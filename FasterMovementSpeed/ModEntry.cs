using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace FasterMovementSpeed
{
    class ModEntry : Mod
    {

        private const int movementSpeed = 3;
        private bool isActive = false;

        private void GameEvents_QuarterTick(object sender, EventArgs args)
        {
            if (isActive)
            {
                Game1.player.addedSpeed = 3;
            }
        }

        private void InputButtons_KeyPress(object sender, EventArgsInput key)
        {
            if (key.Button.Equals("H"))
            {
                isActive = !isActive;
                Monitor.Log("Toggling extra speed to " + isActive + ".");
            }
        }


        public override void Entry(IModHelper helper)
        {
            GameEvents.QuarterSecondTick += GameEvents_QuarterTick;
            InputEvents.ButtonPressed += InputButtons_KeyPress;
        }
    }
}
