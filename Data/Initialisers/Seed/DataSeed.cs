using Data.Entities;
using Data.Enums;
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Data.Initialisers.Seed
{
    public class DataSeed : IDataSeed
    {
        public IList<ShipmentMark> Marks { get; }

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
            var passwordHasher = new PasswordHasher<Staff>();
            
            Marks = new List<ShipmentMark>
            {
                new() { Id = new Guid("7db4e315d56b4ad8b5f20e5fad48807f"), ShipmentConstraint = ShipmentConstraint.Fragile, PriceCoef = 0.2 },
                new() { Id = new Guid("32a1ce4ab821458388a636256c22e23a"), ShipmentConstraint = ShipmentConstraint.KeepDry, PriceCoef = 0.05 },
                new() { Id = new Guid("df1b805f4691465ea99846ddf7bce73a"), ShipmentConstraint = ShipmentConstraint.ProtectFromHeat, PriceCoef = 0.1 },
                new() { Id = new Guid("e3b5adf334ed4a018908e9a78b6ee6e6"), ShipmentConstraint = ShipmentConstraint.TemperatureSensitive, PriceCoef = 0.15 },
                new() { Id = new Guid("e27ab36e16f54a2f84fcf91ad9ee57df"), ShipmentConstraint = ShipmentConstraint.FastExpiring, PriceCoef = 0.25 }
            };

            Categories = new List<ItemCategory>
            {
                new() { Id = new Guid("a4faf9938ede4dda97761d11550952f5"), Name = "Furniture" },
                new() { Id = new Guid("a39cc474d58d4d9481ee94f6adcd416c"), Name = "Clothes" },
                new() { Id = new Guid("d572663bd9eb479e9c99fd3c313c8a1b"), Name = "Electronics" },
                new() { Id = new Guid("8254380b3bf54d0aaeb614818f28145b"), Name = "Stationery" },
                new() { Id = new Guid("0c13456b64f94d4090516fa60c9683ba"), Name = "Canned food" },
                new() { Id = new Guid("42144044a52843d18f9057a6fc630326"), Name = "Packed food" },
                new() { Id = new Guid("27484061b4b24e9f89f4c2cdaa3ec60f"), Name = "Hygiene" },
                new() { Id = new Guid("8e11129b028648a7826545c2c831e5a2"), Name = "Books" },
                new() { Id = new Guid("a8a9df352210400295f0854e83f76781"), Name = "Medicines" },
                new() { Id = new Guid("b9bb3a75213e46e4afc0b0d6d7274320"), Name = "Parts" },
                new() { Id = new Guid("4ef36558f4ad4a58b6c3eeba2ed8dcd7"), Name = "Tools" },
                new() { Id = new Guid("1653f82e9ed941a49c1220a086b56545"), Name = "Devices" },
                new() { Id = new Guid("11f7f3b20aa546e9b2c64f93fbb99cc3"), Name = "Sport equipment" },
                new() { Id = new Guid("6a864ae6a3b24ff89fbb820b0143c7e6"), Name = "Household chemicals" },
                new() { Id = new Guid("6f93d7fe5caa4b7a877d5e2a67a6ef2b"), Name = "Building materials"},
                new() { Id = new Guid("e7dd269bbbdf417ca85d6a6a08c806bd"), Name = "Other"}
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
                { Id = new Guid("4e194baf11174426a89c91f04db6dbd4"), Zip = "03056", 
                    Location = new PostOffice.Address { City = "Kyiv", Street = "Borshchagivska", BuildingNumber = "146" }
                },
                new()
                { Id = new Guid("f7a646036f15446fa424aef73ed7a54c"), Zip = "49086", 
                    Location = new PostOffice.Address { City = "Dnipro", Street = "Pidhirna", BuildingNumber = "19" }
                }
            };

            Staff = new List<Staff>
            {
                new() { Id = new Guid("ea44a4e9712a416db7b34a292bfcab83"), Name = "John", Surname = "Smith", 
                    Role = UserRole.Admin, PhoneNumber = "+380950000001", 
                    PasswordHash = passwordHasher.HashPassword(null, "AdminAdmin1")},
                new() { Id = new Guid("d47f4cd82def4976a2e00c7cca32fe9e"),  Name = "Sam", Surname = "Samuelson", 
                    Role = UserRole.Manager, PostOfficeId = Offices[0].Id, PhoneNumber = "+380950000002", 
                    PasswordHash = passwordHasher.HashPassword(null, "ManagerManager1") },
                new() { Id = new Guid("1955358bd6f1463b95e62cf03478ef5a"), Name = "Bob", Surname = "Samuelson", 
                    Role = UserRole.Manager, PostOfficeId = Offices[1].Id, PhoneNumber = "+380950000003",
                    PasswordHash = passwordHasher.HashPassword(null, "ManagerManager2")
                },
                new() { Id = new Guid("5a90a96e2524414dae07dc4939ec5dbd"),  Name = "Robert", Surname = "Thompson", 
                    Role = UserRole.Operator, PostOfficeId = Offices[0].Id, PhoneNumber = "+380950000004",
                    PasswordHash = passwordHasher.HashPassword(null, "OperatorOperator1")
                },
                new() { Id = new Guid("13c466c093e9430ba6a602517d8281d7"),  Name = "Angela", Surname = "Thompson", 
                    Role = UserRole.Operator, PostOfficeId = Offices[1].Id, PhoneNumber = "+380950000005",
                    PasswordHash = passwordHasher.HashPassword(null, "OperatorOperator2")
                }
            };

            Parcels = new List<Parcel>();
            
            ParcelItems = new List<ParcelItem>();

            StatusHistory = new List<ParcelStatusHistory>();
        }
    }
}
