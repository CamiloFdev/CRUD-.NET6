

namespace Prueba.Domain.Ports.DataAccess
{
    public interface IApplicationUnitOfWork
    {
        IUserRepository Users { get; }  
    }
}
