using Discord.Commands;
using Discord.WebSocket;

using System;
using System.Collections.Generic;
using System.Text;

using TheKrystalShip.Logging;

namespace TheKrystalShip.Discord
{
    public class Tools
    {
        public DiscordSocketClient Client { get; private set; }
        public CommandService CommandService { get; private set; }
        public ILogger<Tools> Logger { get; private set; }

        public Tools(DiscordSocketClient client, CommandService commandService, ILogger<Tools> logger)
        {
            Client = client;
            CommandService = commandService;
            Logger = logger;
        }
    }
}
