using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public Camera cam;
    Vector2 mousePos;

    bool facingRight = true;
    SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    void Aim()
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        //code to face mouse with animation
        if (lookPos.x >= 0 && !facingRight)
        { // mouse is on right side of player
            transform.localScale = new Vector3(1, 1, 1); // or activate look right some other way
            facingRight = true;
        }
        else if (lookPos.x < 0 && facingRight)
        { // mouse is on left side
            transform.localScale = new Vector3(-1, 1, 1); // activate looking left
            facingRight = false;
        }

        if (angle > 90 || angle < -90)
        {
            spr.flipY = true;
        }
        else
        {
            spr.flipY = false;
        }
    }

}
