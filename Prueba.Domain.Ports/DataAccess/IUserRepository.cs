using Prueba.Domain.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Domain.Ports.DataAccess
{
    public interface IUserRepository
    {

        public void CreateUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(User user);
        public Task<ICollection<User>> ListUser();

        public Task<User> GetUser(int Id);




    }
}
