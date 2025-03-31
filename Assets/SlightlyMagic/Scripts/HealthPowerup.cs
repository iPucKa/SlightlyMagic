using UnityEngine;

public class HealthPowerup : Powerup
{
	[SerializeField] private int _additiveHealth;

	public override void Use(GameObject entity)
	{
		base.Use(entity);

		entity.GetComponent<Character>().UseHealthAbility(_additiveHealth);

		Destroy(gameObject);
	}
}
