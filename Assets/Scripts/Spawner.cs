using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 5;
    [SerializeField] EnemyMovement enemy;
    [SerializeField] GameObject enemyParent;
    [SerializeField] Text scoreText;
    [SerializeField] int score;

    bool running = true;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        StartCoroutine(SpawnEnemies());
        

    }

    IEnumerator SpawnEnemies()
    {
        while (running)
        {
            print("Spawning a new enemy!");
            var newEnemy = Instantiate(enemy, (transform.position + new Vector3(0, -5, 0)), Quaternion.identity);
            newEnemy.transform.parent = enemyParent.transform; 
            score += 5;
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
