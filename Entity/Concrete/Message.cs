namespace DataAccess.Entities;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string ReceiverName { get; set; }
    public string ReceiverPhone { get; set; }
    public string SenderPhone { get; set; }
    public DateTime Date { get; set; }

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}
