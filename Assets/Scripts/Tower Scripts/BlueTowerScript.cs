using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTowerScript : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    [SerializeField]
    private float range = 1f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Setup Fields")]

    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;



    //public Transform partToRotate;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
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

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 lookPos = target.position - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //add lerp to smooth enemy lock on
        //might need to rotate y axis in inspector once sprites are added to face enemy

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BlueBulletScript bullet = bulletGO.GetComponent<BlueBulletScript>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
