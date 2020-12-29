using NBrigadier;
using NBrigadier.Arguments;
using NBrigadier.Builder;

namespace Essentials.Command
{
    using Dispatcher = CommandDispatcher<Source>;

    public static class CommandManager
    {
        static CommandManager()
        {
            InfoCommand.Register();
            ExecuteCommand.Register();
            RespawnCommand.Register();
            TeleportCommand.Register();
        }

        public static Dispatcher Dispatcher { get; } = new Dispatcher();

        public static LiteralArgumentBuilder<Source> Literal(string literal)
        {
            return LiteralArgumentBuilder<Source>.Literal(literal);
        }

        public static RequiredArgumentBuilder<Source, T> Argument<T>(string name, IArgumentType<T> argumentType)
        {
            return RequiredArgumentBuilder<Source, T>.Argument(name, argumentType);
        }

        public static LiteralArgumentBuilder<Source> RequiresPlayer(this LiteralArgumentBuilder<Source> builder)
        {
            return builder.Requires(source => source.Player != null);
        }

        public static RequiredArgumentBuilder<Source, T> RequiresPlayer<T>(
            this RequiredArgumentBuilder<Source, T> builder)
        {
            return builder.Requires(source => source.Player != null);
        }
    }
}
