using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    [Table(nameof(ParcelItem))]
    public class ParcelItem : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        [Required]
        public Gabarites Characteristics { get; set; }

        [ForeignKey(nameof(ItemCategory))]
        public Guid ItemCategoryId { get; set; }

        [ForeignKey(nameof(Parcel))]
        public Guid ParcelId { get; set; }

        public ItemCategory ItemCategory { get; set; }

        public Parcel Parcel { get; set; }
        
        [Owned]
        public class Gabarites
        {
            [Required]
            [Range(minimum: 1, maximum: int.MaxValue)]
            public int Width { get; set; }

            [Required]
            [Range(minimum: 1, maximum: int.MaxValue)]
            public int Height { get; set; }

            [Required]
            [Range(minimum: 1, maximum: int.MaxValue)]
            public int Depth { get; set; }

            [Required]
            [Range(minimum: 0.001, double.MaxValue)]
            public double Weight { get; set; }
        }
    }
}
