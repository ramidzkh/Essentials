using System;
using JetBrains.Annotations;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;

namespace Essentials.Command
{
    public class Source
    {
        [CanBeNull] public readonly Player Player;

        public Source([CanBeNull] Player player)
        {
            Player = player;
        }

        public void SendMessage(string message)
        {
            SendMessage(message, Color.White);
        }

        public void SendMessage(string message, Color color)
        {
            if (Player != null)
                ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral(message), color, Player.whoAmI);
            else
                Console.WriteLine(message);
        }
    }
}
