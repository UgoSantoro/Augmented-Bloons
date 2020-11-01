using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics.PerformanceData;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemy Type")]
    public Transform NormalEnemy;
    public Transform TankEnemy;
    public Transform SpeedEnemy;
    public Transform FastAsFuckBoiEnemy;

    [Header("Start")]
    public Transform SpawnPoint;

    [Header("Settings")]
    public GameObject End;
    public float Time_btw_waves = 5f;
    private float countdow = 2f;
    private List<List<int>> waves = new List<List<int>>();
    private Dictionary<EnemyType, Transform> dict = new Dictionary<EnemyType, Transform>();

    public float hp = 25f;
    public Text HP;
    public Text WaveCountdownTest;

    private int Waveindex = -1;

    [Header("Money")]
    public float money = 300;
    public Text MoneyDisplay;


    [Header("Wave")]
    public Text WaveDisplay;
    private int wave;

    void Start () {
        dict.Add(EnemyType.Normal, NormalEnemy);
        dict.Add(EnemyType.Tank, TankEnemy);
        dict.Add(EnemyType.Speed, SpeedEnemy);
        dict.Add(EnemyType.FastAsFuckBoi, FastAsFuckBoiEnemy);
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 1, 1, 1, 1, 1, 1 });
        waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
        waves.Add(new List<int> { 2, 2, 2, 2, 2, 1, 1, 1 });
        waves.Add(new List<int> { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0 });
        waves.Add(new List<int> {
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
        });
    }

    void Update()
    {
        if (countdow <= 0f && Waveindex + 1 < waves.Count)
        {
            if (hp > 0)
                StartCoroutine(SpawnWave());
            else if (hp <= 0)
                End.SetActive(true);
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            countdow = Time_btw_waves;
        }
        countdow -= Time.deltaTime;
        if (WaveCountdownTest != null)
            WaveCountdownTest.text = Mathf.Round(countdow).ToString();
        if (MoneyDisplay != null)
            MoneyDisplay.text = money.ToString();
        if (WaveDisplay != null)
            WaveDisplay.text = (Waveindex + 1).ToString() + " / " + waves.Count.ToString();
        if (HP != null)
            HP.text = hp.ToString();
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
        Enemy.localScale = new Vector3(1, 1, 1);
        Enemy.gameObject.GetComponent<Enemy>().MultWave(Waveindex);
    }
}
