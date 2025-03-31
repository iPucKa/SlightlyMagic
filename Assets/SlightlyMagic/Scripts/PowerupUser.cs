using UnityEngine;

public class PowerupUser : MonoBehaviour
{
	public void UsePowerup(Powerup powerup)
	{
		if (powerup == null)
			Debug.Log("�������� �� �������. ���������� ��������� �������");

		else if (powerup != null && powerup.IsActivated == false)
			powerup.Use(gameObject);
	}
}
