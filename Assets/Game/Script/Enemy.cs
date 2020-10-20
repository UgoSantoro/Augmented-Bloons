using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float hp;
    

    private Transform target;
    private int wavepointIndex = 0;

    void Start () {
        target = Waypoints.points[0];
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
        if (hp <= 0) {
            Destroy(gameObject);
        } 
    }

    public void MultWave(int w) {
        hp += (float)(hp * (w * 0.1));
    }
}
