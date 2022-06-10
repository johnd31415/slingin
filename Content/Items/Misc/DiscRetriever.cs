using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace slingin.Content.Items.Misc
{
	public class DiscRetriever : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("You can't lose discs anymore; you can just trash this now.\n" +
                "Q: How does that make any sense?\n" +
                "A: I don't remember asking your opinion...\n" +
                "You'd really rather I make you equip it or some shit?\n" +
                "I mean just shut the f... sorry that was uncalled for");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(silver: 15);
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddTile(TileID.Anvils)
				.AddIngredient(ItemID.HellstoneBar, 10)
				.AddRecipeGroup(Recipes.Strings, 1)
				.AddIngredient<Weapons.Envy>(1)
				.AddCondition(NetworkText.FromKey("RecipeConditions.hasDisc"), recipe => Main.LocalPlayer.GetModPlayer<SimplePlayer>().hasDisc)
				.Register();
		}
		public override bool OnPickup(Player player)
        {
			Main.LocalPlayer.GetModPlayer<SimplePlayer>().hasRetriever = true;
            return true;
        }
		public override void OnCraft(Recipe recipe)
        {
			Main.LocalPlayer.GetModPlayer<SimplePlayer>().hasRetriever = true;
		}
	}
}
