using UnityEngine;
using System.Collections;

public class EnemyUnit : MonoBehaviour {
	
	public GameObject target = null;
	public GameObject bulletPrefab;
	
	public float roundsPerSecond = 1;
	public float nextFire = 0.0f;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (target);
	}

	
	void OnTriggerStay(Collider co) {
		if(this.tag != "Objective"){
			if ((co.tag == "Player") && Time.time > nextFire) {
				nextFire = Time.time + 1/roundsPerSecond;
				healthBar health = co.GetComponentInChildren<healthBar>();
				if(health) 
				{
					health.decrease();
				}
				//GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
				//g.GetComponent<Bullet>().target = co.transform;
				
			}
		}
		
	}
//	
//	void OnTriggerEnter(Collider co) {
//		if(this.tag != "Objective"){
//			if ((co.tag == "Player") && Time.time > nextFire) {
//				nextFire = Time.time + 1/roundsPerSecond;
//				GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
//				g.GetComponent<Bullet>().target = co.transform;
//				
//			}
//		}
//	}
//	
//	void OnTriggerExit(Collider co) {
//		if(this.tag != "Objective"){
//			if ((co.tag == "Player") && Time.time > nextFire) {
//				nextFire = Time.time + 1/roundsPerSecond;
//				GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
//				g.GetComponent<Bullet>().target = co.transform;
//				
//			}
//		}
//	}
	
}
