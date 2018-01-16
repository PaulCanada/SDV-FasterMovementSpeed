using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace FasterMovementSpeed
{
    class ModEntry : Mod
    {

        private const int movementSpeed = 3;
        private const int originalAddedSpeed = 0;
        private bool isActive = false;

        private void GameEvents_UpdateTick(object sender, EventArgs args)

        {
            if (this.config.isActive)
            {
                Game1.player.addedSpeed = this.config.speedAmount;
            }
            else
            {

                Game1.player.addedSpeed = movementSpeed;
            } else
            {
                Game1.player.addedSpeed = originalAddedSpeed;
            }
        }

        private void ControlButtons_KeyPress(object sender, EventArgsKeyPressed key)
        {
            if (Context.IsPlayerFree)
            {

                if (key.KeyPressed.ToString().Equals("H"))
                {
                    isActive = !isActive;
                    Monitor.Log("Toggling extra speed to " + isActive + ".");
                }

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
