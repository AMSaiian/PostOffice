using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities
{
    [Table(nameof(Staff))]
    public class Staff : IEntity
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

        [ForeignKey(nameof(Position))]
        public Guid PositionId { get; set; }

        [ForeignKey(nameof(PostOffice))]
        public Guid? PostOfficeId { get; set; }

        public PostOffice? PostOffice { get; set; }

        public Position Position { get; set; }
    }

    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasIndex(i => new { i.Name, i.Surname })
                .HasDatabaseName("Staff_fullname")
                .IsUnique();

            builder.HasIndex(i => i.PhoneNumber)
                .HasDatabaseName("Staff_phone_number")
                .IsUnique();
        }
    }
}
