

namespace Prueba.Domain.AggregateRoots
{
    public class User
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        public string Mail { get; protected set; }

        public User(string firstName, string lastName, string mail)
        {

            FirstName = firstName;
            LastName = lastName;
            this.Mail = mail;
        }

        public User(int id, string firstName, string lastName, string mail)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            this.Mail = mail;

        }

        public void UpdateState( string firstName, string lastName, string mail)
        {
           
            FirstName = firstName;
            LastName = lastName;
            Mail = mail;
        }
    }

   
}
