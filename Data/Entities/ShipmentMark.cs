using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Enums;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities
{
    [Table(nameof(ShipmentMark))]
    public class ShipmentMark : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public ShipmentConstraint ShipmentConstraint { get; set; }

        [Required]
        [Range(minimum: 0, maximum: double.MaxValue)]
        public double PriceCoef { get; set; }

        public IList<CategoryMark> CategoryMarks { get; set; }
    }

    public class ShipmentMarkConfiguration : IEntityTypeConfiguration<ShipmentMark>
    {
        public void Configure(EntityTypeBuilder<ShipmentMark> builder)
        {
            builder.HasIndex(i => i.ShipmentConstraint)
                .HasDatabaseName("Shipment_constraint_type")
                .IsUnique();
        }
    }
}
