using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Security.Services.CommandHandlers
{
    public class SqlLogCommand : IRequest<bool>
    {

        /// <summary>
        /// Sql日志
        /// </summary>
        private List<SqlLog> sqlLogInputs;

        public List<SqlLog> SqlLogInputs { get => sqlLogInputs; set => sqlLogInputs = value; }
    }
}
