using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;

namespace Pathoschild.Stardew.EmptyHands.Framework
{
    /// <summary>The mod configuration.</summary>
    internal class ModConfig
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The keyboard input map.</summary>
        public InputMapConfiguration<SButton> Keyboard { get; set; }

        /// <summary>The controller input map.</summary>
        public InputMapConfiguration<SButton> Controller { get; set; }
    }
}
