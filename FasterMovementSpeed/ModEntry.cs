using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace FasterMovementSpeed
{
    class ModEntry : Mod
    {
        private ModConfig config;
        private void GameEvents_UpdateTick(object sender, EventArgs args)
        {
            if (this.config.isActive)
            {
                Game1.player.addedSpeed = this.config.speedAmount;
            }
            else
            {
                Game1.player.addedSpeed = 0;
            }
        }

        private void InputButtons_ButtonPressed(object sender, EventArgsInput key)
        {
            if (Context.IsPlayerFree)
            {
                if (key.Button.ToString().Equals("H"))
                {
                    this.config.isActive = !this.config.isActive;
                    Monitor.Log("Toggling extra speed to " + this.config.isActive + ".");
                    this.Helper.WriteConfig(config);
                }
            }
        }


        public override void Entry(IModHelper helper)
        {
            this.config = (ModConfig)helper.ReadConfig<ModConfig>();
            GameEvents.UpdateTick += GameEvents_UpdateTick;
            InputEvents.ButtonPressed += InputButtons_ButtonPressed;
        }
    }
}
