using UnityEngine;

public class Player : MonoBehaviour
{
	private string _horizontalAxisName = "Horizontal";
	private string _verticalAxisName = "Vertical";

	private float _xInput;
	private float _yInput;

	private KeyCode _usePowerupKey = KeyCode.Space;

	[SerializeField] private float _moveSpeed = 5;
	[SerializeField] private float _rotateSpeed = 500;
	[SerializeField] private int _health = 100;

	private int _maxHealth = 500;
	private float _maxMoveSpeed = 50;
	private float _maxRotateSpeed = 2000;

	private float _defaultMoveSpeed;
	private float _defaultRotateSpeed;

	public float Speed { get; private set; }

	private Mover _mover;
	private Rotator _rotator;

	private Powerup _powerup;
	private Collector _collector;

	private bool _isAbilityUsed;
	private float _speedAgilityDuration = 5f;
	private float _time;

	private float _deadInputZone = 0.1f;

	private void Awake()
	{
		_collector = GetComponent<Collector>();
		_mover = GetComponent<Mover>();
		_rotator = GetComponent<Rotator>();

		_defaultMoveSpeed = _moveSpeed;
		_defaultRotateSpeed = _rotateSpeed;
	}

	private void Update()
	{
		_xInput = Input.GetAxisRaw(_horizontalAxisName);
		_yInput = Input.GetAxisRaw(_verticalAxisName);
		_isAbilityUsed = Input.GetKeyDown(_usePowerupKey);

		_powerup = _collector.Item;

		if (_isAbilityUsed)
			UsePowerup(_powerup);

		ResetSpeedAgility();
	}

	private void FixedUpdate()
	{
		Vector3 input = new Vector3(_xInput, 0, _yInput);
		Vector3 normalizedInput = input.normalized;

		if (input.magnitude <= _deadInputZone)
			return;

		_rotator.RotateTo(normalizedInput, _rotateSpeed);
		_mover.MoveTo(normalizedInput, _moveSpeed);
	}

	private void UsePowerup(Powerup powerup)
	{
		if (powerup == null)
			Debug.Log("Усиление не найдено. Попробуйте подобрать предмет");
		
		else if (powerup != null && powerup.IsActivated == false)
		{
			powerup.Use(this);

			_isAbilityUsed = false;
		}
	}

	public void UseSpeedAgility(int moveMultiplier, int rotateMultiplier)
	{
		_moveSpeed *= moveMultiplier;
		_rotateSpeed *= rotateMultiplier;

		if (_moveSpeed >= _maxMoveSpeed)
			_moveSpeed = _maxMoveSpeed;

		if (_rotateSpeed >= _maxRotateSpeed)
			_rotateSpeed = _maxRotateSpeed;

		_time = 0;
	}

	public void UseHealthAgility(int value)
	{
		_health += value;

		if(_health >= _maxHealth)
			_health = _maxHealth;
	}

	private void ResetSpeedAgility()
	{
		_time += Time.deltaTime;

		if (_time >= _speedAgilityDuration)
		{
			_moveSpeed = _defaultMoveSpeed;
			_rotateSpeed = _defaultRotateSpeed;
		}
	}
}
