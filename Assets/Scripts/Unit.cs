using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public GameObject target = null;
	public Vector3 targetPoint = new Vector3(0,0,0);
	public GameManager gameManager;

	public float roundsPerSecond = 1;
	public float nextFire = 0.0f;

	public int health = 10;
	public int attack = 2; 
	public int dex = 15;
	public float range = 5.0f;
	public float speed = 1;

	public AudioSource[] audio;
	public AudioClip hitClip;
	public AudioClip missClip;

	public Material[] woodMaterials = new Material[4];
	public Material[] brickMaterials = new Material[4];

	private int on = 0;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		audio = GetComponentsInParent<AudioSource>();
		hitClip = audio [0].clip;
		missClip = audio [1].clip;

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

}

