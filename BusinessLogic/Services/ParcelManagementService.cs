using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Data.Context;
using Data.Entities;
using Data.Enums;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ParcelManagementService : IParcelManagementService
    {
        private readonly PostOfficeContext _context;

        private readonly IMapper _mapper;

        public ParcelManagementService(PostOfficeContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }

        public async Task<Result<object>> CreateParcelAsync(
            ClientModel sender, ClientModel receiver, 
            PostOfficeModel officeFrom, PostOfficeModel officeTo, 
            IEnumerable<ParcelItemModel> items)
        {
            Result<object> result = new();
            Client senderEntity = _mapper.Map<Client>(sender);
            Client receiverEntity = _mapper.Map<Client>(receiver);

            PostOffice officeFromEntity = _mapper.Map<PostOffice>(officeFrom);
            PostOffice officeToEntity = _mapper.Map<PostOffice>(officeTo);

            Parcel parcelEntity = new Parcel();
            IEnumerable<ParcelItem> parcelItems = _mapper.Map<IEnumerable<ParcelItem>>(items);

            await ProcessSenderAsync(senderEntity, parcelEntity, result);
            if (!result.IsSuccess)
                return result;

            await ProcessReceiverAsync(receiverEntity, parcelEntity, result);
            if (!result.IsSuccess)
                return result;

            DefineOffices(officeFromEntity, officeToEntity, parcelEntity);

            await ProcessParcelItemsAsync(parcelEntity, parcelItems);

            await ProcessParcelStatusHistoryAsync(parcelEntity);

            await _context.Set<Parcel>().AddAsync(parcelEntity);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<Result<object>> ChangeParcelStatusAsync(ParcelStatusHistoryModel statusModel)
        {
            Result<object> result = new();
            
            ParcelStatusHistory newStatus = _mapper.Map<ParcelStatusHistory>(statusModel);

            Parcel? parcel = await _context.Set<Parcel>().FindAsync(newStatus.ParcelId);

            if (parcel is null)
            {
                result.IsSuccess = false;
                result.Errors.Add("Parcel doesn't exist in context");
                return result;
            }

            if (parcel.Status == statusModel.Status)
            {
                result.IsSuccess = false;
                result.Errors.Add("Parcel already has this status");
                return result;
            }

            parcel.Status = newStatus.Status;

            _context.Set<Parcel>().Update(parcel);

            await _context.Set<ParcelStatusHistory>().AddAsync(newStatus);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<Result<IEnumerable<ParcelModel>>> GetParcelsInOfficeAsync(PostOfficeModel officeModel)
        {
            Result<IEnumerable<ParcelModel>> result = new();

            PostOffice office = _mapper.Map<PostOffice>(officeModel);

            PostOffice? officeInContext = await _context.Set<PostOffice>().FirstOrDefaultAsync(
                               o => o.Zip == office.Zip);

            if (officeInContext is null)
            {
                result.IsSuccess = false;
                result.Errors.Add("Office doesn't exist in context");
                return result;
            }

            IEnumerable<Parcel> parcels = _context.Set<Parcel>()
                .Where(p => p.OfficeToId == officeInContext.Id
                && p.Status == ParcelStatus.RecievedByRecipient);

            IEnumerable<ParcelModel> parcelModels = _mapper.Map<IEnumerable<ParcelModel>>(parcels);
            
            result.Value = parcelModels;
            return result;
        }

        public async Task<Result<IEnumerable<ParcelModel>>> GetClientArrivedParcelsAsync(ClientModel clientModel)
        {
            Result<IEnumerable<ParcelModel>> result = new();
            Client client = _mapper.Map<Client>(clientModel);

            Client? clientInContext = await _context.Set<Client>().FirstOrDefaultAsync(
                c => c.PhoneNumber == client.PhoneNumber
                     && c.Name == client.Name
                     && c.Surname == client.Surname);

            if (clientInContext is null)
            {
                result.IsSuccess = false;
                result.Errors.Add("Client doesn't exist in context");
                return result;
            }

            IEnumerable<Parcel> parcels = _context.Set<Parcel>()
                .Where(
                    p => p.ReceiverId == clientInContext.Id 
                         && p.Status == ParcelStatus.ReadyForGranting);

            IEnumerable<ParcelModel> parcelModels = _mapper.Map<IEnumerable<ParcelModel>>(parcels);

            result.Value = parcelModels;
            return result;
        }

        private bool IsExistClientValid(Client client, Client clientInContext)
        {
            return client.Name == clientInContext.Name &&
                   client.Surname == clientInContext.Surname && 
                   client.PhoneNumber == clientInContext.PhoneNumber;
        }


        private async Task ProcessSenderAsync(Client senderEntity, Parcel parcelEntity, Result<object> result)
        {
            Client? senderInContext = await _context.Set<Client>().FirstOrDefaultAsync(c => c.PhoneNumber == senderEntity.PhoneNumber);

            if (senderInContext is null)
            {
                parcelEntity.SenderId = senderEntity.Id;
                await _context.Set<Client>().AddAsync(senderEntity);
            }
            else if (IsExistClientValid(senderEntity, senderInContext))
            {
                parcelEntity.SenderId = senderInContext.Id;
            }
            else
            {
                result.IsSuccess = false;
                result.Errors.Add("Sender phone number already owned");
            }
        }

        private async Task ProcessReceiverAsync(Client receiverEntity, Parcel parcelEntity, Result<object> result)
        {
            Client? receiverInContext = await _context.Set<Client>().FirstOrDefaultAsync(c => c.PhoneNumber == receiverEntity.PhoneNumber);

            if (receiverInContext is null)
            {
                parcelEntity.ReceiverId = receiverEntity.Id;
                await _context.Set<Client>().AddAsync(receiverEntity);
            }
            else if (IsExistClientValid(receiverEntity, receiverInContext))
            {
                parcelEntity.ReceiverId = receiverInContext.Id;
            }
            else
            {
                result.IsSuccess = false;
                result.Errors.Add("Receiver phone number already owned");
            }
        }

        private void DefineOffices(PostOffice officeFromEntity, PostOffice officeToEntity, Parcel parcelEntity)
        {
            parcelEntity.OfficeFromId = officeFromEntity.Id;
            parcelEntity.OfficeToId = officeToEntity.Id;
            parcelEntity.Status = ParcelStatus.RecievedBySender;
        }

        private async Task ProcessParcelItemsAsync(Parcel parcelEntity, IEnumerable<ParcelItem> parcelItems)
        {
            foreach (var parcelItem in parcelItems)
            {
                parcelItem.ParcelId = parcelEntity.Id;
                await _context.Set<ParcelItem>().AddAsync(parcelItem);
            }
        }

        private async Task ProcessParcelStatusHistoryAsync(Parcel parcelEntity)
        {
            ParcelStatusHistory parcelStatusHistory = new()
            {
                ParcelId = parcelEntity.Id,
                Status = ParcelStatus.RecievedBySender,
                ChangesTime = DateTime.Now
            };

            await _context.Set<ParcelStatusHistory>().AddAsync(parcelStatusHistory);
        }
    }
}
