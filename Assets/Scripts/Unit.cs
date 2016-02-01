using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public GameObject target = null;
	public GameManager gameManager;
	//public GameObject bulletPrefab;

	public float roundsPerSecond = 1;
	public float nextFire = 0.0f;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (target);
	}

	public void setNavMeshTarget() {
		if(target != null) {
			this.GetComponent<NavMeshAgent>().destination = target.transform.position;
		}
	}

	public void OnMouseDown() {
		//Debug.Log ("I am Clicked");
		if (gameManager.selectedUnit == this.gameObject)
			gameManager.selectedUnit = null;
		else {
			gameManager.selectedUnit = this.gameObject;
		}
	}

	void OnTriggerStay(Collider co) {
		/*
Objective can never attack
Armor and artillery can only attack if the other collider is tagged as a Wall
Otherwise, a unit can only attack something tagged as an "Enemy" or an "Objective"
		 */
		if(this.tag != "Objective") {
			if (
				(((this.name.Contains("Armor") || this.name.Contains("Artillery")) && co.tag == "Wall")
				||
				(this.name.Contains("Infantry") && (co.tag == "Enemy" || co.tag == "Objective")))
				&& 
				Time.time > nextFire
				) {
				//Debug.Log("we did it: stay " + this.name);
				//Vector3 bulletPos = new Vector3(this.transform.position.x + 0.2f, this.transform.position.y, this.transform.position.z);
				nextFire = Time.time + 1/roundsPerSecond;
				healthBar health = co.GetComponentInChildren<healthBar>();
				if(health) 
				{
					health.decrease();
				}
//				GameObject g = (GameObject)Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
//				g.GetComponent<Bullet>().target = co.transform;
				
			}
		}
			
	}
//	
//	void OnTriggerEnter(Collider co) {
//		if(this.tag != "Objective") {
//			if (
//				((this.name.Contains("Armor") || this.name.Contains("Artillery")) && co.tag == "Wall")
//				||
//				(this.name.Contains("Infantry") && (co.tag == "Enemy" || co.tag == "Objective"))
//				&& 
//				Time.time > nextFire
//				) {
//				Debug.Log("we did it: enter " + this.name);
//
//				Vector3 bulletPos = new Vector3(this.transform.position.x + 0.2f, this.transform.position.y, this.transform.position.z);
//				nextFire = Time.time + 1/roundsPerSecond;
//				GameObject g = (GameObject)Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
//				g.GetComponent<Bullet>().target = co.transform;
//			
//			}
//		}
//	}
//	
//	void OnTriggerExit(Collider co) {
//		if(this.tag != "Objective") {
//			if (
//				((this.name.Contains("Armor") || this.name.Contains("Artillery")) && co.tag == "Wall")
//				||
//				(this.name.Contains("Infantry") && (co.tag == "Enemy" || co.tag == "Objective"))
//				&& 
//				Time.time > nextFire
//				) {
//				Debug.Log("we did it: exit " + this.name);
//
//				Vector3 bulletPos = new Vector3(this.transform.position.x + 0.2f, this.transform.position.y, this.transform.position.z);
//				nextFire = Time.time + 1/roundsPerSecond;
//				GameObject g = (GameObject)Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
//				g.GetComponent<Bullet>().target = co.transform;
//				
//			}
//		}
//		
//	}

}
