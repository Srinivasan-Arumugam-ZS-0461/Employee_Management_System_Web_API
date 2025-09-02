using EmployeeLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLibrary
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Company Table 
            //A Company can have many employees. CompanyId is the foreign key in Employee table. A Company cannot be deleted if it has employees.
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // A Company must have a unique phone number.
            modelBuilder.Entity<Company>()
                .HasIndex(c => c.PhoneNumber)
                .IsUnique();

            //A Company must have a unique email.
            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Email)
                .IsUnique();
            #endregion

            #region Employee Table 
            // An Employee must have a unique phone number.
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.PhoneNumber)
                .IsUnique();

            // An Employee must have a unique email.
            modelBuilder.Entity<Employee>()
                .HasIndex(c => c.Email)
                .IsUnique();

            // An Employee's Role is an enum and should be stored as a string in the database.
            modelBuilder.Entity<Employee>()
                .Property(e => e.Role)
                .HasConversion<string>();
            #endregion

            #region Seed Data
            Company company = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Zuci Systems",
                Description = "Zuci Systems is a leading software development company specializing in custom software solutions, " +
                    "mobile app development, and web application development. We are committed to delivering high-quality software " +
                    "products that meet the unique needs of our clients.",
                Address = "123 Main St, Thoraipakkam, Chennai",
                PhoneNumber = "1234567890",
                Email = "zucisystems@zucisystems.com",
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            modelBuilder.Entity<Company>().HasData(company);

            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bala Venkata Rama Sai Immadisetty",
                    PhoneNumber = "9876543210",
                    Email = "bala@zucisystems.com",
                    DOB = new DateTime(2003, 06, 15),
                    Address = "123 Sai Baba PG, Thoraipakkam, Chennai",
                    Role = Enums.EmployeeRoles.Developer,
                    CompanyId = company.Id,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Srinivasan Arumugam",
                    PhoneNumber = "1234567890",
                    Email = "srinivasan@zucisystems.com",
                    DOB = new DateTime(2003, 02, 22),
                    Address = "123 Annai Indira Nagar, Thoraipakkam, Chennai",
                    Role = Enums.EmployeeRoles.Developer,
                    CompanyId = company.Id,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                }
            );

            #endregion
        }
    }
}
