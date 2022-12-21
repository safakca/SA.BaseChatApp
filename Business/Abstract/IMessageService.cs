using DataAccess.Entities;
using DataAccess.Repository;

namespace Business.Abstract;
public interface IMessageService : IBaseRepository<Message>
{
    List<Message> GetMessagesByPhone(string phone);
    List<Message> GetMessagesByReceiver(int receiverId, string senderPhone);
    List<Message> GetMessagesBySender(string receiverPhone, int receiverId);
}

