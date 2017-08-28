
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using System.Collections.Generic;

using System;
using Terraria.ModLoader.IO;
using System.IO;

namespace DarkSouls
{
		 
	public class DarkSoulsWorld : ModWorld
	{

		public static bool downedSorcerer = false; // Downed Tutorial Boss
		public static bool downedAttraidies = false;
        public int iexp = 0;
        public int ilevel = 0;
        public int itnl = 0;
        public string oritemname = "";
        public int oridamage = 0;
        public int oricrit = 0;

        public void Initialize(Terraria.Item item)
        {

            if (item.damage > 0)
            {

                iexp = 0;
                ilevel = 0;

                oritemname = Name;
                oridamage = item.damage;
                oricrit = item.crit;
            }


            downedSorcerer = false;
			downedAttraidies = false;
		}

		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedSorcerer) downed.Add("Sorcerer");
			if (downedAttraidies) downed.Add("Attraidies");
            


            return new TagCompound {
				{"downed", downed}
                
            };
		}

		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedSorcerer = downed.Contains("Sorcerer");
			downedAttraidies = downed.Contains("Attraidies");

		}


		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = downedSorcerer;
			flags[1] = downedAttraidies;
			writer.Write(flags);

			//If you prefer, you can use the BitsByte constructor approach as well.
			//writer.Write(saveVersion);
			//BitsByte flags = new BitsByte(downedAbomination, downedPuritySpirit);
			//writer.Write(flags);

			// This is another way to do the same thing, but with bitmasks and the bitwise OR assignment operator (the |=)
			// Note that 1 and 2 here are bit masks. The next values in the pattern are 4,8,16,32,64,128. If you require more than 8 flags, make another byte.
			//writer.Write(saveVersion);
			//byte flags = 0;
			//if (downedAbomination)
			//{
			//	flags |= 1;
			//}
			//if (downedPuritySpirit)
			//{
			//	flags |= 2;
			//}
			//writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedSorcerer = flags[0];
			downedAttraidies = flags[1];
		}


		public static void Attraidies()
{

if (!downedAttraidies)
	{
		InitiateSuperHardmode();
	}
}
		

		public static void InitiateSuperHardmode()
{
	if (!downedAttraidies)
	{
		if (Main.netMode == 0)
		{
			Main.NewText("A portal from The Abyss has been opened!"); 
			Main.NewText("Artorias, the Ancient Knight of the Abyss has entered this world!...");
			Main.NewText("You must seek out the Shaman Elder...");
		}
		else if (Main.netMode == 2)
		{
			Main.NewText("A portal from The Abyss has been opened!"); 
			Main.NewText("Artorias, the Ancient Knight of the Abyss has entered this world!...");
			Main.NewText("You must seek out the Shaman Elder...");
		}
		
		Main.hardMode = true;
		downedAttraidies = true;

	
	}
	
   else if (downedAttraidies)
   {
			
		 if (Main.netMode == 0)
		 {
			Main.NewText("The portal from The Abyss remains open..."); 
			Main.NewText("You must seek out the Shaman Elder..."); 
			
		 }
		else if (Main.netMode == 2)
		 {
			Main.NewText("The portal from The Abyss remains open..."); 
			Main.NewText("You must seek out the Shaman Elder..."); 
		 }

		 downedAttraidies = true;
		 Main.hardMode = true;


	}
		
}






    }

}
