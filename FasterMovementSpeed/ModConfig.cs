using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace FasterMovementSpeed
{
    internal class ModConfig 
    {

        public bool isActive { get; set; } = false;
        public int speedAmount { get; set; } = 3;

    }
}
