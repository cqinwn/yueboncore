using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yuebon.Email.CommandHandler;

public class SendMailCommandHandler : IRequestHandler<SendMailCommand, SendResultEntity>
{
    public async Task<SendResultEntity> Handle(SendMailCommand request, CancellationToken cancellationToken)
    {
       return await SendMailHelper.SendMail(request._mailBodyEntity);
    }
}
