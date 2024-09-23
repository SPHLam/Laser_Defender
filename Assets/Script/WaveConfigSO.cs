using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
	[SerializeField] List<GameObject> enemyPrefabs;
	[SerializeField] private Transform _pathPrefab;
	[SerializeField] private float _moveSpeed = 5f;
	[SerializeField] private float timeBetweenEnemySpawns = 1f;
	[SerializeField] private float _spawnTimeVariance = 0f;
	[SerializeField] private float _minimumSpawnTime = 0.2f;

	public Transform GetStartingWaypoint()
	{
		return _pathPrefab.GetChild(0);
	}

	public List<Transform> GetWayPoints()
	{
		List<Transform> waypoints = new List<Transform>();
		foreach (Transform waypoint in _pathPrefab)
		{
			waypoints.Add(waypoint);
		}
		return waypoints;
	}

	public float GetMoveSpeed()
	{
		return _moveSpeed;
	}

	public int GetEnemyCount()
	{
		return enemyPrefabs.Count;
	}

	public GameObject GetEnemyPrefab(int index)
	{
		return enemyPrefabs[index];
	}

	public float GetRandomSpawnTime()
	{
		float randomSpawnTime = Random.Range(timeBetweenEnemySpawns - _spawnTimeVariance, timeBetweenEnemySpawns + _spawnTimeVariance);
		return Mathf.Clamp(randomSpawnTime, _minimumSpawnTime, float.MaxValue);
	}
}
