using Essentials.Extensions;
using Microsoft.Xna.Framework;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using Terraria;

namespace Essentials.Mixins
{
    [Mixin(typeof(Player))]
    public class PlayerMixin : Player, IPlayerExtension
    {
        public Vector2? OldPosition { get; private set; }

        [Inject(PlayerTargets.Methods.Teleport, AtLocation.Head)]
        [Unique]
        private void Teleport()
        {
            OldPosition = position;
        }
    }
}
