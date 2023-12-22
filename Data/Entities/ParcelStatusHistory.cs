using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Enums;
using Data.Interfaces;

namespace Data.Entities
{
    [Table(nameof(ParcelStatusHistory))]
    public class ParcelStatusHistory : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public ParcelStatus Status { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ChangesTime { get; set; }

        [ForeignKey(nameof(Parcel))]
        public Guid ParcelId { get; set; }

        public Parcel Parcel { get; set; }
    }
}
