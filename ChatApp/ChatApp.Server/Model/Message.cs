namespace ChatApp.Server.Model
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string User { get; set; }

        public string SendTime { get; set; }= DateTime.Now.ToString();
    }
}
