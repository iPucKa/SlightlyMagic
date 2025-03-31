using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time;

    public float CurrentTime => _time;

    void Update()
    {
		Find();
	}

    public void ResetTimer()
    {
        _time = 0;
    }

	private float Find()
	{
		_time += Time.deltaTime;
        return _time;
	}
}
