using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using ServiceLayer.Chat.Hubs.Models;

namespace ServiceLayer.Chat.Hubs
{

    public class ChatHub : Hub
    {


        public void SendChatMessage(string message, string username)
        {

            var user = Context.User;
            var name = username;


            if (user.Identity.IsAuthenticated)
            {
                name = user.Identity.Name;
            }
            else if(string.IsNullOrEmpty(name))
            {
                name = "Anonymous";
            }

            var chatMessage = new ChatMessage
                              {
                                  Message = message,
                                  SenderName = name
                              };

            Clients.All.sendMessage(chatMessage);
        }


    }


}