using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Text;

namespace TheKrystalShip.Discord
{
    public class Module : ModuleBase<SocketCommandContext>
    {
        public Tools Tools { get; private set; }

        public Module(Tools tools)
        {
            Tools = tools;
        }

        protected override void BeforeExecute(CommandInfo command)
        {
            base.BeforeExecute(command);

        }

        protected override void AfterExecute(CommandInfo command)
        {
            base.AfterExecute(command);

        }
    }
}
