using UnityEngine;

public class WeaponPowerup : Powerup
{
	[SerializeField] private Arrow _arrowPrefab;
	[SerializeField] private Transform _arrowSpawnPont;

	public override void Use(GameObject entity)
	{
		base.Use(entity);

		Vector3 position = _arrowSpawnPont.position + Vector3.down * 2;

		Quaternion lookPoint = transform.parent.rotation;

		Instantiate(_arrowPrefab, position, lookPoint);

		Destroy(gameObject);
	}
}
