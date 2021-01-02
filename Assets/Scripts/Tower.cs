using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 30f; 
    [SerializeField] ParticleSystem projectileParticle;

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            AttackEnemy();
        }       
        else 
        {
            toggleFiring(false);
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
