using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 5;
    [SerializeField] EnemyMovement enemy;

    bool running = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (running)
        {
            print("Spawning a new enemy!");
            Instantiate(enemy, (transform.position + new Vector3(0, -5, 0)), Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
