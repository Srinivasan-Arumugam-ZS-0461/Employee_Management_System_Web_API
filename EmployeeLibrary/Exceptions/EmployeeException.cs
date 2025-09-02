using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EmployeeLibrary.Exceptions
{
    public class EmployeeException : Exception
    {
        public EmployeeException(string message) : base(message)
        {
        }
        
    }
}
