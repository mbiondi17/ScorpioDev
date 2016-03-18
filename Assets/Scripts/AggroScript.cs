using UnityEngine;
using System.Collections;

public class AggroScript : MonoBehaviour {

	public GameObject assignedUnit;

	// Use this for initialization
	void Start () {
		if (assignedUnit.GetComponent<EnemyUnit> ().isStatic) {
			GetComponent<SphereCollider>().radius = assignedUnit.GetComponent<EnemyUnit>().range;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!assignedUnit) {
			//Debug.Log("Destroyed");
			Destroy (gameObject);
		} 
	}

	void OnTriggerEnter(Collider co) {
		if (co.tag == "Player") {
			assignedUnit.GetComponent<EnemyUnit> ().target = co.gameObject;
			//Debug.Log ("Set target");
		}
	}

	void OnTriggerStay(Collider co) {
		if (assignedUnit.GetComponent<EnemyUnit> ().isStatic) {
			if (this.tag != "Objective") {
				if ((co.tag == "Player") && Time.time > assignedUnit.GetComponent<EnemyUnit> ().nextFire) {
					assignedUnit.GetComponent<EnemyUnit> ().nextFire = Time.time + 1 / assignedUnit.GetComponent<EnemyUnit> ().speed;
					healthBar health = co.GetComponentInChildren<healthBar> ();
					if (health) {
						int hit = Random.Range (0, 101);
						if (hit <= 100 - co.GetComponent<Unit> ().dex) {
							health.decrease (assignedUnit.GetComponent<EnemyUnit> ().attack);
						}
					}
					else {
						assignedUnit.GetComponent<EnemyUnit> ().target = null;
					}
				}
			}
		}
	}
}
