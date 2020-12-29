using static Essentials.Command.CommandManager;

namespace Essentials.Command
{
    public static class ExecuteCommand
    {
        public static void Register()
        {
            var node = Dispatcher.Register(Literal("execute"));

            Dispatcher.Register(Literal("execute")
                .Then(Literal("run")
                    .Redirect(Dispatcher.Root))
                .Then(Literal("as")
                    .Then(Argument("player", PlayerArgumentType.Instance)
                        .Redirect(node, context => new Source(PlayerArgumentType.GetValue(context, "player")))))
                .Then(Literal("asc")
                    .Redirect(node, context => new Source(null)))
            );
        }
    }
}
