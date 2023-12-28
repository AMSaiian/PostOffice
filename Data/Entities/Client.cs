using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities
{
    [Table(nameof(Client))]
    public class Client : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(13)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [InverseProperty("Sender")]
        public IList<Parcel> SentParcels { get; set; }

        [InverseProperty("Receiver")]
        public IList<Parcel> AddressedParcels { get; set; }
    }

    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasIndex(i => new { i.Name, i.Surname })
                .HasDatabaseName("Client_fullname")
                .IsUnique();

            builder.HasIndex(i => i.PhoneNumber)
                .HasDatabaseName("Client_phone_number")
                .IsUnique();
        }
    }
}
