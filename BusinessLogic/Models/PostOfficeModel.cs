using BusinessLogic.Interfaces;


namespace BusinessLogic.Models
{
    public class PostOfficeModel : IModel
    {
        public Guid? Id { get; set; } 

        public string? Zip { get; set; }

        public AddressModel? Location { get; set; }

        public class AddressModel
        {
            public string? City { get; set; }
            
            public string? Street { get; set; }

            public string? BuildingNumber { get; set; }
        }
    }
}
