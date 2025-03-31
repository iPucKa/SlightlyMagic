using UnityEngine;

public class Inventory : MonoBehaviour
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

	public void Occupy(Powerup item)
	{
		_item = item;
		_item.SetStatus();
	}

	public void SetParent(Transform parent)
	{
		_item.transform.SetParent(parent);

		_item.transform.position = transform.position;
		_item.transform.rotation = transform.rotation;

		Debug.Log($"���������: {_item}, �������� ��������: {parent.name}");
	}
}
