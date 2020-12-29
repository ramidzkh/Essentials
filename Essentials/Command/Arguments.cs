using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using NBrigadier;
using NBrigadier.Arguments;
using NBrigadier.CommandSuggestion;
using NBrigadier.Context;
using Terraria;

namespace Essentials.Command
{
    public class PlayerArgumentType : IArgumentType<Player>
    {
        public static readonly PlayerArgumentType Instance = new PlayerArgumentType();

        private PlayerArgumentType()
        {
        }

        public Player Parse(StringReader reader)
        {
            var name = reader.ReadString();
            return Main.player.First(player => player.name == name);
        }

        public Func<Suggestions> ListSuggestions<TS>(CommandContext<TS> context, SuggestionsBuilder builder)
        {
            return Suggestions.Empty();
        }

        public ICollection<string> Examples { get; } = new List<string>();

        public static Player GetValue<TS>(CommandContext<TS> context, string name)
        {
            return context.GetArgument<Player>(name, typeof(Player));
        }
    }

    public class Vector2ArgumentType : IArgumentType<Vector2>
    {
        public static readonly Vector2ArgumentType Instance = new Vector2ArgumentType();

        private Vector2ArgumentType()
        {
        }

        public Vector2 Parse(StringReader reader)
        {
            var x = reader.ReadFloat();
            reader.SkipWhitespace();
            var y = reader.ReadFloat();
            return new Vector2(x, y);
        }

        public Func<Suggestions> ListSuggestions<TS>(CommandContext<TS> context, SuggestionsBuilder builder)
        {
            return Suggestions.Empty();
        }

        public ICollection<string> Examples { get; } = new List<string>();

        public static Vector2 GetValue<TS>(CommandContext<TS> context, string name)
        {
            return context.GetArgument<Vector2>(name, typeof(Vector2));
        }
    }
}
