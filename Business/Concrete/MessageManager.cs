using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Entities;

namespace Business.Concrete;

public class MessageManager : IMessageService
{
    private readonly IMessageDal _messageDal;

    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }

    public void Create(Message entity)
    {
        _messageDal.Create(entity);
    }
    public void Update(Message entity)
    {
        _messageDal.Update(entity);
    }
    public void Remove(Message entity)
    {
        _messageDal.Remove(entity);
    }
    public List<Message> GetMessagesByPhone(string phone)
    {
        return _messageDal.GetMessagesByPhone(phone);
    }

    public List<Message> GetMessagesByReceiver(int receiverId, string senderPhone)
    {
        return _messageDal.GetMessagesByReceiver(receiverId, senderPhone);
    }

    public List<Message> GetMessagesBySender(string receiverPhone, int receiverId)
    {
        return _messageDal.GetMessagesBySender(receiverPhone, receiverId);
    }
}
