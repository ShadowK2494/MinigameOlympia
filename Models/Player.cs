<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinigameOlympia.Models {
    internal class Player {
=======
﻿using MinigameOlympia;
using OlympiaWebService.Helper;
using System.Collections.Generic;

namespace OlympiaWebService.Models
{
    public class Player
    {
>>>>>>> DinhQuang
        public string IDPlayer { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int WinCount { get; set; }
    }
}
