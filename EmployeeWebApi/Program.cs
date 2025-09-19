using EmployeeLibrary;
using EmployeeLibrary.AutoMapper;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Queries;
using EmployeeLibrary.Repositories;
using EmployeeLibrary.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EmployeeWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            try
            {
                Log.Information("Starting up the application");

                var builder = WebApplication.CreateBuilder(args);

                //Configuring the Serilog
                builder.Host.ConfigureSerilog();
                // Register the Repositories and its implementation.
                builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

                //Add the MediatR library for handling requests.

                builder.Services.AddMediatR(configuration =>
                {
                    configuration.RegisterServicesFromAssemblies(typeof(GetAllCompaniesQuery).Assembly);
                });

                builder.Services.AddAutoMapper(typeof(MappingProfile));
                // Add services to the container.

                builder.Services.AddControllers();
                builder.Services.AddScoped<ICompanyService, CompanyService>();
                builder.Services.AddDbContext<EmployeeDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
