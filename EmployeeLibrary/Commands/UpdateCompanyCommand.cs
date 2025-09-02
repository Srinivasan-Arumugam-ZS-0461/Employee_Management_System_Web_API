using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLibrary.DTO;
using MediatR;

namespace EmployeeLibrary.Commands
{
    public record UpdateCompanyCommand(UpdateCompanyDTO updateCompanyDTO) : IRequest<CompanyDTO>;
}
