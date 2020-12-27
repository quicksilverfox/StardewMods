using StardewModdingAPI;

namespace EmptyHands.Framework
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
