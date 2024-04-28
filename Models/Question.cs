using System.Collections.Generic;

namespace OlympiaWebService.Models
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
