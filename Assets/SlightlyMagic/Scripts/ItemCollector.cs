using UnityEngine;

public class ItemCollector : MonoBehaviour
{
	private int _items;

	private void OnTriggerEnter(Collider other)
	{
		MagicItem item = other.GetComponent<MagicItem>();

		if (item != null)
		{
			//Add(coin.Value);
			Destroy(item.gameObject);
		}

	}

	public void Add(int items)
	{
		if (items < 0)
		{
			Debug.LogError("Items < 0");
			return;
		}

		_items += items;

		Debug.Log($"Монет собрано: {_items}");
	}
}
