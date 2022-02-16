using System.Collections;
using Wrld;
using Wrld.Space;
using UnityEngine;
using System.Collections.Generic;
public class BuildingAltitudePicking : MonoBehaviour
{
    public LatLong[] enemyLocationOnBuildings;     //Enemy Fixed Locations
    
    public GameObject EnemyPool;// Enenmy Objects Pool
    private void OnEnable()
    {
     //   enemyLocationOnBuildings = 
        StartCoroutine(GenerateEnemyOnBuildings());
    }
    IEnumerator GenerateEnemyOnBuildings()   //CoRoutine to Generate All Enemy from Object Pool
    {
        yield return new WaitForSeconds(5f);  //Initial Wait for City/Buildings Generation

         for (int i = 0; i < enemyLocationOnBuildings.Length; i++)
         {
             yield return new WaitForSeconds(0.5f);
                
             MakeEnemy(enemyLocationOnBuildings[i]);
         }
    }

    void MakeEnemy(LatLong latLong)
    {
        var ray = Api.Instance.SpacesApi.LatLongToVerticallyDownRay(latLong);
        LatLongAltitude buildingIntersectionPoint;
        var didIntersectBuilding = Api.Instance.BuildingsApi.TryFindIntersectionWithBuilding(ray, out buildingIntersectionPoint);
        if (didIntersectBuilding)
        {
            var boxAnchor = EnemyPool.GetComponent<ObjectPool>().GetPooledObject();   //Get Unused Enemy from Pool
            boxAnchor.SetActive(true);
          boxAnchor.GetComponent<GeographicTransform>().SetPosition(buildingIntersectionPoint.GetLatLong());

            var box = boxAnchor.transform.GetChild(0);
            box.localPosition = Vector3.up * (float)buildingIntersectionPoint.GetAltitude();
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
