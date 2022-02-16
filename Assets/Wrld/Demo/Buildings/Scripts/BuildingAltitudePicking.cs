using System.Collections;
using Wrld;
using Wrld.Space;
using UnityEngine;
using System.Collections.Generic;
public class BuildingAltitudePicking : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab = null;

    public LatLong[] enemyLocationOnBuildings;
    private LatLong cameraLocation = LatLong.FromDegrees(37.795641, -122.404173);
    private LatLong boxLocation1 = LatLong.FromDegrees(37.795159, -122.404336);
    private LatLong boxLocation2 = LatLong.FromDegrees(37.795173, -122.404229);

    public GameObject EnemyPool;
 //private LatLong boxLocation3 = LatLong.FromDegrees(37.895159, -122.404336);
 //   private LatLong boxLocation4 = LatLong.FromDegrees(17.795173, -152.404229);

    private void OnEnable()
    {
     //   enemyLocationOnBuildings = 
        StartCoroutine(Example());
    }

    private float a = 37.795159f;
    private float b = -122.404336f;
    private LatLong boxLocation12;
    IEnumerator Example()
    {
     
        
      //  Api.Instance.CameraApi.MoveTo(cameraLocation, distanceFromInterest: 400, headingDegrees: 0, tiltDegrees: 45);
      yield return new WaitForSeconds(5f);

     // while (true)
     // {
         for (int i = 0; i < enemyLocationOnBuildings.Length; i++)
         {
             yield return new WaitForSeconds(0.5f);
             // boxLocation12 = LatLong.FromDegrees(a, b);
                
                 MakeBox(enemyLocationOnBuildings[i]);
             //   MakeBox(enemyLocationOnBuildings[1]);

             //   MakeBox(boxLocation2);

             //   a = a - 0.000219f;
             //  b = b + 0.000119f;

             //  MakeBox(boxLocation12);
         }
   //  }
    }

    void MakeBox(LatLong latLong)
    {
     //   print("make box called"+latLong);

        var ray = Api.Instance.SpacesApi.LatLongToVerticallyDownRay(latLong);
        LatLongAltitude buildingIntersectionPoint;
        var didIntersectBuilding = Api.Instance.BuildingsApi.TryFindIntersectionWithBuilding(ray, out buildingIntersectionPoint);
        if (didIntersectBuilding)
        {
          //  print("enemy generated"+latLong);
            var boxAnchor = EnemyPool.GetComponent<ObjectPool>().GetPooledObject() as GameObject;
         //   print(boxAnchor.gameObject.name);
        //    var boxAnchor = Instantiate(boxPrefab) as GameObject;
          boxAnchor.SetActive(true);
          boxAnchor.GetComponent<GeographicTransform>().SetPosition(buildingIntersectionPoint.GetLatLong());

            var box = boxAnchor.transform.GetChild(0);
            box.localPosition = Vector3.up * (float)buildingIntersectionPoint.GetAltitude();
            
           // Destroy(boxAnchor, 2.0f);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
