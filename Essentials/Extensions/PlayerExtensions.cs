using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;

namespace Essentials.Extensions
{
    public static class PlayerExtensions
    {
        public static void SendMessageToPlayer(this Player player, string message)
        {
            SendMessageToPlayer(player, message, Color.White);
        }

        public static void SendMessageToPlayer(this Player player, string message, Color color)
        {
            ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral(message), color, player.whoAmI);
        }
    }
}
