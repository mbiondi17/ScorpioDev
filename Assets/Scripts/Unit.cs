using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public GameObject target = null;
	public Vector3 targetPoint = new Vector3(0,0,0);
	public GameManager gameManager;

	public float roundsPerSecond = 1;
	public float nextFire = 0.0f;


	public Material[] woodMaterials = new Material[4];
	public Material[] brickMaterials = new Material[4];

	private int on = 0;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

		if (gameManager.selectedUnits.Contains(this.gameObject)) {
			if (on == 0) {
				this.GetComponentInParent<healthBar>().GetComponentInChildren<healthBar>().m_FullHealthColor = Color.blue;
				this.GetComponentInParent<healthBar>().Invoke("SetHealthUI", 0.0f);
				on = 1;
			}
		} else {
			if(on == 1) {
				this.GetComponentInParent<healthBar>().GetComponentInChildren<healthBar>().m_FullHealthColor = Color.green;
				this.GetComponentInParent<healthBar>().Invoke("SetHealthUI", 0.0f);
				on = 0;
			}
		}

	}

	public void setNavMeshTarget() {
		if(target != null) {
			this.GetComponent<NavMeshAgent>().destination = target.transform.position;
		}
		else if(targetPoint != new Vector3(0,0,0)) {
			this.GetComponent<NavMeshAgent>().destination = targetPoint;
		}
	}

	public void OnMouseDown() {
		//Debug.Log ("I am Clicked");
		gameManager.selectedUnits.Add(this.gameObject);
		//Debug.Log (gameManager.selectedUnit.name);
	}

	/*
Objective can never attack
Armor and artillery can only attack if the other collider is tagged as a Wall
Otherwise, a unit can only attack something tagged as an "Enemy" or an "Objective"
		 */
	
	void OnTriggerStay(Collider co) {
		if ((this.name.Contains("Infantry") 
		    && (co.tag == "Enemy" || co.tag == "Objective"))
			&& Time.time > nextFire) {
			//Debug.Log("we did it " + this.name);
			nextFire = Time.time + 1/roundsPerSecond;
			healthBar health = co.GetComponentInChildren<healthBar>();
			if(health) 
			{
				health.decrease();
			}
			else {
				this.target = null;
			}

			
		}
		else if(((this.name.Contains("Armor") || this.name.Contains("Artillery")) && co.tag == "Wall") && Time.time > nextFire) {
			nextFire = Time.time + 1/roundsPerSecond;
			//Debug.Log("We're here!");
			if(co.GetComponentInParent<Renderer>().material.mainTexture == woodMaterials[0].mainTexture) {
				co.GetComponentInParent<Renderer>().material = woodMaterials[1];
			}
			else if(co.GetComponentInParent<Renderer>().material.mainTexture == woodMaterials[1].mainTexture) {
				co.GetComponentInParent<Renderer>().material = woodMaterials[2];
			}
			else if(co.GetComponentInParent<Renderer>().material.mainTexture == woodMaterials[2].mainTexture) {
				co.GetComponentInParent<Renderer>().material = woodMaterials[3];
			}
			else if(co.GetComponentInParent<Renderer>().material.mainTexture == brickMaterials[0].mainTexture) {
				co.GetComponentInParent<Renderer>().material = brickMaterials[1];
			}
			else if(co.GetComponentInParent<Renderer>().material.mainTexture == brickMaterials[1].mainTexture) {
				co.GetComponentInParent<Renderer>().material = brickMaterials[2];
			}
			else if(co.GetComponentInParent<Renderer>().material.mainTexture == brickMaterials[2].mainTexture) {
				co.GetComponentInParent<Renderer>().material = brickMaterials[3];
			}
			else {
				Destroy(co.gameObject);
				this.target = null;
			}
		}
	}
}

