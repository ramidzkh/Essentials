using static Essentials.Command.CommandManager;

namespace Essentials.Command
{
    public static class InfoCommand
    {
        public static void Register()
        {
            Dispatcher.Register(Literal("info")
                .Executes(context =>
                {
                    var source = context.Source;

                    if (source.Player != null)
                        source.SendMessage($"Your position: {source.Player.position}");
                    else
                        // Server
                        source.SendMessage("You are a server :yeef:");

                    return 1;
                }));
        }
    }
}
