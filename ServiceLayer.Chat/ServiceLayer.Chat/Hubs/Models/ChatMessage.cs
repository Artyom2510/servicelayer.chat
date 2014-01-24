using System;

namespace ServiceLayer.Chat.Hubs.Models
{
    /// <summary>
    ///     The Message object contains all the data we need to send back to the SignalR hub client so it can create a view for
    ///     it (display it)
    /// </summary>
    public class ChatMessage
    {
        public ChatMessage()
        {
            Sent = DateTime.UtcNow; 
        }
        public ChatMessage(string message, string senderName, string connectionId, string groupName)
        {
            Message = message;
            SenderName = senderName;
            Sent = DateTime.UtcNow;
            GroupName = groupName;

            Avatar = MemberStore.GetAvatar(senderName, connectionId);
        }

        /// <summary>
        ///     Gets or set the message we need to send
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sender
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        ///     Gets the datetime when the message was sent
        /// </summary>
        public DateTime Sent { get; private set; }

        /// <summary>
        ///     Gets the portrett or Avatar of the sender
        /// </summary>
        public string Avatar { get; private set; }

        /// <summary>
        ///     Getsa or sets the group name we need to send the message to
        /// </summary>
        public string GroupName { get; set; }
    }
}