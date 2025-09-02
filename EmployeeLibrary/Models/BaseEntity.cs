namespace EmployeeLibrary.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
