using Data.Entities;
using Data.Enums;
using Data.Interfaces;

namespace Data.Initialisers.Seed
{
    public class DataSeed : IDataSeed
    {
        public IList<ShipmentMark> Marks { get; }

        public IList<Position> Positions { get; }

        public IList<ItemCategory> Categories { get; } 

        public IList<CategoryMark> CategoryMarks { get; } 

        public IList<Parcel> Parcels { get; }

        public IList<ParcelItem> ParcelItems { get; }

        public IList<ParcelStatusHistory> StatusHistory { get; }

        public IList<PostOffice> Offices { get; }
        
        public IList<Client> Clients { get; } = new List<Client>();

        public IList<Staff> Staff { get; }
        
        public DataSeed()
        {
            Marks = new List<ShipmentMark>
            {
                new() { Id = Guid.NewGuid(), ShipmentConstraint = ShipmentConstraint.Fragile, PriceCoef = 0.2 },
                new() { Id = Guid.NewGuid(), ShipmentConstraint = ShipmentConstraint.KeepDry, PriceCoef = 0.05 },
                new() { Id = Guid.NewGuid(), ShipmentConstraint = ShipmentConstraint.ProtectFromHeat, PriceCoef = 0.1 },
                new() { Id = Guid.NewGuid(), ShipmentConstraint = ShipmentConstraint.TemperatureSensitive, PriceCoef = 0.15 },
                new() { Id = Guid.NewGuid(), ShipmentConstraint = ShipmentConstraint.FastExpiring, PriceCoef = 0.25 }
            };

            Positions = new List<Position>
            {
                new() { Id = Guid.NewGuid(), Name = "Operator" },
                new() { Id = Guid.NewGuid(), Name = "Office manager" },
                new() { Id = Guid.NewGuid(), Name = "System manager" }
            };

            Categories = new List<ItemCategory>
            {
                new() { Id = Guid.NewGuid(), Name = "Furniture" },
                new() { Id = Guid.NewGuid(), Name = "Clothes" },
                new() { Id = Guid.NewGuid(), Name = "Electronics" },
                new() { Id = Guid.NewGuid(), Name = "Stationery" },
                new() { Id = Guid.NewGuid(), Name = "Canned food" },
                new() { Id = Guid.NewGuid(), Name = "Packed food" },
                new() { Id = Guid.NewGuid(), Name = "Hygiene" },
                new() { Id = Guid.NewGuid(), Name = "Books" },
                new() { Id = Guid.NewGuid(), Name = "Medicines" },
                new() { Id = Guid.NewGuid(), Name = "Parts" },
                new() { Id = Guid.NewGuid(), Name = "Tools" },
                new() { Id = Guid.NewGuid(), Name = "Devices" },
                new() { Id = Guid.NewGuid(), Name = "Sport equipment" },
                new() { Id = Guid.NewGuid(), Name = "Household chemicals" },
                new() { Id = Guid.NewGuid(), Name = "Building materials"},
                new() { Id = Guid.NewGuid(), Name = "Other"}
            };

            CategoryMarks = new List<CategoryMark>
            {
                new() { CategoryId = Categories[0].Id, MarkId = Marks[1].Id },

                new() { CategoryId = Categories[1].Id, MarkId = Marks[1].Id },

                new() { CategoryId = Categories[2].Id, MarkId = Marks[0].Id },
                new() { CategoryId = Categories[2].Id, MarkId = Marks[1].Id },
                new() { CategoryId = Categories[2].Id, MarkId = Marks[2].Id },

                new() { CategoryId = Categories[3].Id, MarkId = Marks[1].Id },

                new() { CategoryId = Categories[4].Id, MarkId = Marks[2].Id },

                new() { CategoryId = Categories[5].Id, MarkId = Marks[4].Id },

                new() { CategoryId = Categories[7].Id, MarkId = Marks[1].Id },

                new() { CategoryId = Categories[8].Id, MarkId = Marks[3].Id },
                new() { CategoryId = Categories[8].Id, MarkId = Marks[4].Id },

                new() { CategoryId = Categories[9].Id, MarkId = Marks[1].Id },

                new() { CategoryId = Categories[11].Id, MarkId = Marks[0].Id },
                new() { CategoryId = Categories[11].Id, MarkId = Marks[1].Id },

                new() { CategoryId = Categories[12].Id, MarkId = Marks[0].Id }
            };

            Offices = new List<PostOffice>     
            {
                new()
                { Id = Guid.NewGuid(), Zip = "03056", 
                    Location = new PostOffice.Address { City = "Kyiv", Street = "Borshchagivska", BuildingNumber = "146" }
                },
                new()
                { Id = Guid.NewGuid(), Zip = "49086", 
                    Location = new PostOffice.Address { City = "Dnipro", Street = "Pidhirna", BuildingNumber = "19" }
                }
            };

            Staff = new List<Staff>
            {
                new() { Id = Guid.NewGuid(), Name = "John", Surname = "Smith", 
                    PositionId = Positions[2].Id, PhoneNumber = "+380950000001"},
                new() { Id = Guid.NewGuid(),  Name = "Sam", Surname = "Samuelson", 
                    PositionId = Positions[1].Id, PostOfficeId = Offices[0].Id, PhoneNumber = "+380950000002" },
                new() { Id = Guid.NewGuid(), Name = "Bob", Surname = "Samuelson", 
                    PositionId = Positions[1].Id, PostOfficeId = Offices[1].Id, PhoneNumber = "+380950000003" },
                new() { Id = Guid.NewGuid(),  Name = "Robert", Surname = "Thompson", 
                    PositionId = Positions[0].Id, PostOfficeId = Offices[0].Id, PhoneNumber = "+380950000004" },
                new() { Id = Guid.NewGuid(),  Name = "Angela", Surname = "Thompson", 
                    PositionId = Positions[0].Id, PostOfficeId = Offices[1].Id, PhoneNumber = "+380950000005"}
            };

            Parcels = new List<Parcel>();
            
            ParcelItems = new List<ParcelItem>();

            StatusHistory = new List<ParcelStatusHistory>();
        }
    }
}
