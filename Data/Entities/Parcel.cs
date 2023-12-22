using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Enums;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities
{
    [Table(nameof(Parcel))]
    public class Parcel : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public ParcelStatus Status { get; set; }

        [Required]
        [ForeignKey("OfficeFrom")]
        public Guid OfficeFromId { get; set; }

        [Required]
        [ForeignKey("OfficeTo")]
        public Guid OfficeToId { get; set; }

        [Required]
        [ForeignKey("Sender")]
        public Guid SenderId { get; set; }

        [Required]
        [ForeignKey("Receiver")]
        public Guid ReceiverId { get; set; }

        public PostOffice OfficeFrom { get; set; }

        public PostOffice OfficeTo { get; set; }

        public Client Sender { get; set; }

        public Client Receiver { get; set; }

        public IList<ParcelItem> ParcelFilling { get; set; }

        public IList<ParcelStatusHistory> ParcelHistory { get; set; }
    }

    public class ParcelConfiguration : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            builder.HasOne(p => p.OfficeFrom)
                .WithMany(o => o.SendParcels)
                .HasForeignKey(p => p.OfficeFromId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.OfficeTo)
                .WithMany(o => o.ReceiveParcels)
                .HasForeignKey(p => p.OfficeToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Sender)
                .WithMany(c => c.SentParcels)
                .HasForeignKey(p => p.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Receiver)
                .WithMany(c => c.AddressedParcels)
                .HasForeignKey(p => p.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
