using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics.PerformanceData;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform NormalEnemy;
    public Transform TankEnemy;
    public Transform SpeedEnemy;
    public Transform FastAsFuckBoiEnemy;

    public Transform SpawnPoint;

    public float Time_btw_waves = 5f;
    private float countdow = 2f;
    private List<List<int>> waves = new List<List<int>>();
    private Dictionary<EnemyType, Transform> dict = new Dictionary<EnemyType, Transform>();

    public Text WaveCountdownTest;

    private int Waveindex = -1;

    public float money = 300;

    void Start () {
        dict.Add(EnemyType.Normal, NormalEnemy);
        dict.Add(EnemyType.Tank, TankEnemy);
        dict.Add(EnemyType.Speed, SpeedEnemy);
        dict.Add(EnemyType.FastAsFuckBoi, FastAsFuckBoiEnemy);
        waves.Add(new List<int> { 1 });
        waves.Add(new List<int> { 1, 1 });
        waves.Add(new List<int> { 1 });
        waves.Add(new List<int> { 1 });
        waves.Add(new List<int> { 0, 1, 2 ,3 });
    }

    void Update()
    {
        if (countdow <= 0f && Waveindex + 1 < waves.Count)
        {
            StartCoroutine(SpawnWave());
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            countdow = Time_btw_waves;
        }
        countdow -= Time.deltaTime;
        WaveCountdownTest.text = Mathf.Round(countdow).ToString();
    }

    IEnumerator SpawnWave()
    {
        Waveindex++;
        foreach (EnemyType type in waves[Waveindex]) {
            SpawnEnemy(type);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy(EnemyType type)
    {
        Transform Enemy = Instantiate(dict[type], SpawnPoint.position, SpawnPoint.rotation);
        Enemy.gameObject.GetComponent<Enemy>().MultWave(Waveindex);
    }
}
