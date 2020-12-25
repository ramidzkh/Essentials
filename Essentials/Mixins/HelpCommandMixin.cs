using Essentials.Command;
using Essentials.Extensions;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using Terraria;
using Terraria.Chat.Commands;
using static Essentials.Command.CommandManager;

namespace Essentials.Mixins
{
    [Mixin(typeof(HelpCommand))]
    public class HelpCommandMixin
    {
        [Inject(HelpCommandTargets.Methods.ProcessIncomingMessage, AtLocation.Tail)]
        [Unique]
        private void ProcessIncomingMessage(string text, byte clientId)
        {
            var player = Main.player[clientId];
            var usage = Dispatcher.GetSmartUsage(Dispatcher.Root, new Source(player));

            foreach (var value in usage.Values) player.SendMessageToPlayer("/" + value);
        }
    }
}
