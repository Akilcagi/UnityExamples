using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range = 15f; 
    public float fireRate = 1f; 
    private float fireCountdown = 0f; 
    private Transform target; 

    public GameObject bulletPrefab; 
    public Transform firePoint;
    private bool isPlaced = false;
    private AudioSource shootAudioSource;

    private void Start()
    {
        shootAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!isPlaced)
            return;


        if (!target)
        {
            FindTarget();
        }
       
        if (target == null || Vector3.Distance(transform.position, target.position) > range)
        {
            FindNearestTarget();
            return;
        }

        
        LockOnTarget();

        
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    public void SetPlaced()
    {
        isPlaced = true;
    }
    void FindTarget()
    {
        
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && closestDistance <= range)
        {
            target = closestEnemy.transform;
        }
    }
    void FindNearestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void LockOnTarget()
    {
       
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f); 
        }
    }

    void Shoot()
    {
        shootAudioSource.Play();
        if (target != null)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }
    }
    


 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
