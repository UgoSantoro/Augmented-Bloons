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

    private Transform target;
    private int wavepointIndex = 0;

    void Start () {
        target = Waypoints.points[0];
        hp = starthp;
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
            Destroy(gameObject);
        }
    }

    public void MultWave(int w) {
        hp += (float)(hp * (w * 0.1));
    }
}
