using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace IMC.Hubs
{
    public class ClinicHub : Hub
    {
        public void Send(string name)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name);
        }

    }
}