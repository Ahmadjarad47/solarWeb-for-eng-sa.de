namespace Solares.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public DateTime TimeSendEmail { get; set; } = DateTime.Now;
    }
}
