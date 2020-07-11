using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDrop : MonoBehaviour
{

    public Transform blueTowerPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DropBlueTower();
        }
    }

    void DropBlueTower()
    {
        Instantiate(blueTowerPrefab, firePoint.position, Quaternion.identity);
    }
}
