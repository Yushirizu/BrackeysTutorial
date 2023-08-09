using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    private float _countdown = 2f;

    [FormerlySerializedAs("WaveCountdownText")] public Text waveCountdownText;

    private int _waveIndex;

    void Update()
    {
        // If countdown is less than or equal to 0, spawn a wave
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
        }

        // Countdown
        _countdown -= Time.deltaTime;

        // Round the countdown to an integer
        waveCountdownText.text = Mathf.Round(_countdown).ToString(CultureInfo.InvariantCulture);
    }

    IEnumerator SpawnWave()
    {
        _waveIndex++;

        // Spawn enemies
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        // Spawn enemy
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}