using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;

    [Header("Attributes")] public float range = 15f;
    public float fireRate = 1f;
    private float _fireCountdown = 0f;

    [Header("Unity Setup Fields")] public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        // Find all enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            // Find distance to enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // If enemy is in range, set target to nearest enemy
        if (nearestEnemy != null && shortestDistance <= range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If no target, return
        if (_target == null)
        {
            return;
        }

        // Lock on target
        Vector3 dir = _target.position - transform.position;
        // Rotate turret
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Smoothly rotate turret
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // Rotate only on y axis
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // Fire
        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / fireRate;
        }

        _fireCountdown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        // Create bullet
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Get bullet component
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        // Shoot bullet
        if (bullet != null)
        {
            bullet.Seek(_target);
        }
    }
}