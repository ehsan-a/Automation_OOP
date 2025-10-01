using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_OOP
{
    internal class User
    {
        public enum type
        {
            Junior = 0,
            MidLevel = 1,
            Senior = 2
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public type UserType { get; set; }
        public User(string firstName, string lastName, type userType, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserType = userType;
            Username = username;
            Password = password;
        }
    }
}