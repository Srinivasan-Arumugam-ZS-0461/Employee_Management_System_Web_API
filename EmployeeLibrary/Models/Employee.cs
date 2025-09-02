using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeLibrary.Enums;

namespace EmployeeLibrary.Models
{
    public class Employee : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }

        [Required]
        public EmployeeRoles Role { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

    }
}
