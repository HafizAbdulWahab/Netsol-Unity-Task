using System;
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int currentHealth = 3;     //The box's current health point total

    public GameObject ObjectPoolInstance;

    private void OnEnable()
    {
        currentHealth = 3;
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)         //Check if health has fallen below zero /Enemy Died
        {
            ObjectPoolInstance.GetComponent<ObjectPool>().ActivateDisableEnemyObjects();  //Start CoRoutine to Activate Enemy 
            gameObject.SetActive (false);             //if health has fallen below zero, deactivate it 

        }
    }

}