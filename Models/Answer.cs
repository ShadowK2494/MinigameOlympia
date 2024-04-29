namespace OlympiaWebService.Models
{
    public class Answer
    {
        public string IDAnswer { get; set; }
        public string Answ { get; set; }
        public string Picture { get; set; }
        public Question Question { get; set; }
    }
}
