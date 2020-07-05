using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float speed;
    private Transform target;
    public float agroRange = 3;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, target.position);

        if (distToPlayer < agroRange)
        {
            // code to chase
            if (Vector2.Distance(transform.position, target.position) > 1.5)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
        else
        {
            // stop chasing
            rb2d.velocity = new Vector2(0, 0);
        }

    }
}
