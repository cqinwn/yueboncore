using Microsoft.AspNetCore.SignalR;
using Senparc.WebSocket.SignalR;
using System.Threading.Tasks;

namespace Yuebon.WebApi.WebSocket.Hubs
{
    /// <summary>
    /// 
    /// </summary>
    public class SenparcHub : SenparcWebSocketHubBase
    {
        /// <summary>
        /// 给普通网页用的自定义扩展方法 url：[your domain]/WebScoket
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendCustomMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveCustomMessage", user, message);
        }
    }
}