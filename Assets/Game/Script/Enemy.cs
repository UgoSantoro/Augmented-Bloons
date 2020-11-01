using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float starthp;
    private float hp;

    public Image Healthbar;

    private GameObject gameHandler;
    private Transform target;
    private int wavepointIndex = 0;

    void Start () {
        target = Waypoints.points[0];
        hp = starthp;
        gameHandler = GameObject.Find("GameHandler");
    }

    void Update () {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {
        if (wavepointIndex >= Waypoints.points.Length - 1) {
            gameHandler.GetComponent<WaveSpawner>().hp -= 1;
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void Hit(float power) {
        hp -= power;

        Healthbar.fillAmount = hp / starthp;
        if (hp <= 0) {
            gameHandler.GetComponent<WaveSpawner>().money = gameHandler.GetComponent<WaveSpawner>().money + ( (power + hp) / 2) + 10;
            Destroy(gameObject);
        } else {
            gameHandler.GetComponent<WaveSpawner>().money = gameHandler.GetComponent<WaveSpawner>().money + ( power / 2);
        }
    }

    public void MultWave(int w) {
        hp += (float)(hp * (w * 0.1));
    }
}
