namespace ChatApp.Server.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
    }
}
