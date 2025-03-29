using UnityEngine;

public class Arrow : MonoBehaviour
{
	[SerializeField] private float _arrowDestroyTime;
	[SerializeField] private float _force;

	private Rigidbody _arrow;

	private float _time;

	private void Awake()
	{
		_arrow = GetComponent<Rigidbody>();
		_arrow.angularVelocity = Vector3.zero;
	}

	private void Update()
	{
		_time += Time.deltaTime;

		_arrow.AddForce(transform.forward * _force * Time.deltaTime, ForceMode.Impulse);

		if (_time >= _arrowDestroyTime)
			Destroy(gameObject);
	}
}
