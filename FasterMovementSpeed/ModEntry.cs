using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void InputButtons_KeyPress(object sender, EventArgsKeyPressed key)
        {
            if (key.KeyPressed.Equals("H"))
            {
                isActive = !isActive;
            }
        }


        public override void Entry(IModHelper helper)
        {
            GameEvents.QuarterSecondTick += GameEvents_QuarterTick;
            ControlEvents.KeyPressed += InputButtons_KeyPress;
        }
    }
}
