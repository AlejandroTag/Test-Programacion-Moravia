using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PruebaMoraviaWebService.Logical
{
    public class MySignalRService : PersistentConnection
    {

        protected Task OnReceivedAsync(string connectionId, string data)
        {
            string clientDescription = getClientDescription();

            return Connection.Broadcast(new { user = clientDescription, message = data });
        }

        private string getClientDescription()
        {
            var context = HttpContext.Current;

            var name = context.Request.IsAuthenticated
                            ? context.User.Identity.Name
                            : context.Request.UserHostAddress;

            return name;
        }
    }
}