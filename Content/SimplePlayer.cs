using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

/*
 * Tracks a number of fields for the player that we use to determine various disc behavior
 */
namespace slingin.Content
{
    class SimplePlayer : ModPlayer
    {
        public int currentThrows = 0;
        public bool hasDisc = false;
        public bool wantsToSeeDumbMessages = true;

        public bool hasRetriever = false;

        public override void PreSavePlayer()
        {

        }
        
        /*
         * Save player data
         */
        public override void SaveData(TagCompound tag)
        {
            try
            {
                tag.Set("throws", currentThrows, true);
                tag.Set("hasDisc", hasDisc, true);
                tag.Set("hasRetriever", hasRetriever, true);
                tag.Set("chatMessages", wantsToSeeDumbMessages, true);
            }
            catch
            {
            }
        }

        /*
         * Load player data
         */
        public override void LoadData(TagCompound tag)
        {
            try
            {
                currentThrows = tag.GetInt("throws");
                hasDisc = tag.GetBool("hasDisc");
                hasRetriever = tag.GetBool("hasRetriever");
                wantsToSeeDumbMessages = tag.GetBool("chatMessages");
            }
            catch
            {
            }
        }
        /*
         * Adds a throw to the global count. Each disc calls this on useItem
         */
        public void AddThrow()
        {
            currentThrows += 1;
            if (currentThrows % 1000 == 0 && Main.LocalPlayer.GetModPlayer<SimplePlayer>().wantsToSeeDumbMessages)
            {
                Main.NewText("Damn son, " + currentThrows + " good throws! You must be gitting gud", 63, 255, 63);
            }
        }

        /*
         * Returns amount of damage to add to the disc based on currentThrows and discLevel. Called by each disc in ModifyWeaponDamage().
         * 
         * discLevel:
         * 1 = putter
         * 2 = mid
         * 3 = fairway
         * 4 = distance
         */
        public int getDiscDamage(int discLevel)
        {

            if (discLevel > 3 && currentThrows > 8000)
            {
                return (180 * currentThrows) / (currentThrows + 6000);
            }
            else if (discLevel > 2 && currentThrows > 4000)
            {
                return (100 * currentThrows) / (currentThrows + 4000);
            }
            else if (discLevel > 1 && currentThrows > 2000)
            {
                return (40 * currentThrows) / (currentThrows + 2000);
            }
            else
            {
                return (20 * currentThrows) / (currentThrows + 1000);
            }
        }
    }
}