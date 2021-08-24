using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Server2.Command
{
    public abstract class Command
    {
        public abstract string[] Nemes { get; set; }

        public abstract void Execute(SocketMessage arg);

        public bool Contains(string messege)
        {
            foreach (var mess in Nemes)
            {
                if (messege.Contains(mess))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
