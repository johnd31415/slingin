using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Chat;

namespace slingin.Content
{
	public class StopMessagesCommand : ModCommand
	{
        public override string Command => "stopSlinginMessages";//throw new NotImplementedException();

        public override CommandType Type => CommandType.Chat;//throw new NotImplementedException();

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (Main.LocalPlayer.GetModPlayer<SimplePlayer>().wantsToSeeDumbMessages)
            {
                Main.NewText("Okay I guess I'll stop", 255, 0, 63);
                Main.LocalPlayer.GetModPlayer<SimplePlayer>().wantsToSeeDumbMessages = false;
            }
            else
            {
                Main.NewText("They were already off, now they're going back on. Suck it", 76, 153, 0);
                Main.LocalPlayer.GetModPlayer<SimplePlayer>().wantsToSeeDumbMessages = true;
            }
            //throw new NotImplementedException();
        }
    }
}