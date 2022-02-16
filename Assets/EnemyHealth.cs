using System;
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    //The box's current health point total
    public int currentHealth = 3;
    public GameObject ObjectPoolInstance;

    private void OnEnable()
    {
        currentHealth = 3;
    }

    public void Damage(int damageAmount)
    {
    //    print("Damage is Called");
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0) 
        {
            print("enemy died");
            ObjectPoolInstance.GetComponent<ObjectPool>().ActivateDisableEnemyObjects();
            //if health has fallen below zero, deactivate it 
            gameObject.SetActive (false);
          //  StartCoroutine(ReSpawn());
        //  EnemyHealth.StartCoroutine(ReSpawn());
        }
    }

    IEnumerator ReSpawn()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(true);
    }
}