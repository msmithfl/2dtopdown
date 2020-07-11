using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float destroyAfterSec = 2.0f;

    void Start()
    {

    }
    void Update()
    {
        Destroy(this.gameObject, destroyAfterSec);
    }
}
