using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    [Header("General")]
    public float fireRate = 1f;
    public float power = 1f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    private float fireCountdown = 0f;
    public float range = 15f;

    [Header("Use Laser")]
    public bool uselaser = false;
    public LineRenderer linerenderer;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;

    public Transform firePoint;

    void Start() {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        target = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                if (shortestDistance <= range) {
                    target = enemy.transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            if (uselaser)
            {
                if (linerenderer.enabled)
                    linerenderer.enabled = false;
            }
            return;
        }
        LockOnTarget();

        if (uselaser)
        {
            Laser();
        } else
        {
            if (fireCountdown <= 0f) {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }

    }

    void LockOnTarget ()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, rotation.z);
    }

    void Laser()
    {
        if (!linerenderer.enabled)
        {
            linerenderer.enabled = true;
        }
        linerenderer.SetPosition(0, firePoint.position);
        linerenderer.SetPosition(1, target.position);
        if (fireCountdown <= 0f) {
            target.gameObject.GetComponent<Enemy>().Hit(power);
            fireCountdown = 1f / fireRate / 30;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot () {
        GameObject bulletGo = (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null) {
            bullet.power = power;
            bullet.Seek(target);
        }
    }

    public void lvl_up()
    {
        power += power/10;
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
