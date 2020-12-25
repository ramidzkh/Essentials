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
                    .RedirectNode(Dispatcher.Root))
                .Then(Literal("as")
                    .Then(Argument("player", PlayerArgumentType.Instance)
                        .RedirectNode(node, context => new Source(PlayerArgumentType.GetValue(context, "player")))))
                .Then(Literal("asc")
                    .RedirectNode(node, context => new Source(null)))
            );
        }
    }
}
