using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities
{
    [Table(nameof(ItemCategory))]
    public class ItemCategory : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public IList<ParcelItem> ParcelItems { get; set; }

        public IList<CategoryMark> CategoryMarks { get; set; }
    }

    public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.HasIndex(i => i.Name)
                .HasDatabaseName("Category_name")
                .IsUnique();
        }
    }
}
