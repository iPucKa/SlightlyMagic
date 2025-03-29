using UnityEngine;

public class WeaponPoerup : Powerup
{
	[SerializeField] private Arrow _arrowPrefab;
	[SerializeField] private Transform _arrowSpawnPont;

	public override void Use(Player player)
	{
		base.Use(player);

		Vector3 position = _arrowSpawnPont.position + Vector3.down * 2;

		Quaternion lookPoint = transform.parent.rotation;

		Instantiate(_arrowPrefab, position, lookPoint);

		Destroy(gameObject);
	}
}
