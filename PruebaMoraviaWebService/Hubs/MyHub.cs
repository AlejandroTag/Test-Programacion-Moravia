using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PruebaMoraviaWebService.Hubs
{
    public class MyHub : Hub
    {
        public void Subscribe(string customerId)
        {
            Groups.Add(Context.ConnectionId, customerId);
        }

        public void Unsubscribe(string customerId)
        {
            Groups.Remove(Context.ConnectionId, customerId);
        }

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}