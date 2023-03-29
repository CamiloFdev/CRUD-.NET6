
using Prueba.Domain.Ports.DataAccess;

namespace Prueba.Adapters.DataAccess
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        public IUserRepository Users { get; }

        public ApplicationUnitOfWork(IUserRepository userRepository)
        {
            Users = userRepository;
        }
    }
}
