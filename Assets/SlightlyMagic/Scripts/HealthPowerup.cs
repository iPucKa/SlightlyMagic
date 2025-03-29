using UnityEngine;

public class HealthPowerup : Powerup
{
	[SerializeField] private int _additiveHealth;

	public override void Use(Player player)
	{
		base.Use(player);

		player.UseHealthAgility(_additiveHealth);

		Destroy(gameObject);
	}
}
