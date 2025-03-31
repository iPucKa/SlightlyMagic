using UnityEngine;

public class Character : MonoBehaviour
{
	private string _horizontalAxisName = "Horizontal";
	private string _verticalAxisName = "Vertical";

	private float _xInput;
	private float _yInput;

	private KeyCode _usePowerupKey = KeyCode.Space;

	[SerializeField] private float _moveSpeed = 10;
	[SerializeField] private float _rotateSpeed = 500;
	[SerializeField] private int _health = 100;
	[SerializeField] private Timer _timer;

	private int _maxHealth = 500;
	private float _maxMoveSpeed = 50;
	private float _maxRotateSpeed = 2000;

	private float _defaultMoveSpeed;
	private float _defaultRotateSpeed;

	public float Speed { get; private set; }

	private Mover _mover;
	private Rotator _rotator;

	private Inventory _inventory;
	private PowerupUser _powerupUser;

	private float _speedAbilityDuration = 5f;
	private float _currentTime;

	private float _deadInputZone = 0.1f;

	private void Awake()
	{
		_inventory = GetComponentInChildren<Inventory>();
		_powerupUser = GetComponent<PowerupUser>();

		_mover = GetComponent<Mover>();
		_rotator = GetComponent<Rotator>();

		_defaultMoveSpeed = _moveSpeed;
		_defaultRotateSpeed = _rotateSpeed;
	}

	private void Update()
	{
		_xInput = Input.GetAxisRaw(_horizontalAxisName);
		_yInput = Input.GetAxisRaw(_verticalAxisName);		

		if (Input.GetKeyDown(_usePowerupKey))
			_powerupUser.UsePowerup(_inventory.Item);

		ResetSpeedAbility();
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

	public void UseSpeedAbility(int moveMultiplier, int rotateMultiplier)
	{
		_moveSpeed *= moveMultiplier;
		_rotateSpeed *= rotateMultiplier;

		if (_moveSpeed >= _maxMoveSpeed)
			_moveSpeed = _maxMoveSpeed;

		if (_rotateSpeed >= _maxRotateSpeed)
			_rotateSpeed = _maxRotateSpeed;

		_timer.ResetTimer();
	}

	public void UseHealthAbility(int value)
	{
		_health += value;

		if(_health >= _maxHealth)
			_health = _maxHealth;
	}

	private void ResetSpeedAbility()
	{
		_currentTime = _timer.CurrentTime;

		if (_currentTime >= _speedAbilityDuration)
		{
			_moveSpeed = _defaultMoveSpeed;
			_rotateSpeed = _defaultRotateSpeed;
		}
	}
}
