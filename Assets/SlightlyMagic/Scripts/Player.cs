using UnityEngine;

public class Player : MonoBehaviour
{
	private string _horizontalAxisName = "Horizontal";
	private string _verticalAxisName = "Vertical";

	[SerializeField] private float _speed;
	[SerializeField] private float _rotateSpeed;

	private MovementHandler _movementHandler;
	private Rotator _rotator;
	private ItemCollector _itemCollector;

	private CharacterController _controller;

	private float _deadInputZone = 0.1f;

	private void Awake()
	{
		_controller = GetComponent<CharacterController>();
		_itemCollector = GetComponent<ItemCollector>();
		_movementHandler = GetComponent<MovementHandler>();
		_rotator = GetComponent<Rotator>();
	}

	private void Update()
	{
		Vector3 input = new Vector3(Input.GetAxis(_horizontalAxisName), 0, Input.GetAxis(_verticalAxisName));
		Vector3 normalizedInput = input.normalized;

		if (input.magnitude <= _deadInputZone)
			return;

		_rotator.RotateTo(normalizedInput, _rotateSpeed);
		_movementHandler.MoveTo(_controller, normalizedInput, _speed);
	}
}
