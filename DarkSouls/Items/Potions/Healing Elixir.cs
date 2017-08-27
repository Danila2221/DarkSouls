using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
namespace DarkSouls.Items.Potions
{

	public class HealingElixir : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 32;
			item.maxStack = 20;

			item.rare = 11;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Healing Elixir");
			DisplayName.AddTranslation(GameCulture.Russian, "Исцеляющий эликсир");
			Tooltip.SetDefault("Heals the player of all bleeding, poisoned, confused and broken armor debuffs."
				+ "\nAdds life regeneration buff for 2 minutes");
			Tooltip.AddTranslation(GameCulture.Russian, "Излечивает игрока от кровотечения, отравленния, ошеломления и сломанных доспехов."
				+ "\nДобавляет регенерацию здоровья на 2 минуты");
		
		}


		public override bool UseItem(Player player)
		{
			player.AddBuff(2, 10800, false);   

for(int num36 = 0; num36 < 10; num36++)
	{
		if (player.buffType[num36] == 20)
		{
		player.buffType[num36] = 0;
		player.buffTime[num36] = 0;
		
		break;
		}
	}

for(int num37 = 0; num37 < 10; num37++)
	{
		if (player.buffType[num37] == 30)
		{
		player.buffType[num37] = 0;
		player.buffTime[num37] = 0;
		
		break;
		}
	}


for(int num31 = 0; num31 < 10; num31++)
	{
		if (player.buffType[num31] == 31)
		{
		player.buffType[num31] = 0;
		player.buffTime[num31] = 0;
		
		break;
		}
	}


for(int num38 = 0; num38 < 10; num38++)
	{
		if (player.buffType[num38] == 36)
		{
		player.buffType[num38] = 0;
		player.buffTime[num38] = 3600;
		
		break;
		}
	}
	return true;
}
			
		}

		
	}

