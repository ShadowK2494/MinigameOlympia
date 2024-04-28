namespace OlympiaWebService.Models
{
    public class Friend
    {
        public string IDSelf { get; set; }
        public string IDFriend { get; set; }
        public Player Player { get; set; }
        public Player FriendPlayer { get; set; }
    }
}
