using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatrogzito
{
    internal class User
    {
        public User(string name, int age, int phoneNumber, string address, string email, string gender , string comment)
        {
            Name = name;
            Age = age;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            Gender = gender;
            Comment = comment;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Comment { get; set; }

        public override string ToString()
        {
            return $"{Name},{Age},{PhoneNumber},{Address},{Email},{Gender},{Comment}";
        }

        public static User FromString(string userData)
        {
            var parts = userData.Split(",");
            return new User(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), parts[3], parts[4], parts[5], parts[6]);

        }
    }
}
