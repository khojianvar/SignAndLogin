using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignAndLogin
{
    internal class User
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public User(string fullName, string userName, string password, string phoneNumber)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            PhoneNumber = phoneNumber;
        }

    }
}
