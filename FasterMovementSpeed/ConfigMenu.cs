using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;
using System;
using System.Collections.Generic;

namespace FasterMovementSpeed.Framework
{
    internal class ConfigMenu : IClickableMenu
    {

        private readonly ClickableTextureComponent ApplyButton;
        private readonly int MaxArraySize = 15;
        private readonly int DefaultTileSize = 32;
        private readonly int MinLeftMargin = 32;
        private readonly int MinTopMargin = 32;
        private readonly ModConfig config;
        private int valueToSave = 2;


        public ConfigMenu(ModConfig config)
        {
            int width1 = this.MaxArraySize * this.DefaultTileSize + this.MinLeftMargin * 2;
            int height1 = this.MaxArraySize * this.DefaultTileSize + this.MinTopMargin * 2;
            int x = Game1.viewport.Width / 2 - width1 / 2;
            int y = Game1.viewport.Height / 2 - height1 / 2;

            this.initialize(x, y, width1, height1, true);
            this.ApplyButton = new ClickableTextureComponent("save-changes", new Rectangle(this.xPositionOnScreen + this.width - Game1.tileSize / 2, this.yPositionOnScreen + this.height - Game1.tileSize / 2, Game1.tileSize, Game1.tileSize), "", "Save Changes", Game1.mouseCursors, new Rectangle(128, 256, 64, 64), 1f, false);
        }

        public override void receiveLeftClick(int x, int y, bool playSound = true)
        {
            base.receiveLeftClick(x, y, playSound);

            int mouseX = x - this.xPositionOnScreen;
            int mouseY = y - this.yPositionOnScreen;

            if (this.ApplyButton.containsPoint(x, y))
            {
                this.config.speedAmount = valueToSave;
                this.exitThisMenu(true);

            }

            if (this.upperRightCloseButton.containsPoint(x, y))
            {
                //Game1.playSound("select");
            }
        }

        public override void receiveRightClick(int x, int y, bool playSound = true)
        {
        }

        public override void draw(SpriteBatch b)
        {
            Game1.spriteBatch.Draw(Game1.mouseCursors, new Vector2((float)Game1.getOldMouseX(), (float)Game1.getOldMouseY()), new Rectangle?(Game1.getSourceRectForStandardTileSheet(Game1.mouseCursors, 0, 16, 16)), Color.White, 0.0f, Vector2.Zero, (float)(4.0 + (double)Game1.dialogueButtonScale / 150.0), SpriteEffects.None, 0.0f);
            this.ApplyButton.draw(Game1.spriteBatch);

            base.draw(b);
        }

        public override void update(GameTime time)
        {
            base.update(time);
            this.ApplyButton.tryHover(Game1.getMouseX(), Game1.getMouseY(), 0.1f);
        }
    }
}
