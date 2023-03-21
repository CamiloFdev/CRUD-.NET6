using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Domain.Ports.DataAccess
{
    public interface IApplicationUnitOfWork
    {
        IUserRepository users { get; }  
    }
}
