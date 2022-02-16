using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrld.Space;
public class moveon : MonoBehaviour
{
    float latitude = 37.7858f;
    float longitude = -122.401f;
    
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotateSpeed = 2f;
    
    [SerializeField]private float nextFire; 
    public float fireRate = 0.25f;                                        // Number in seconds which controls how often the player can fire
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible

    
    public GameObject BulletPool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.F) && Time.time > nextFire)
        {
            print("PLayer is FIring");
            nextFire = Time.time + fireRate;

            GameObject bullet = BulletPool.GetComponent<ObjectPool>().GetPooledObject();
            if (bullet != null)
            {
                print("buulet found");
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = this.transform.rotation;
                bullet.SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //   Wrld.SetOriginPoint(mylatitude+0.0001f,mylongitude+0.0001f,1781f);
            this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
          // latitude = latitude + 0.00011f;
          // longitude = longitude;
          // LatLongAltitude lla = new LatLongAltitude(latitude, longitude, 5);
          // Wrld.Api.Instance.SetOriginPoint(lla);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up, -rotateSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up, rotateSpeed);
        }
    
    }
    // Update is called once per frame
    void LateUpdate()
    {
     //   MovePlayer();
    }

    void MovePlayer()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0,
            Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
    }


}
