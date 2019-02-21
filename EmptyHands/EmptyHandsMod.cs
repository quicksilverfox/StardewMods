﻿using System;
using Pathoschild.Stardew.EmptyHands.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace EmptyHands
{
    /// <summary>The mod entry point.</summary>
    public class EmptyHandsMod : Mod
    {
        /*********
        ** Properties
        *********/
        /// <summary>The mod configuration.</summary>
        private ModConfig Config;


        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides methods for interacting with the mod directory, such as read/writing a config file or custom JSON files.</param>
        public override void Entry(IModHelper helper)
        {
            Config = helper.ReadConfig<RawModConfig>().GetParsed(Monitor);

            helper.Events.Input.ButtonPressed += ControlEvents_KeyPressed;
            /*
            ControlEvents.KeyPressed += this.ControlEvents_KeyPressed;
            ControlEvents.ControllerButtonPressed += this.ControlEvents_ControllerButtonPressed;
            ControlEvents.ControllerTriggerPressed += this.ControlEvents_ControllerTriggerPressed;*/
        }


        /*********
        ** Private methods
        *********/
        /****
        ** Event handlers
        ****/

        /// <summary>The method invoked when the player presses a keyboard button.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ControlEvents_KeyPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Game1.hasLoadedGame)
                return;

            ReceiveKeyPress(e.Button, Config.Keyboard);
        }

        /// <summary>The method invoked when the player presses a controller button.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ControlEvents_ControllerTriggerPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Game1.hasLoadedGame)
                return;

            ReceiveKeyPress(e.Button, Config.Controller);
        }

        /// <summary>The method invoked when the player presses a controller trigger button.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ControlEvents_ControllerButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Game1.hasLoadedGame)
                return;

            ReceiveKeyPress(e.Button, Config.Controller);
        }

        /****
        ** Methods
        ****/
        /// <summary>The method invoked when the player presses an input button.</summary>
        /// <typeparam name="TSButton"></typeparam>
        /// <param name="key">The pressed input.</param>
        /// <param name="map">The configured input mapping.</param>
        private void ReceiveKeyPress<TSButton>(TSButton key, InputMapConfiguration<TSButton> map)
        {
            if (!map.IsValidKey(key))
                return;

            // perform bound action
            try
            {
                if (key.Equals(map.SetToNothing))
                    UnsetActiveItem();
            }
            catch (Exception ex)
            {
                Monitor.Log($"Something went wrong handling input '{key}':\n{ex}", LogLevel.Error);
                Game1.addHUDMessage(new HUDMessage("Huh. Something went wrong handling your input. The error log has the technical details.", HUDMessage.error_type));
            }
        }

        /// <summary>Sets active item to an impossible value.</summary>
        private void UnsetActiveItem()
        {
            Game1.player.CurrentToolIndex = int.MaxValue;
        }
    }
}
