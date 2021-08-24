using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Server2.Command.Commands;

namespace Server2
{
    class Program
    {
        DiscordSocketClient client;
        public static List<Command.Command> commands;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            client = new DiscordSocketClient();

            commands = new List<Command.Command>
            {
                new Dog()
            };

            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "ODc5MjMwNzU2NzI2MTQ1MDQ3.YSMtcw.HZ4ObJDoYlak-fdEwSzv0oCOvO0";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadKey();
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage arg)
        {
            if (!arg.Author.IsBot && arg.Content != null)
            {
                //arg.Channel.SendMessageAsync(arg.Content);
                Console.WriteLine($"{MyTime()} Get msg     From {arg.Author}: {arg.Content}");

                foreach (var comm in commands)
                {
                    if (comm.Contains((string)arg.Content))
                    {
                        comm.Execute((SocketMessage)arg);
                    }
                }
            }
            return Task.CompletedTask;
        }

        private string MyTime()
        {
            DateTime now = DateTime.Now;
            return now.ToLongTimeString();
        }
    }
}
