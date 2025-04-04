using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private List<SpawnPoint> _spawnPoints;
	[SerializeField] private float _cooldown;

	[SerializeField] private List<Powerup> _powerupPrefabs;

	private float _time;

	private void Update()
	{
		_time += Time.deltaTime;

		if (_time >= _cooldown)
		{
			List<SpawnPoint> emptyPoints = GetEnptyPoints();

			if (emptyPoints.Count == 0)
			{
				_time = 0;
				return;
			}

			SpawnPoint spawnPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];

			Powerup item = Instantiate(_powerupPrefabs[Random.Range(0, _powerupPrefabs.Count)], spawnPoint.Position, Quaternion.identity);

			spawnPoint.Occupy(item);

			_time = 0;
		}
	}

	private List<SpawnPoint> GetEnptyPoints()
	{
		List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

		foreach (SpawnPoint point in _spawnPoints)
			if (point.IsEmpty)
				emptyPoints.Add(point);

		return emptyPoints;
	}
}
