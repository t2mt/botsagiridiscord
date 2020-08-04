using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BotSagiriDiscord
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient clients;
        private readonly CommandService commands;

        public CommandHandler(DiscordSocketClient Clients,CommandService Commands)
        {
            clients = Clients;
            commands = Commands;
        }

        public async Task InstallCommandsAsync()
        {
            clients.MessageReceived += HandleCommandAsync;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(),services:null);
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if(message == null)
            {
                return;
            }
            var context = new SocketCommandContext(clients, message);
            int argPos = 0;

            if (message.HasCharPrefix('!', ref argPos) || message.HasMentionPrefix(clients.CurrentUser,ref argPos) || message.Author.IsBot)
            {
                var result = await commands.ExecuteAsync(context: context, argPos: argPos, services: null);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            }
            return;
        }
    }
}
