using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BulletFollowEnemy : MonoBehaviour
{
    Rigidbody rb;
 
    public float speed = 1f;
 
    private Transform target;
 
    private float moveSpeedFollow = 1f;
    public float rotateSpeed = 200f;

    private GameObject respawns;
 
    public float MoveSpeed5 = 1f;
    private float startTime,journeyLength;
    private bool search = false;
    private void OnEnable()
    {
     //   StartCoroutine(bullet());   
     Search();
    }

    IEnumerator bullet()
    {
         yield return new WaitForSeconds(10f);
         Search();
        // yield return new WaitForSeconds(2f);
        //
         search = true;
       
    }
    
    void Search()
    {
        rb = GetComponent<Rigidbody>();
 
        startTime = Time.time;
        if (GameObject.FindGameObjectWithTag("EnemyToFollow") != null)
        {
            respawns = GameObject.FindGameObjectWithTag("EnemyToFollow");
            search = true;
        }

        // Calculate the journey length.
        journeyLength = Vector3.Distance(this.transform.position,respawns.gameObject.transform.position);
 
    }
 
    // Update is called once per frame
    void Update()
    {
        
        if (search)
        {
            print("following the enemy");
            search = true;
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(this.transform.position, respawns.gameObject.transform.position, fractionOfJourney);

        }
    }
     
 
}