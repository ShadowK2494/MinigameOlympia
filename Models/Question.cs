using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinigameOlympia.Models
{
    public class Question
    {
        public string IDQuestion { get; set; }
        public int Round { get; set; }
        public string Quest { get; set; }
        public bool IsMain { get; set; }
        public ICollection<GroupQuestion> QuestionOfs { get; set; }
        public ICollection<GroupQuestion> MemberQuestions { get; set; }
        public Answer Answer { get; set; }
    }
}
