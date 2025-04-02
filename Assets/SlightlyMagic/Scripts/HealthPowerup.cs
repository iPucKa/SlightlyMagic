using UnityEngine;

public class HealthPowerup : Powerup
{
	[SerializeField] private int _additiveHealth;

	public override void Use(GameObject entity)
	{
		base.Use(entity);

		entity.GetComponent<Character>().AddHealth(_additiveHealth);

		Destroy(gameObject);
	}
}
