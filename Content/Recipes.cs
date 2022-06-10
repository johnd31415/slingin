using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Localization;

namespace slingin.Content
{
	public class Recipes : ModSystem
	{
		public static RecipeGroup EvilBar;
		public static RecipeGroup Strings;

		public override void Unload()
		{
			EvilBar = null;
			Strings = null;
		}

		public override void AddRecipeGroups()
		{
			// Language.GetTextValue("LegacyMisc.37") is the word "Any" in english, and the corresponding word in other languages
			EvilBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {"Evil Bar"}",
				ItemID.DemoniteBar, ItemID.CrimtaneBar);

			RecipeGroup.RegisterGroup("slingin:EvilBar", EvilBar);

			Strings = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {"String"}",
				ItemID.WhiteString, ItemID.BlackString, ItemID.BlueString, ItemID.BrownString, ItemID.CyanString, ItemID.GreenString, ItemID.LimeString, ItemID.OrangeString,
				ItemID.PinkString, ItemID.PurpleString, ItemID.RainbowString, ItemID.RedString, ItemID.SkyBlueString, ItemID.TealString, ItemID.VioletString, ItemID.YellowString);

			RecipeGroup.RegisterGroup("slingin:Strings", Strings);
		}
	}
}