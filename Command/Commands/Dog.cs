using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Server2.Command.Commands
{
    class Dog : Command
    {
        public override string[] Nemes { get; set; } = new string[] { "Собак", "собак", "Сук", "Псин", "псин" };

        public override async void Execute(SocketMessage arg)
        {
            Random rnd = new Random();
            int r = rnd.Next(174, 208);
            await arg.Channel.SendMessageAsync("https://vk.com/photo-202797035_457239" + r);
        }
    }
}
