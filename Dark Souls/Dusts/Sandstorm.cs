using Terraria;
using Terraria.ModLoader;

namespace DarkSouls.Dusts
{
	public class Sandstorm : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.4f;
			dust.noGravity = true;
			dust.noLight = false;
			dust.scale *= 1.5f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			
			dust.scale *= 0.99f;
			float light = 2.35f * dust.scale;
			Lighting.AddLight(dust.position, light, light, light);
			if (dust.scale < 1f)
			{
				dust.active = true;
			}
			return false;
		}
	}
}