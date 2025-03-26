using UnityEngine;

public class MovementHandler : MonoBehaviour
{
	public void MoveTo(Vector3 direction, float speedMoving)
	{
		transform.Translate(direction * speedMoving * Time.deltaTime, Space.World);

		Debug.DrawRay(transform.position, direction, Color.red);
	}

	public void MoveTo(CharacterController controller, Vector3 direction, float speedMoving)
	{
		controller.Move(direction * speedMoving * Time.deltaTime);
	}
}
