using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   // public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects= new List<GameObject>();

    private bool isCoroutineRunning = false;
    void Awake()
    {
    //    SharedInstance = this;
    }

    private void OnEnable()        //Get All Child Objects
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            pooledObjects.Add(transform.GetChild(i).gameObject);
        }
    }

    public GameObject GetPooledObject()    //Return Unused Object if Available
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public void ActivateDisableEnemyObjects()
    {
        if (!isCoroutineRunning)     //Check if Activate Corutine is Already Running
        {
            StartCoroutine(ActivateEnemy());
        }
    }

    IEnumerator ActivateEnemy()
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(3f);  //initial Wait
        
        for(int i = 0; i < transform.childCount; i++)
        {
            if(!pooledObjects[i].transform.GetChild(0).GetChild(0).gameObject.activeInHierarchy)     //Check if Body of Enemy is Disbaled
            {
                yield return new WaitForSeconds(3f);
                pooledObjects[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(true);  //Activate Enemy Again
            }
        }
        isCoroutineRunning = false;

    }
}
