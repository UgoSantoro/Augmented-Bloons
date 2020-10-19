using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics.PerformanceData;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemayPrefab;

    public Transform SpawnPoint;

    public float Time_btw_waves = 5f;
    private float countdow = 2f;

    public Text WaveCountdownTest;

    private int Waveindex = 0;

    void Update()
    {
      if (countdow <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdow = Time_btw_waves;
        }

        countdow -= Time.deltaTime;
        WaveCountdownTest.text = Mathf.Round(countdow).ToString();
    }

    IEnumerator SpawnWave()
    {
        Waveindex++;
        for (int i = 0; i < Waveindex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(EnemayPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
