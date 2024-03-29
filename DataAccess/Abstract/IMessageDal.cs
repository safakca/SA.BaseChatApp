﻿using DataAccess.Entities;
using DataAccess.Repository;

namespace DataAccess.Abstract;

public interface IMessageDal : IBaseRepository<Message>
{
    List<Message> GetMessagesByPhone(string phone);
    List<Message> GetMessagesByReceiver(int receiverId, string senderPhone);
    List<Message> GetMessagesBySender(string receiverPhone, int receiverId);
}
