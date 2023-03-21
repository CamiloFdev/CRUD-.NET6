using Prueba.Adapters.EntityFramework;
using Prueba.Domain.Ports.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Adapters.DataAccess
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        public IUserRepository users { get; }

        public ApplicationUnitOfWork(IUserRepository userRepository)
        {
            users = userRepository;
        }
    }
}
