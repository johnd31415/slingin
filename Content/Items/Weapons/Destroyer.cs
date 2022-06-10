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
	public class Destroyer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("I bet with some practice this thing could sail over them mountains!\nTry not to lose it...");//TODO

			ItemID.Sets.SkipsInitialUseSound[Item.type] = true; // This skips use animation-tied sound playback, so that we're able to make it be tied to use time instead in the UseItem() hook.
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			// Common Properties
			Item.rare = ItemRarityID.Red;
			Item.value = Item.sellPrice(gold: 10);

			// Use Properties
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 12;
			Item.useTime = 16;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			// Weapon Properties
			Item.damage = 5;
			Item.knockBack = 3f;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.glowMask = 1;

			// Projectile Properties
			Item.shootSpeed = 21.0f;
			Item.shoot = ModContent.ProjectileType<Projectiles.DestroyerProjectile>();
		}

		/*
		 * 1/10000 chance to lose disc on throw
		 */
		public override bool? UseItem(Player player) {
			// Because we're skipping sound playback on use animation start, we have to play it ourselves whenever the item is actually used.
			if (!Main.dedServ && Item.UseSound.HasValue) {
				SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
			}
			SimplePlayer player2 = Main.LocalPlayer.GetModPlayer<SimplePlayer>();
			Random rnd = new Random();
			if (!player2.hasRetriever && rnd.Next(10000) == 0)
            {
				Item.stack = 0;
				Main.NewText("Shit, did you see where that went?", 63, 255, 63);
			}
			return null;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddTile(TileID.LunarCraftingStation)
				.AddIngredient<Firebird>(1)
				.AddIngredient(ItemID.LunarBar, 10)
				.AddCondition(NetworkText.FromKey("RecipeConditions.hasDisc"), recipe => Main.LocalPlayer.GetModPlayer<SimplePlayer>().hasDisc)
				.Register();
		}
		public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
			damage.Base += Main.LocalPlayer.GetModPlayer<SimplePlayer>().getDiscDamage(4);
		}
		public override bool OnPickup(Player player)
        {
			Main.LocalPlayer.GetModPlayer<SimplePlayer>().hasDisc = true;
            return true;
        }
	}
}
