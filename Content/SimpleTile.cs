using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace slingin.Content
{
    public class SimpleTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            if (!Main.LocalPlayer.GetModPlayer<SimplePlayer>().hasDisc && type == TileID.Trees)
            {
                Random rnd = new Random();
                if (rnd.Next(1000) == 0)
                {
                    Main.NewText("Was this thing stuck up there?", 255, 0, 63);
                    Main.NewText("It says KC on the back here... strange", 0, 77, 255);
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Weapons.Envy>());
                    Main.LocalPlayer.GetModPlayer<SimplePlayer>().hasDisc = true;
                }
            }
            return true;
		}

        public override void NearbyEffects(int x, int y, int type, bool closer)
        {
            if (type == ModContent.TileType<Content.Tiles.Basket>() && NPC.CountNPCS(ModContent.NPCType<Content.NPCs.BasketDummy>()) < 1)
            {
                Main.NewText("Spawn dummy i hope", 255, 0, 63);
                NPC.NewNPC(Terraria.Entity.GetSource_None(), x, y, ModContent.NPCType<Content.NPCs.BasketDummy>());
            }
		}

    }
}
