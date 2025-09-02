using System.ComponentModel.DataAnnotations;

namespace EmployeeLibrary.Models
{
    public class Company : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Address { get; set; }

        [Required, MaxLength(600)]
        public string Description { get; set; }

        [Required, StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
