using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinigameOlympia.Models
{
    public class Answer
    {
        public string IDAnswer { get; set; }
        public string Answ { get; set; }
        public string Picture { get; set; }
        public Question Question { get; set; }
    }
}
