using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float moveSpeed = 507f;

	private Rigidbody rb;

	private GameObject target;
	private Vector3 moveDirection;
	
	// Use this for initialization
	void OnEnable()
	{
		rb = GetComponent<Rigidbody>();
		target = GameObject.FindGameObjectWithTag("EnemyToFollow");
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector3(moveDirection.x, moveDirection.y,moveDirection.z);
		//Destroy (gameObject, 3f);
		StartCoroutine(DisableMe());
	}

	IEnumerator DisableMe()
	{
		yield return new WaitForSeconds(7f);
		if (gameObject.activeSelf)
		{
		//	ObjectPoolInstance.GetComponent<ObjectPool>().ActivateDisableEnemyObjects();
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag.Equals ("EnemyToFollow")) {
		//	Debug.Log ("Hit!"+col.gameObject.name);
			//Destroy (gameObject);
			col.GetComponent<EnemyHealth>().Damage(3);
			gameObject.SetActive(false);
		}
	}

}
