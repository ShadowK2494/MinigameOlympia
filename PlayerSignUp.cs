using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinigameOlympia {
    internal class PlayerSignUp {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public PlayerSignUp() { }
        public PlayerSignUp(string name, string username, string pass, int gender, string email, string phone) {
            Name = name;
            Username = username;
            Password = pass;
            if (gender == 0)
                Gender = Gender.Male;
            else if (gender == 1)
                Gender = Gender.Female;
            else
                Gender = Gender.Other;
            Email = email;
            PhoneNumber = phone;
        }
    }
    
}
