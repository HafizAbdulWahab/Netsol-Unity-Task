using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField]private float moveSpeed = 500f;

	private Rigidbody rb;

	private GameObject target;  
	private Vector3 moveDirection;
	
	// Use this for initialization
	void OnEnable()
	{
		rb = GetComponent<Rigidbody>();
		target = GameObject.FindGameObjectWithTag("EnemyToFollow");   //Find Any Enemy
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector3(moveDirection.x, moveDirection.y,moveDirection.z);
		StartCoroutine(DisableMe());
	}

	IEnumerator DisableMe()      //Disable Bullet after some time if case it does not hit any enemy
	{
		yield return new WaitForSeconds(7f);
		if (gameObject.activeSelf)  //if Bullet is still active then disable it
		{
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter (Collider col)      //If Bullet Hit Enemy
	{
		if (col.gameObject.tag.Equals ("EnemyToFollow")) {
			col.GetComponent<EnemyHealth>().Damage(1);    //Call Damage Method
			gameObject.SetActive(false);  //Disable Bullet
		}
	}

}
