using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health;
	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Destroy (gameObject);
	}
}
