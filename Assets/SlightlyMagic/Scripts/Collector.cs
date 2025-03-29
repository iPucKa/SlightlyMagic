using UnityEngine;

public class Collector : MonoBehaviour
{
	[SerializeField] private JoinPoint _joinPoint;

	private Powerup _item;

	public Powerup Item
	{
		get
		{
			if (_item == null)
				return null;

			if (_item.gameObject == null)
				return null;

			return _item;
		}
	}

	private bool CanJoinItem
	{
		get
		{
			if (_joinPoint.IsEmpty)
				return true;
			else
				return false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Powerup item = other.GetComponent<Powerup>();

		if (item != null)
		{
			if (CanJoinItem)
			{
				_joinPoint.Occupy(item);
				Join(item);
			}
		}
	}

	public void Join(Powerup item)
	{
		_item = item;

		item.transform.SetParent(transform);

		item.transform.position = _joinPoint.transform.position;
		item.transform.rotation = _joinPoint.transform.rotation;

		Debug.Log($"Подобрано: {item}");
	}
}
