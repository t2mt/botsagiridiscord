using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotSagiriDiscord
{
    public class Program
    {
        public static void Main(string[] args) => new Program().MainSync().GetAwaiter().GetResult();

        private DiscordSocketClient client;
        private CommandHandler handler;

        public async Task MainSync()
        {
            client = new DiscordSocketClient();

            client.Log += Log;

            var token = "NzM5NzQxNDgxODA3MzgwNTIx.Xye38A.Jy_cZNWWIUlJ8xpu2Spn6dUha7I";

            await client.LoginAsync(TokenType.Bot,token);
            await client.StartAsync();
            handler = new CommandHandler(client);
            await Task.Delay(-1);
        }
        private Task Log(LogMessage msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
