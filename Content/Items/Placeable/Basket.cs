using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace slingin.Content.Items.Placeable
{
	public class Basket : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Practice Basket");
			Tooltip.SetDefault("This is a WIP basket");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Basket>());
			Item.value = 150;
			Item.maxStack = 99;
			Item.width = 16;
			Item.height = 24;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.IronBar, 10)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
