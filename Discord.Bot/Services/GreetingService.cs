using System.Threading.Tasks;

using TheKrystalShip.Logging;

namespace TheKrystalShip.Discord
{
    public class GreetingService
    {
        private readonly ILogger<GreetingService> _logger;

        public GreetingService(ILogger<GreetingService> logger)
        {
            _logger = logger;
        }
    }
}
