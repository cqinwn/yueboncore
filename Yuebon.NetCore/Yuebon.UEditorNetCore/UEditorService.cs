using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Yuebon.UEditorNetCore.Handlers;

namespace Yuebon.UEditorNetCore
{
   /// <summary>
   /// 
   /// </summary>
    public class UEditorService
    {
        private UEditorActionCollection actionList;


        public UEditorService(IHostingEnvironment env, UEditorActionCollection actions)
        {
            Config.WebRootPath = env.ContentRootPath;
            actionList = actions;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void DoAction(HttpContext context)
        {
            var action = context.Request.Query["action"];
            if (actionList.ContainsKey(action))
                actionList[action].Invoke(context);
            else
                new NotSupportedHandler(context).Process();
        }
    }
}
