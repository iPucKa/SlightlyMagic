using UnityEngine;

public class Destroyer : MonoBehaviour
{
	[SerializeField] private float _deathTime;

	private void Start()
	{
		Destroy(gameObject, _deathTime);
	}
}
