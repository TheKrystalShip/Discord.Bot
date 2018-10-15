using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TheKrystalShip.Discord
{
    public static class Settings
    {
        private static IConfiguration _config;

        public static IConfiguration Instance => _config ??
            (_config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Properties"))
                .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                .Build());
    }
}
