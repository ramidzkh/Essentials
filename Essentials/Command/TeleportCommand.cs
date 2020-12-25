using Essentials.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using static Essentials.Command.CommandManager;

namespace Essentials.Command
{
    public static class TeleportCommand
    {
        public static void Register()
        {
            var node = Dispatcher.Register(Literal("teleport")
                .Then(Argument("position", Vector2ArgumentType.Instance)
                    .RequiresPlayer()
                    .Executes(context =>
                    {
                        var player = context.Source.Player;
                        var position = Vector2ArgumentType.GetValue(context, "position");
                        player.TeleportAndNotify(position);
                        return 1;
                    })));

            Dispatcher.Register(Literal("tp")
                .RedirectNode(node));

            Dispatcher.Register(Literal("back")
                .RequiresPlayer()
                .Executes(context =>
                {
                    var player = context.Source.Player;
                    var oldPosition = ((IPlayerExtension) player).OldPosition;

                    if (oldPosition != null)
                        player.TeleportAndNotify((Vector2) oldPosition);
                    else
                        player.SendMessageToPlayer("No previous position stored");

                    return 1;
                }));
        }

        private static void TeleportAndNotify(this Player player, Vector2 position)
        {
            player.Teleport(position);
            NetMessage.SendData(65, -1, -1, null, 0, player.whoAmI, position.X, position.Y,
                (int) PlayerSpawnContext.RecallFromItem);
        }
    }
}
