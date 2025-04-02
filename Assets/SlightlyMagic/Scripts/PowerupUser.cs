using UnityEngine;

public class PowerupUser : MonoBehaviour
{
	public void UsePowerup(Powerup powerup)
	{
		if (powerup == null)
			Debug.Log("Усиление не найдено. Попробуйте подобрать предмет");

		else
			powerup.Use(gameObject);
	}
}
