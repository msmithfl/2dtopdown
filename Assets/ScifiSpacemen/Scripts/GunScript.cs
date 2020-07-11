using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {


    private Vector3 mousePos;
    SpriteRenderer spr;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private bool lastFired = false;
    Rigidbody2D rb2d;


    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Aim();
        Fire();
    }

    //Mouse Look script
    void Aim()
    {
        float jump = Input.GetAxis("Jump");

        //Gets mouse position, you can define Z to be in the position you want the weapon to be in
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (jump != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.parent.position.y - 0.05f, transform.position.z);
        } else
        {
            transform.position = new Vector3(transform.position.x, transform.parent.position.y, transform.position.z);
        }

        if(angle > 5)
        {
            spr.sortingOrder = 4;
        } else
        {
            spr.sortingOrder = 6;
        }

        if (angle > 90 || angle < -90)
        {
            spr.flipY = true;
        } else
        {
            spr.flipY = false;
        }
    }
    void Fire()
    {
        float fire = Input.GetAxis("Fire1");

        if(fire > 0)
        {
            if(!lastFired)
            {
                // Create the Bullet from the Bullet Prefab
                var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<BulletScript>().StartShoot();
                // Destroy the bullet after some time
                Destroy(bullet, 0.9f);

                lastFired = true;
            }
        } else
        {
            lastFired = false;
        }
    }
}
