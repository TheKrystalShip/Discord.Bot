using Discord;
using Discord.WebSocket;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TheKrystalShip.Discord
{
    public class Bot
    {
        private static DiscordSocketClient _client;
        private static CommandHandler _commandHandler;
        private static string _token;

        public Bot()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig()
                {
                    LogLevel = LogSeverity.Debug,
                    DefaultRetryMode = RetryMode.AlwaysRetry,
                    ConnectionTimeout = 5000
                }
            );

            _commandHandler = new CommandHandler(ref _client);

            _token = Settings.Instance["Bot:Token"];
        }

        public async Task InitAsync()
        {
            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();
        }
    }
}
