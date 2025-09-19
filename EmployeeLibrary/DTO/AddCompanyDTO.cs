using System.ComponentModel.DataAnnotations;

namespace EmployeeLibrary.DTO
{
    public class AddCompanyDTO
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }
        [Required, MaxLength(600)]
        public string Description { get; set; }
        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
