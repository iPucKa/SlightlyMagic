using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
	[SerializeField] private float _destroyTime;
	[SerializeField] private float _rotateSpeed;
	[SerializeField] protected ParticleSystem _powerupEffectPrefab;

	private Vector3 _defaultPosition;
	protected float _time;

	public bool IsCollected
	{
		get
		{
			if (transform.parent != null)
				return true;
			return false;
		}
	}

	protected bool _isActivated;
	public bool IsActivated => _isActivated;

	private void Awake()
	{
		_defaultPosition = transform.position;
		_isActivated = false;
	}

	private void Update()
	{
		_time += Time.deltaTime;

		if (IsCollected == false)
		{
			if (_time < _destroyTime)
			{
				DoAnimation();
			}
			else
				Destroy(gameObject);
		}
	}

	private void DoAnimation()
	{
		transform.Rotate(Vector3.up, _rotateSpeed);
		transform.position = _defaultPosition + Vector3.up * Mathf.Sin(_time) / 5;
	}

	public virtual void Use(Player player)
	{
		_isActivated = true;

		EffectPlay();
	}

	protected void EffectPlay()
	{
		Instantiate(_powerupEffectPrefab, transform.parent.position, Quaternion.identity);
		_powerupEffectPrefab.Play();
	}
}
