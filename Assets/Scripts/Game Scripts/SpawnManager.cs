using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject _enemyPrefab;
    public float spawnRate = 1f;
    public GameObject _enemyContainer;
    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRountine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRountine()
    {

        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-2.3f, 2.3f), 1.5f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(spawnRate);
        }
    }
    /*
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }*/
}
