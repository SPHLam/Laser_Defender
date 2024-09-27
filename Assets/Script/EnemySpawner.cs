using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float _timeBetweenWaves = 0f;
    int currentWaveIndex = 0;
	[SerializeField] bool isLooping = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            currentWaveIndex = 0;
			foreach (WaveConfigSO currentWave in waveConfigs)
			{
				for (int i = 0; i < currentWave.GetEnemyCount(); i++)
				{
					Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.Euler(0, 0, 180), transform);
					yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
				}
				++currentWaveIndex;
				yield return new WaitForSeconds(_timeBetweenWaves);
			}
		} while (isLooping);
    }

    public WaveConfigSO GetCurrentWave()
    {
        return waveConfigs[currentWaveIndex];
    }
}
