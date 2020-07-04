using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public GameObject crossHair;
    public GameObject arrowPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // to flip LR animations **right animation is curently used for both left and right
        //if (Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    transform.localScale = new Vector2(-1, 1);
        //}
        //else if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    transform.localScale = new Vector2(1, 1);
        //}

        AimAndShoot();

        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void AimAndShoot()
    {
        Vector3 aim = new Vector3(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"), 0.0f);
        Vector2 shootingDirection = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));

        if (aim.magnitude > 0.0f)
        {
            aim.Normalize();
            aim *= 4f;
            crossHair.transform.localPosition = aim;
            crossHair.SetActive(true);

            shootingDirection.Normalize();
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
                arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * 13.0f;
                arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
                Destroy(arrow, 2.0f);
            }
        }
        else
        {
            crossHair.SetActive(false);
        }
    }
}
