using UnityEngine;

public class JoinPoint : MonoBehaviour
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

	public void Occupy(Powerup item) => _item = item;
}
