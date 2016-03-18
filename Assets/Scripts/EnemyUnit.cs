using UnityEngine;
using System.Collections;

public class EnemyUnit : MonoBehaviour {
	
	public GameObject target = null;
	public GameObject bulletPrefab;

	public int health = 15;
	public int attack = 2; 
	public int dex = 15;
	public float range = 5.0f;
	public int speed = 1;

	public bool isStatic = false;

	public float nextFire = 0.0f;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && !isStatic) {
			GetComponent<NavMeshAgent> ().destination = target.transform.position;
		} 
	}

	
	void OnTriggerStay(Collider co) {
		if (this.tag != "Objective") {
			if ((co.tag == "Player") && Time.time > nextFire) {
				GetComponent<NavMeshAgent>().destination = GetComponent<Transform>().position;
				nextFire = Time.time + 1 / speed;
				healthBar health = co.GetComponentInChildren<healthBar> ();
				if (health) {
					int hit = Random.Range (0, 101);
					if (hit <= 100 - co.GetComponent<Unit> ().dex) {
						health.decrease (attack);
					}
				}
				else {
					target = null;
				}
			}
		}
	}


}
