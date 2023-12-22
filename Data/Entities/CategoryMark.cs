using System.ComponentModel.DataAnnotations.Schema;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Entities
{
    [Table(nameof(CategoryMark))]
    public class CategoryMark : IEntity
    {
        public Guid CategoryId { get; set; } = Guid.NewGuid();

        public Guid MarkId { get; set; }

        public ItemCategory Category { get; set; }

        public ShipmentMark Mark { get; set; }
    }

    public class CategoryMarkConfiguration : IEntityTypeConfiguration<CategoryMark>
    {
        public void Configure(EntityTypeBuilder<CategoryMark> builder)
        {
            builder.HasKey(cm => new { cm.CategoryId, cm.MarkId });

            builder.HasOne(cm => cm.Category)
                .WithMany(ic => ic.CategoryMarks)
                .HasForeignKey(cm => cm.CategoryId);

            builder.HasOne(cm => cm.Mark)
                .WithMany(m => m.CategoryMarks)
                .HasForeignKey(cm => cm.MarkId);
        }
    }
}
