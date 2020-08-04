using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotSagiriDiscord.Modules
{
    public class CommandLines : ModuleBase
    {
        [Command("hello")]
        public async Task Hello()
        {
            await ReplyAsync("Hi! Chào mừng Onii-chan " + Context.Message.Author.Mention + "đến với N-World");
        }
    }
}
