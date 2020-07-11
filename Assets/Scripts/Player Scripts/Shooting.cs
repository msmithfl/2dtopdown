using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    [SerializeField]
    private float _fireRate = 2.0f;
    private float _canFire = -1f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _canFire)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        _canFire = Time.time + _fireRate;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
