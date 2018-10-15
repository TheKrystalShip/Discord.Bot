using Discord.Commands;

using System.Threading.Tasks;

using TheKrystalShip.Logging;

namespace TheKrystalShip.Discord
{
    public class GreetingModule : Module
    {
        public GreetingModule(Tools tools) : base(tools)
        {

        }

        [Command("hello")]
        [Alias("hello there", "hey")]
        [Summary("Replies with a custom message")]
        public async Task GreetAsync()
        {
            await ReplyAsync($"General {Context.User.Username} ⚔️⚔️");
        }
    }
}
