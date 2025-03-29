using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	private Powerup _item;

	public bool IsEmpty
	{
		get
		{
			if (_item == null)
				return true;

			if (_item.gameObject == null)
				return true;

			return false;
		}
	}
	public Vector3 Position => transform.position;

	public void Occupy(Powerup item) => _item = item;

	private void Update()
	{
		if (_item == null)
			return;

		if (_item.gameObject == null)
			return;

		if (_item.transform.position == Position)
			return;

		if (_item != null && _item.gameObject != null)
			if (_item.transform.parent != null)
				_item = null;
	}
}
