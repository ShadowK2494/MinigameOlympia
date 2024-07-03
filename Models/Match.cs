using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinigameOlympia.Models
{
    class Match
    {
        public string IDPlayer { get; set; }
        public string IDRoom { get; set; }
        public DateTime Time { get; set; }
        public Player Player { get; set; }
     //   public Room Room { get; set; }
    }
}
