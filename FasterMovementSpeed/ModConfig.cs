using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace FasterMovementSpeed
{
    class ModConfig : Mod
    {

        public bool isActive { get; set; } = false;
        public int speedAmount { get; set; } = 3;

        public override void Entry(IModHelper helper)
        {
            ModConfig config = helper.ReadConfig<ModConfig>();

        }
    }
}
