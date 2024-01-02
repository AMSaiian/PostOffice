using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.RequestWraps;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelManagementController : ControllerBase
    {
        private readonly IParcelManagementService _service;

        private readonly ClientValidator _clientValidator;

        private readonly ParcelItemValidator _parcelItemValidator;

        private readonly PostOfficeValidator _postOfficeValidator;

        public ParcelManagementController(
            IParcelManagementService service, 
            ClientValidator clientValidator, 
            ParcelItemValidator parcelItemValidator, 
            PostOfficeValidator postOfficeValidator)
        {
            _service = service;
            _clientValidator = clientValidator;
            _parcelItemValidator = parcelItemValidator;
            _postOfficeValidator = postOfficeValidator;
        }
        
        [Authorize(Roles = "Operator")]
        [HttpPost]
        public async Task<ActionResult<Result<object>>> CreateNewParcel([FromBody] CreateParcelWrap value)
        {
            Result<object> result = new();
            
            ValidationResult senderValidation = await _clientValidator.ValidateAsync(value.Sender);
            ValidationResult receiverValidation = await _clientValidator.ValidateAsync(value.Receiver);
            ValidationResult officeFromValidation = await _postOfficeValidator.ValidateAsync(value.OfficeFrom);
            ValidationResult officeToValidation = await _postOfficeValidator.ValidateAsync(value.OfficeTo);
            List<ValidationResult> parcelItemValidation = new List<ValidationResult>();

            foreach (var parcelItem in value.Items)
            {
                parcelItemValidation.Add(await _parcelItemValidator.ValidateAsync(parcelItem));
            }

            bool isValid = 
                senderValidation.IsValid 
                && receiverValidation.IsValid 
                && officeFromValidation.IsValid 
                && officeToValidation.IsValid
                && parcelItemValidation.All(v => v.IsValid);

            if (isValid)
            {
                result = await _service.CreateParcelAsync(
                value.Sender, value.Receiver,
                value.OfficeFrom, value.OfficeTo,
                value.Items);

                if (result.IsSuccess)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            else
            {
                result.IsSuccess = false;
                result.Errors.AddRange(senderValidation.Errors.Select(e => e.ErrorMessage));
                result.Errors.AddRange(receiverValidation.Errors.Select(e => e.ErrorMessage));
                result.Errors.AddRange(officeFromValidation.Errors.Select(e => e.ErrorMessage));
                result.Errors.AddRange(officeToValidation.Errors.Select(e => e.ErrorMessage));
                result.Errors.AddRange(parcelItemValidation.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                result.Errors = result.Errors.Distinct().ToList();

                return BadRequest(result);
            }
        }

        [Authorize(Roles = "Operator")]
        [HttpGet("arrivedParcels/{zip}")]
        public async Task<ActionResult<Result<IEnumerable<ArrivedParcelModel>>>> GetArrivedParcels(string zip)
        {
            Result<IEnumerable<ArrivedParcelModel>> result = await _service.GetParcelsInOfficeAsync(zip);
            return Ok(result);
        }

        [Authorize(Roles = "Operator")]
        [HttpPut("changeStatus")]
        public async Task<ActionResult<Result<object>>> ChangeParcelStatus([FromBody] ParcelStatusHistoryModel value)
        {
            Result<object> result = await _service.ChangeParcelStatusAsync(value);
            return Ok(result);
        }

        [Authorize(Roles = "Operator")]
        [HttpPost("clientArrivedParcels/{zip}")]
        public async Task<ActionResult<Result<IEnumerable<ForGrantParcelModel>>>> GetClientArrivedParcels(string zip, [FromBody] ClientModel client)
        {
            Result<IEnumerable<ForGrantParcelModel>> result = new();
            ValidationResult clientValidation = await _clientValidator.ValidateAsync(client);

            if (!clientValidation.IsValid)
            {
                result.IsSuccess = false;
                result.Errors.AddRange(clientValidation.Errors.Select(e => e.ErrorMessage));
                return BadRequest(result);
            }
            
            result = await _service.GetClientArrivedParcelsAsync(zip, client);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
