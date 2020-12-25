using Terraria;
using static Essentials.Command.CommandManager;

namespace Essentials.Command
{
    public static class RespawnCommand
    {
        public static void Register()
        {
            Dispatcher.Register(Literal("respawn")
                .Requires(source => source.Player != null && source.Player.respawnTimer > 0)
                .Executes(context =>
                {
                    NetMessage.SendData(12, -1, -1, null, context.Source.Player.whoAmI);
                    return 1;
                }));
        }
    }
}
