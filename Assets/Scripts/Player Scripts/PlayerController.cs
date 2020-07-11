using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    bool facingRight = true;

    public Animator animator;
    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateMovement();
    }

        

    void Update()
    {
        StartAnimation();
    }
    

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //movement
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        //clamping code
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.2f, 2.2f), Mathf.Clamp(transform.position.y, -1.09f, 1.16f), 0);
    }

    void StartAnimation()
    {
        // using mousePosition and player's transform (on orthographic camera view)
        var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (delta.x >= 0 && !facingRight)
        { // mouse is on right side of player
            transform.localScale = new Vector3(1, 1, 1); // or activate look right some other way
            facingRight = true;
        }
        else if (delta.x < 0 && facingRight)
        { // mouse is on left side
            transform.localScale = new Vector3(-1, 1, 1); // activate looking left
            facingRight = false;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
  
}
