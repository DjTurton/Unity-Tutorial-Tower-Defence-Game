using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f; 
    [SerializeField] ParticleSystem projectileParticle;


    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            AttackEnemy();
        }       
        else 
        {
            toggleFiring(false);
        }   
    }

    void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0)
        {
            return;
        }
        else 
        {
            Transform closestEnemy = sceneEnemies[0].transform;

            foreach (var candidate in sceneEnemies)
            {
                closestEnemy = GetClosestEnemy(candidate.transform, closestEnemy);
            } 
            targetEnemy = closestEnemy;
        }
    }

    Transform GetClosestEnemy(Transform a, Transform b)
    {
        var aDist = Vector3.Distance(transform.position, a.position);
        var bDist = Vector3.Distance(transform.position, b.position);
        if (aDist < bDist)
        {
            return a;
        }
        else 
        {
            return b;
        }
    }

    void AttackEnemy()
    {
        float distance = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distance <= attackRange)
        {
            objectToPan.LookAt(targetEnemy);
            toggleFiring(true);
        }
        else 
        {
            toggleFiring(false);
        }   

    }

    void toggleFiring(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
