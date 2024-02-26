using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp27
{
    internal class User
    {
        public static List<User> Users = new List<User>();
        public User(string name, string surname, string number, string email)
        {
            Name = name;
            Surname = surname;
            Number = number;
            Email = email;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
}
