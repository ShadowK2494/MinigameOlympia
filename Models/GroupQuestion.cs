using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinigameOlympia.Models
{
    public class GroupQuestion
    {
        public string IDQuestion { get; set; }
        public string IDGroup { get; set; }
        public Question Main { get; set; }
        public Question Member { get; set; }
    }
}
