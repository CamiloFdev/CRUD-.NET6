using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Domain.AggregateRoots
{
    public class User
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        public string mail { get; protected set; }

        public User(string firstName, string lastName, string mail)
        {

            FirstName = firstName;
            LastName = lastName;
            this.mail = mail;
        }

        public User(int id, string firstName, string lastName, string mail)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            this.mail = mail;

        }

        public  User UpdateState(int id, string firstName, string lastName, string mail, User user)
        {
            user.Id = id;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.mail = mail;


            return user;
        }
    }

   
}
