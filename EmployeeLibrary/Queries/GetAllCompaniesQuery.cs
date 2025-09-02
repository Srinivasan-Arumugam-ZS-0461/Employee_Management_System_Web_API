using EmployeeLibrary.DTO;
using MediatR;

namespace EmployeeLibrary.Queries
{
    public record GetAllCompaniesQuery() : IRequest<IEnumerable<CompanyDTO>>;
}
