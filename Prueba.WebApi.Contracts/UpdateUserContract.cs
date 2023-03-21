using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.WebApi.Contracts
{
    public record UpdateUserContract(int Id, string FirstName, string LastName, string mail);
}
