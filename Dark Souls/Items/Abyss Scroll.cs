using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace DarkSouls.Items
{
	public class AbyssScroll : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Свиток Бездны");
			Tooltip.SetDefault("To close the seal to the Abyss and ignite the Kiln of the First Flame,"
				+ "\nyou must defeat the 6 lords of The Abyss: Artorias, Blight, The Wyvern Mage Shadow,"
				+ "\nChaos, and Seath the Scaleless. With a lord soul from each of these beings,"
				+ "\nyou will be able to summon the final guardian - Gwyn, Lord of Cinder."
				+ "\nTo craft the summoning item for each guardian, you will need to return to eight familiar places"
				+ "\nand collect a unique item dropped from an enemy you will find there: The Western Ocean, the Underground,"
				+ "\nthe Corruption, the Jungle, the dungeon, the underworld and the Eastern Ocean.");
				
			Tooltip.AddTranslation(GameCulture.Russian, "Чтобы закрыть портал в бездну и зажечь Печь Первого Пламени,"
				+ "\nВы должны победить 6 повелителей Бездны: Арториаса, Блайта, Теневого Мага Виверн,"
				+ "\nХаоса и Ситха Скалы. Из душ данных существ,"
				+ "\nвы сможете призвать главного стража - Гвина, Повелителя Пепла.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;
		}

		
	}
}
