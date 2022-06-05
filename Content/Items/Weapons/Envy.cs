using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace slingin.Content.Items.Weapons
{
	public class Envy : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("I bet with some practice this thing could sail over them mountains!\nTry not to lose it...");

			ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			// Common Properties
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(silver: 10);

			// Use Properties
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 12;
			Item.useTime = 24;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			// Weapon Properties
			Item.damage = 5;
			Item.knockBack = 2.5f;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;

			// Projectile Properties
			Item.shootSpeed = 15.0f;
			Item.shoot = ModContent.ProjectileType<Projectiles.EnvyProjectile>();
		}

		//public override bool CanUseItem(Player player) {
		//	// Ensures no more than one disc can be thrown out, use this when using autoReuse
		//	return player.ownedProjectileCounts[Item.shoot] < 1;
		//}

		public override bool? UseItem(Player player) {
			// Because we're skipping sound playback on use animation start, we have to play it ourselves whenever the item is actually used.
			if (!Main.dedServ && Item.UseSound.HasValue) {
				SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
			}
			SimplePlayer player2 = Main.LocalPlayer.GetModPlayer<SimplePlayer>();
			player2.AddThrow();
			Random rnd = new Random();
			if (rnd.Next(3000) == 0)
            {
				Item.stack = 0;
				Main.NewText("Shit, did you see where that went?", 63, 255, 63);
			}
			return null;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddTile(TileID.Anvils)
				.AddRecipeGroup(RecipeGroupID.IronBar, 10)
				.AddCondition(NetworkText.FromKey("RecipeConditions.hasDisc"), recipe => Main.LocalPlayer.GetModPlayer<SimplePlayer>().hasDisc)
				.Register();
		}
		public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
			int x = Main.LocalPlayer.GetModPlayer<SimplePlayer>().currentThrows;
			damage.Base += (20 * x) / (x + 1000);
		}

	}
}
