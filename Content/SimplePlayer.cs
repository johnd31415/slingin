using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

/*
 * Tracks total number of disc throws. Each disc weapon has a formula for adding damage based on this value
 */

namespace slingin.Content
{
    class SimplePlayer : ModPlayer
    {
        public int currentThrows = 0;
        public bool hasDisc = false;

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
                tag.Set("hasDisc", hasDisc, true);
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
                hasDisc = tag.GetBool("hasDisc");
            }
            catch
            {
            }
        }

        public void AddThrow()
        {
            currentThrows += 1;
            if (currentThrows % 1000 == 0)//TODO chat command to disable these messages
            {
                Main.NewText("Damn son, " + currentThrows + " throws! You must be gitting gud", 63, 255, 63);
            }
        }
    }
}