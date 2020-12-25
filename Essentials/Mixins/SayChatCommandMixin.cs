using System;
using Essentials.Command;
using Essentials.Extensions;
using NBrigadier;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using SharpILMixins.Annotations.Parameters;
using Terraria;
using Terraria.Chat.Commands;

namespace Essentials.Mixins
{
    [Mixin(typeof(SayChatCommand))]
    public class SayChatCommandMixin
    {
        [Inject(SayChatCommandTargets.Methods.ProcessIncomingMessage, AtLocation.Head)]
        [Unique]
        private void ProcessIncomingMessage(string text, byte clientId, [InjectCancelParam] out bool cancel)
        {
            if (!(cancel = text.StartsWith("/"))) return;

            var player = Main.player[clientId];
            var reader = new StringReader(text);
            reader.Skip();

            try
            {
                CommandManager.Dispatcher.Execute(reader, new Source(player));
            }
            catch (Exception exception)
            {
                player.SendMessageToPlayer(exception.Message);
            }
        }
    }
}
