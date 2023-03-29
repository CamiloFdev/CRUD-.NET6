
using Microsoft.EntityFrameworkCore;
using Prueba.Adapters.EntityFramework;
using Prueba.Domain.AggregateRoots;
using Prueba.Domain.Ports.DataAccess;

namespace Prueba.Adapters.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public void CreateUser(User user)
        {

            _context.Users.Add(user);
            _context.SaveChanges();

        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<ICollection<User>> ListUser()
        {
            var users =  await _context.Users.ToListAsync();

            return users;
        }
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();

        }

         public async Task<User> GetUser(int Id)
        {
            var users = await _context.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();

            return users;
        }

        public UserRepository(ApplicationDbContext context)
        {
             _context = context;
            

        }
    }
}
