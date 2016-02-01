using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 10;
	public Transform target;

	// Update is called once per frame
	void FixedUpdate () 
	{

		if(target != null) 
		{
			Vector3 dir = target.position - transform.position;
			GetComponent<Rigidbody>().velocity = dir.normalized*speed;
		}
		else 
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter (Collider other) 
	{

		healthBar health = other.GetComponentInChildren<healthBar>();
		if(health) 
		{
			health.decrease();
			Destroy(gameObject);
		}
	}
}
