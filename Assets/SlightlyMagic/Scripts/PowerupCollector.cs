using UnityEngine;

public class PowerupCollector : MonoBehaviour
{
	[SerializeField] private Inventory _inventory;

	private bool CanJoinItem => _inventory.IsEmpty;

	private void OnTriggerEnter(Collider other)
	{
		Powerup item = other.GetComponent<Powerup>();

		if (item != null)
		{
			if (CanJoinItem)			
				_inventory.Occupy(item, transform);			
		}
	}
}
