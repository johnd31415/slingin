using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

/*
 * Tracks total number of disc throws. Each disc item has a formula for adding damage based on this value
 */

namespace slingin.Content
{
    class SimplePlayer : ModPlayer
    {
        public int currentThrows = 0;

        public override void PreSavePlayer()
        {

        }
        /*
         * Making sure everything saves and loads correctly.
         */

        public override void SaveData(TagCompound tag)
        {
            try
            {
                tag.Set("throws", currentThrows, true);
            }
            catch
            {
            }
        }

        public override void LoadData(TagCompound tag)
        {
            try
            {
                currentThrows = tag.GetInt("throws");
            }
            catch
            {
            }
        }

        public void AddThrow()
        {
            currentThrows += 1;
            if (currentThrows % 10000 == 0)
            {
                Main.NewText("Damn son, " + currentThrows + " throws! You must be gitting gud", 63, 255, 63);
            }
        }
    }
}