using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int playerHealth = 5;
    [SerializeField] int damagePerHit = 1;
    [SerializeField] Text healthText;

    private void Start() 
    {
        healthText.text = playerHealth.ToString();
    }

    private void OnTriggerEnter(Collider other) {
        playerHealth -= damagePerHit;
        print("Im HIT!!!");
        if (playerHealth <= 0)
        {
            print("Get fucked");
        }
        healthText.text = playerHealth.ToString();
    }

}
