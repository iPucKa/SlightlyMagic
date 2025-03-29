using UnityEngine;

public class SpeedPowerup : Powerup
{
	[SerializeField] private int _moveSpeedMultiplier;
	[SerializeField] private int _rotateSpeedMultiplier;

	public override void Use(Player player)
	{
		base.Use(player);

		player.UseSpeedAgility(_moveSpeedMultiplier, _rotateSpeedMultiplier);

		Destroy(gameObject);
	}
}
