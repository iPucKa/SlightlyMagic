using UnityEngine;

public class PowerupUser : MonoBehaviour
{
	public void UsePowerup(Powerup powerup)
	{
		if (powerup == null)
			Debug.Log("�������� �� �������. ���������� ��������� �������");

		else
			powerup.Use(gameObject);
	}
}
