using Discord;
using Discord.WebSocket;

using Microsoft.Extensions.Configuration;

using System;
using System.IO;
using System.Threading.Tasks;

namespace TheKrystalShip.Discord
{
    public class Program
    {
        private static Bot _bot;

        public static async Task Main(string[] args)
        {
            await (_bot = new Bot())
                .InitAsync()
                .DelayIndefinetly();
        }
    }
}
