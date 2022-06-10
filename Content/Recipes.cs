using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace slingin.Content
{
	public class Recipes : ModSystem
	{
		public static RecipeGroup EvilBar;

		public override void Unload()
		{
			EvilBar = null;
		}

		public override void AddRecipeGroups()
		{
			// Language.GetTextValue("LegacyMisc.37") is the word "Any" in english, and the corresponding word in other languages
			EvilBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {"Evil Bar"}",
				ItemID.DemoniteBar, ItemID.CrimtaneBar);

			RecipeGroup.RegisterGroup("slingin:EvilBar", EvilBar);
		}
	}
}