using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace FasterMovementSpeed
{
    class ModEntry : Mod
    {
        private ModConfig config;
        private void GameEvents_QuarterTick(object sender, EventArgs args)
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

        private void InputButtons_KeyPress(object sender, EventArgsKeyPressed key)
        {
            if (key.KeyPressed.Equals("H"))
            {
                this.config.isActive = !this.config.isActive;
                Monitor.Log("Toggling extra speed to " + this.config.isActive + ".");
            }
        }


        public override void Entry(IModHelper helper)
        {
            GameEvents.QuarterSecondTick += GameEvents_QuarterTick;
            ControlEvents.KeyPressed += InputButtons_KeyPress;
            this.config = (ModConfig)helper.ReadConfig<ModConfig>();
        }
    }
}
