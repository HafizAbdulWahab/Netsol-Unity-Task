using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   // public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects= new List<GameObject>();
    void Awake()
    {
    //    SharedInstance = this;
    }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            pooledObjects.Add(transform.GetChild(i).gameObject);
        }
    }

    public GameObject GetPooledObject()
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
        StartCoroutine(ActivateEnemy());
    }

    IEnumerator ActivateEnemy()
    {
        // print("transform name "+transform.name);
        // print("transform child "+transform.childCount);
           yield return new WaitForSeconds(2f);

//print("child name "+transform.GetChild(0).GetChild(0).GetChild(0).name);
        for(int i = 0; i < transform.childCount; i++)
        { 
            print("child name 2 "+pooledObjects[i].transform.GetChild(0).GetChild(0).name);

            if(!pooledObjects[i].transform.GetChild(0).GetChild(0).gameObject.activeInHierarchy)
            {
                print("child name 3"+pooledObjects[i].transform.GetChild(0).GetChild(0).name);

                yield return new WaitForSeconds(3f);
                pooledObjects[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
             //   print("name of atviating enemy"+pooledObjects[i].name);
            
            }
        }

        yield return new WaitForSeconds(0.1f);
    }
    void Start()
    {
        /*pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }*/
    }
// Update is called once per frame
    void Update()
    {
        
    }
}
