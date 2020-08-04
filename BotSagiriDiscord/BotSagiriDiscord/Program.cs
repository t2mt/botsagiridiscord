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
        private CommandService commands;
        public async Task MainSync()
        {
            client = new DiscordSocketClient();

            client.Log += Log;

            //  You can assign your bot token to a string, and pass that in to connect.
            //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
            var token = "NzM5NzQxNDgxODA3MzgwNTIx.Xye38A.Y1Z8WEz_qJ5Re6vZ8HpQwE6lEZw";

            // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            handler = new CommandHandler(client, commands);
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
