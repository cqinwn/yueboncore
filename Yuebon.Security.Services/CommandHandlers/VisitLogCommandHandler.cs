using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Security.Services.CommandHandlers
{
    /// <summary>
    /// 访问日志
    /// </summary>
    internal class VisitLogCommandHandler : IRequestHandler<VisitLogCommand, bool>
    {
        private readonly IVisitlogService _visitlogService;

        public VisitLogCommandHandler(IVisitlogService visitlogService)
        {
            _visitlogService = visitlogService;
        }

        public async Task<bool> Handle(VisitLogCommand request, CancellationToken cancellationToken)
        {
            VisitLog visitLog = request.VisitLogInput;
            int row = await _visitlogService.InsertAsync(visitLog);
            return row > 0;
        }
    }
}
