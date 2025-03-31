using UnityEngine;

public class SpeedPowerup : Powerup
{
	[SerializeField] private int _moveSpeedMultiplier;
	[SerializeField] private int _rotateSpeedMultiplier;

	public override void Use(GameObject entity)
	{
		base.Use(entity);

		entity.GetComponent<Character>().UseSpeedAbility(_moveSpeedMultiplier, _rotateSpeedMultiplier);

		Destroy(gameObject);
	}
}
