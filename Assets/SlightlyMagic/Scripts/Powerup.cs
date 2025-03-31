using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
	[SerializeField] private float _destroyTime;
	[SerializeField] private float _rotateSpeed;
	[SerializeField] protected ParticleSystem _powerupEffectPrefab;

	private Vector3 _defaultPosition;
	protected float _time;
	protected bool _isCollected;

	public void SetStatus() => _isCollected = true;

	public bool IsActivated { get; private set; }

	private void Awake()
	{
		_defaultPosition = transform.position;
		IsActivated = false;
	}

	private void Update()
	{
		_time += Time.deltaTime;

		if (_isCollected == false)
		{
			if (_time < _destroyTime)
				DoAnimation();
			else
				Destroy(gameObject);
		}
	}

	private void DoAnimation()
	{
		transform.Rotate(Vector3.up, _rotateSpeed);
		transform.position = _defaultPosition + Vector3.up * Mathf.Sin(_time) / 5;
	}

	public virtual void Use(GameObject entity)
	{
		if (CanUseAbility(entity))
		{
			IsActivated = true;
			EffectPlay();
		}
		else
		{
			Debug.Log("Объект не может использовать способности");
			return;
		}
	}

	private bool CanUseAbility(GameObject entity)
	{
		PowerupUser user = entity.GetComponent<PowerupUser>();

		if (user != null)
			return true;
		else
			return false;
	}

	protected void EffectPlay()
	{
		Instantiate(_powerupEffectPrefab, transform.parent.position, Quaternion.identity);
		_powerupEffectPrefab.Play();
	}
}
