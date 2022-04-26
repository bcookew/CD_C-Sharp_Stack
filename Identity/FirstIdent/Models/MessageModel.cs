namespace FirstIdent.Models
{
    public class Message
    {
        public int MessageId {get;set;}
        public string MessageText { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}