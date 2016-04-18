using UnityEngine;
using System.Collections;

public class RangeScript : MonoBehaviour {

	public GameObject assignedUnit;

	// Use this for initialization
	void Start () {
		GetComponent<SphereCollider> ().radius = assignedUnit.GetComponent<Unit> ().range;	
	}
	
	// Update is called once per frame
	void Update () {
		if (!assignedUnit) {
			//Debug.Log("Destroyed");
			Destroy (gameObject);
		} 
	}

	void OnTriggerStay(Collider co) {

		if (((assignedUnit.GetComponent<Unit> ().name.Contains("Infantry") ||  assignedUnit.GetComponent<Unit> ().name.Contains("Archer"))
		     && co.tag == "Enemy")
		    && Time.time > assignedUnit.GetComponent<Unit> ().nextFire) {

			GetComponentInParent<Unit>().superAnimu.SetBool ("Attack", true);

			assignedUnit.GetComponent<Unit> ().nextFire = Time.time + 1/assignedUnit.GetComponent<Unit> ().speed;
			healthBar health = co.GetComponentInChildren<healthBar>();
			assignedUnit.GetComponent<NavMeshAgent>().destination = assignedUnit.GetComponent<Transform>().position;
			if(health) 
			{
				int hit = Random.Range(0, 101);
				if(co.tag != "Objective") {
					if(hit <= 100 - co.GetComponent<EnemyUnit>().dex) {
						assignedUnit.GetComponent<Unit> ().GetComponents<AudioSource>()[0].PlayOneShot (assignedUnit.GetComponent<Unit> ().hitClip);
						health.decrease(assignedUnit.GetComponent<Unit> ().attack);
					}
					else {
						assignedUnit.GetComponent<Unit> ().GetComponents<AudioSource>()[1].PlayOneShot (assignedUnit.GetComponent<Unit> ().missClip);
					}
				}
				else {
					assignedUnit.GetComponent<Unit> ().GetComponents<AudioSource>()[0].PlayOneShot(assignedUnit.GetComponent<Unit> ().hitClip);
					health.decrease (assignedUnit.GetComponent<Unit> ().attack);
				}
				
			}
			else {
				assignedUnit.GetComponent<Unit> ().target = null;
				GetComponentInParent<Unit>().superAnimu.SetBool ("Attack", false);
			}
			
			
		}
		else if(((assignedUnit.name.Contains("Armor") 
		          || assignedUnit.name.Contains("Artillery")) 
		         && co.gameObject == assignedUnit.GetComponent<Unit> ().target) && Time.time > assignedUnit.GetComponent<Unit> ().nextFire) {

			assignedUnit.GetComponent<Unit> ().nextFire = Time.time + 1/(assignedUnit.GetComponent<Unit> ().speed);
			assignedUnit.GetComponent<NavMeshAgent>().destination = assignedUnit.GetComponent<Transform>().position;
			//Debug.Log("We're here!");
			if(co.GetComponentInParent<Renderer>().material.mainTexture == assignedUnit.GetComponent<Unit> ().woodMaterials[0].mainTexture) {
				co.GetComponentInParent<Renderer>().material = assignedUnit.GetComponent<Unit> ().woodMaterials[1];
			}
			else if(co.GetComponentInParent<Renderer>().material.mainTexture == assignedUnit.GetComponent<Unit> ().woodMaterials[1].mainTexture) {
				co.GetComponentInParent<Renderer>().material = assignedUnit.GetComponent<Unit> ().woodMaterials[2];
			}
			else if(co.GetComponentInParent<Renderer>().material.mainTexture == assignedUnit.GetComponent<Unit> ().woodMaterials[2].mainTexture) {
				co.GetComponentInParent<Renderer>().material = assignedUnit.GetComponent<Unit> ().woodMaterials[3];
			}
			else if(co.GetComponentInParent<Renderer>().material.mainTexture == assignedUnit.GetComponent<Unit> ().brickMaterials[0].mainTexture) {
				co.GetComponentInParent<Renderer>().material = assignedUnit.GetComponent<Unit> ().brickMaterials[1];
			}
			else if(co.GetComponentInParent<Renderer>().material.mainTexture == assignedUnit.GetComponent<Unit> ().brickMaterials[1].mainTexture) {
				co.GetComponentInParent<Renderer>().material = assignedUnit.GetComponent<Unit> ().brickMaterials[2];
			}
			else if(co.GetComponentInParent<Renderer>().material.mainTexture == assignedUnit.GetComponent<Unit> ().brickMaterials[2].mainTexture) {
				co.GetComponentInParent<Renderer>().material = assignedUnit.GetComponent<Unit> ().brickMaterials[3];
			}
			else {
				Destroy(co.gameObject);
				assignedUnit.GetComponent<Unit> ().target = null;
			}
		}
	}
}
