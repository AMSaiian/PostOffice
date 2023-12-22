using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities
{
    [Table(nameof(PostOffice))]
    public class PostOffice : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.PostalCode)]
        [StringLength(5)]
        public string Zip { get; set; }

        [Required]
        public Address Location { get; set; }

        [InverseProperty("OfficeFrom")]
        public IList<Parcel> SendParcels { get; set; }

        [InverseProperty("OfficeTo")]
        public ICollection<Parcel> ReceiveParcels { get; set; }

        public IList<Staff> OfficeStaff { get; set; }

        [Owned]
        public class Address
        {
            [Required(AllowEmptyStrings = false)]
            public string City { get; set; }
            
            [Required(AllowEmptyStrings = false)]
            public string Street { get; set; }

            [Required(AllowEmptyStrings = false)]
            public string BuildingNumber { get; set; }
        }
    }

    public class PostOfficeConfiguration : IEntityTypeConfiguration<PostOffice>
    {
        public void Configure(EntityTypeBuilder<PostOffice> builder)
        {
            builder.HasIndex(i => i.Zip)
                .HasDatabaseName("Office_zip")
                .IsUnique();
        }
    }
}
