using Discord;
using Discord.Commands;
using Discord.WebSocket;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Reflection;
using System.Threading.Tasks;

using TheKrystalShip.Logging;
using TheKrystalShip.Logging.Extensions;

namespace TheKrystalShip.Discord
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commandService;
        private readonly IServiceProvider _services;
        private readonly ILogger<CommandHandler> _logger;

        public CommandHandler(ref DiscordSocketClient client)
        {
            _client = client;

            _commandService = new CommandService(new CommandServiceConfig()
                {
                    DefaultRunMode = RunMode.Async,
                    CaseSensitiveCommands = false,
                    LogLevel = LogSeverity.Debug
                }
            );

            _commandService.AddModulesAsync(Assembly.GetEntryAssembly());

            _services = ConvigureServiceProvider();
            _services.GetRequiredService<EventManager>();
            _logger = _services.GetRequiredService<ILogger<CommandHandler>>();

            _commandService.Log += CommandServiceLog;
            _client.MessageReceived += HandleCommand;
        }

        private IServiceProvider ConvigureServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commandService)
                .AddHandlers()
                .AddManagers()
                .AddServices()
                .AddLogger()
                .AddTools()
                .BuildServiceProvider();
        }

        private Task CommandServiceLog(LogMessage logMessage)
        {
            if (logMessage.Exception is null)
            {
                _logger.LogInformation(logMessage.Message);
            }
            else
            {
                _logger.LogError(logMessage.Exception, logMessage.Message);
            }

            return Task.CompletedTask;
        }

        private async Task HandleCommand(SocketMessage socketMessage)
        {
            SocketUserMessage message = socketMessage as SocketUserMessage;

            if (message is null || message.Author.IsBot)
            {
                return;
            }

            int argPos = 0;
            bool hasMention = message.HasMentionPrefix(_client.CurrentUser, ref argPos);

            string defaultPrefix = Settings.Instance["Bot:Prefix"];
            bool hasPrefix = message.HasStringPrefix(defaultPrefix, ref argPos);

            if (!hasMention && !hasPrefix)
            {
                return;
            }

            SocketCommandContext context = new SocketCommandContext(_client, message);
            IResult result = await _commandService.ExecuteAsync(context, argPos, _services);

            if (!result.IsSuccess)
            {
                _logger.LogError(result.ErrorReason);
            }
        }
    }
}
