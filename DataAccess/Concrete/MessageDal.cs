using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class MessageDal : BaseRepository<Message>, IMessageDal
{
    private readonly BaseContext _context;
    public MessageDal(BaseContext context) : base(context)
    {
        _context = context;
    }

    public List<Message> GetMessagesByPhone(string phone)
    {
        return _context.Messages.Include(x => x.AppUser)
                                .Where(x => x.SenderPhone == phone).ToList();
    }

    public List<Message> GetMessagesByReceiver(int receiverId, string senderPhone)
    {
        return _context.Messages.Include(x => x.AppUser)
                                .Where(x => x.AppUserId == receiverId && x.SenderPhone == senderPhone).ToList();
    }

    public List<Message> GetMessagesBySender(string receiverPhone, int receiverId)
    {
        return _context.Messages.Include(x => x.AppUser)
                                .Where(x => x.AppUserId == receiverId && x.ReceiverPhone == receiverPhone).ToList();
    }
}
