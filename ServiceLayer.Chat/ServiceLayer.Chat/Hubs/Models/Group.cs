namespace ServiceLayer.Chat.Hubs.Models
{
    /// <summary>
    ///     This is the Gruop object holding the parameters needed for creating a chatgroup
    ///     this object wil also be used for a one on one chat
    /// </summary>
    internal class Group
    {
        public Group(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }

        public string Name { get; set; }
        public string ShortName { get; set; }

        public static string CreateGroupname(string inviter, string invitee)
        {
            return inviter + invitee;
        }
    }
}