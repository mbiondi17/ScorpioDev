using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level2Manager : MonoBehaviour {

	public GameObject EnemySpawn1;
	public GameObject EnemySpawn2;
	public GameObject EnemySpawn3;
	public GameObject EnemySpawn4;
	public GameObject EnemySpawn5;
	public GameObject EnemySpawn6;
	public GameObject PlayerSpawn;
	public GameObject InfantryPrefab;
	public GameObject SacredBandPrefab;
	public GameObject BowRiderPrefab;
	public GameObject WarChariotPrefab;
	public GameObject ElephantPrefab;

	public GameObject victoryTextObj;

	private GameObject target;
	public Collider levelCollider;
	private float time;
	private float spawnTime;
	private bool phase1;
	private bool phase2;

	private GameManager gameManager;
	int enemies = 1; //1 enemy starts alive

	// Use this for initialization
	void Start () {
		time = Time.time;
		spawnTime = Time.time;
		victoryTextObj.GetComponent<RectTransform>().localPosition = new Vector3(1000,1000,0);
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("Time: " + spawnTime);
		if(enemies == 0) {
			victoryTextObj.GetComponent<RectTransform>().localPosition = new Vector3(100,0,0);
			Invoke("destroy", 5.0f);
		}
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			if (target != null) enemy.GetComponent<EnemyUnit> ().target = target;
		}
		if (Time.time > time && Time.time < 42.0f + time) {
			phase1 = true;
			phase2 = false;
		} else if (Time.time > 42.0f + time && Time.time < 63.0f + time) {
			phase1 = false;
			phase2 = true;
		}
		else if(Time.time > 63.0f) {
			phase1 = false;
			phase2 = false;
		}

		if (phase1) {
			if (Time.time >= 7.0f + spawnTime) {
				Instantiate (BowRiderPrefab, EnemySpawn1.transform.position, Quaternion.identity);
				enemies++;
				spawnTime = Time.time;
			}
		} else if (phase2) {
			if (Time.time >= 7.0f + spawnTime) {
				Instantiate (SacredBandPrefab, EnemySpawn1.transform.position, Quaternion.identity);
				enemies++;				
				spawnTime = Time.time;
			}
		}
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider co)
	{	
		if (co.tag == "Player") {
			target = co.gameObject;
		}
	}


	void destroy() {
		Destroy(this.gameObject);
	}

	public void EnemyDied() {
		enemies--;
	}
}
