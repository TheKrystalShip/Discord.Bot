using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheKrystalShip.Discord
{
    public static class TaskExtensions
    {
        public static async Task DelayIndefinetly(this Task task)
        {
            await Task.Delay(-1);
        }
    }
}
