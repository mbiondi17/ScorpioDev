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
	public GameObject collider;
	private int enemiesLeft;
	private float time;
	private float spawnTime;
	private bool validTarget;
	private bool phase1;
	private bool phase2;
	private bool phase3;
	private bool phase4;

	private GameManager gameManager;
	List<GameObject> enemies = new List<GameObject>();

	// Use this for initialization
	void Start () {
		time = Time.time;
		spawnTime = Time.time;
		victoryTextObj.GetComponent<RectTransform>().localPosition = new Vector3(1000,1000,0);
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		enemies.AddRange(GameObject.FindGameObjectsWithTag ("Enemy"));
		enemiesLeft = enemies.Count;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("Time: " + spawnTime);
		if(enemiesLeft == 0) {
			victoryTextObj.GetComponent<RectTransform>().localPosition = new Vector3(100,0,0);
			Invoke("destroy", 5.0f);
		}
		enemies.AddRange(GameObject.FindGameObjectsWithTag ("Enemy"));
		enemiesLeft = enemies.Count;

		if (Time.time > time && Time.time < 45.0f + time) {
			Debug.Log ("In phase 1");
			phase1 = true;
			phase2 = false;
			phase3 = false;
			phase4 = false;
		} else if (Time.time > 45.0f + time && Time.time < 70.0f + time) {
			phase1 = false;
			phase2 = true;
			phase3 = false;
			phase4 = false;
		} else if (Time.time > 70.0f + time && Time.time < 200f + time) {
			phase1 = false;
			phase2 = false;
			phase3 = true;
			phase4 = false;
		} else if (Time.time > 200.0f + time) {
			phase1 = false;
			phase2 = false;
			phase3 = false;
			phase4 = true;
		}

		if (phase1) {
			if (Time.time >= 15.0f + spawnTime) {
				GameObject newEnemy = (GameObject)Instantiate (BowRiderPrefab, EnemySpawn1.transform.position, Quaternion.identity);
				GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
				GameObject closestPlayer = null;
				float closestDist = 9999999.0f;
				OnTriggerEnter(collider);
				if (validTarget) {
					closestPlayer = target;
				}/*
				foreach (GameObject unit in players) {
					float dist = Vector3.Distance (newEnemy.transform.position, unit.transform.position);
					if (OnTriggerEnter(co) && dist < closestDist) {
						closestDist = Vector3.Distance (newEnemy.transform.position, unit.transform.position);
						closestPlayer = unit;
					}

				}*/
				spawnTime = Time.time;

				if (closestPlayer != null) {
					newEnemy.GetComponent<EnemyUnit> ().target = closestPlayer;
				}

			}
		} else if (phase2) {
			if (Time.time >= 15.0f + spawnTime) {
				GameObject newEnemy = (GameObject)Instantiate (SacredBandPrefab, EnemySpawn1.transform.position, Quaternion.identity);
				newEnemy.GetComponent<NavMeshAgent> ().speed = 30;
				GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
				GameObject closestPlayer = null;
				float closestDist = 9999999.0f;
				foreach (GameObject unit in players) {
					if (validTarget && Vector3.Distance (newEnemy.transform.position, unit.transform.position) < closestDist) {
						closestDist = Vector3.Distance (newEnemy.transform.position, unit.transform.position);
						closestPlayer = unit;
					}
				}
				spawnTime = Time.time;

				if (closestPlayer != null) {
					newEnemy.GetComponent<EnemyUnit> ().target = closestPlayer;
				}
			}
		} else if (phase3) {
			if (Time.time >= 15.0f + spawnTime) {
				GameObject newEnemy = (GameObject)Instantiate (WarChariotPrefab, EnemySpawn1.transform.position, Quaternion.identity);
				GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
				GameObject closestPlayer = null;
				float closestDist = 9999999.0f;
				foreach (GameObject unit in players) {
					float dist = Vector3.Distance (newEnemy.transform.position, unit.transform.position);
					if (dist < 500f && dist < closestDist) {
						closestDist = Vector3.Distance (newEnemy.transform.position, unit.transform.position);
						closestPlayer = unit;
					}
				}
				if (closestPlayer != null) {
					newEnemy.GetComponent<EnemyUnit> ().target = closestPlayer;
				}
				spawnTime = Time.time;

			}
		} else if (phase4) {
			if (Time.time >= 15.0f + spawnTime) {
				GameObject newEnemy = (GameObject)Instantiate (ElephantPrefab, EnemySpawn1.transform.position, Quaternion.identity);
				GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
				GameObject closestPlayer = null;
				float closestDist = 9999999.0f;
				foreach (GameObject unit in players) {
					float dist = Vector3.Distance (newEnemy.transform.position, unit.transform.position);
					if (dist < 500f && dist < closestDist) {
						closestDist = Vector3.Distance (newEnemy.transform.position, unit.transform.position);
						closestPlayer = unit;
					}
				}
				if (closestPlayer != null) {
					newEnemy.GetComponent<EnemyUnit> ().target = closestPlayer;
				}
				spawnTime = Time.time;

			}
		}
		/*
		if(Time.time >= 5.0f + time) {

			if(enemiesSpawned < 15 && friendliesSpawned < 15) {
				if(friendliesSpawned % 2 == 0) {
					GameObject newFriendly = (GameObject)Instantiate(InfantryPrefab, PlayerSpawn1.transform.position, Quaternion.identity);
					newFriendly.GetComponent<Unit>().attack = gameManager.infAttack;
					newFriendly.GetComponent<Unit>().dex = gameManager.infDex;
					newFriendly.GetComponent<Unit>().range = gameManager.infRange;
					newFriendly.GetComponent<Unit>().health = gameManager.infHealth;
					newFriendly.GetComponent<Unit>().speed = gameManager.infSpeed;
					newFriendly.GetComponent<Unit>().isRunning = true;
					newFriendly.GetComponent<Unit>().target = safety;
					newFriendly.GetComponent<Unit>().setNavMeshTarget();
					friendliesSpawned++;
				}
				else {
					GameObject newFriendly = (GameObject)Instantiate(InfantryPrefab, PlayerSpawn2.transform.position, Quaternion.identity);
					newFriendly.GetComponent<Unit>().attack = gameManager.infAttack;
					newFriendly.GetComponent<Unit>().dex = gameManager.infDex;
					newFriendly.GetComponent<Unit>().range = gameManager.infRange;
					newFriendly.GetComponent<Unit>().health = gameManager.infHealth;
					newFriendly.GetComponent<Unit>().speed = gameManager.infSpeed;
					newFriendly.GetComponent<Unit>().isRunning = true;
					newFriendly.GetComponent<Unit>().target = safety;
					newFriendly.GetComponent<Unit>().setNavMeshTarget();
					friendliesSpawned++;
				}

				float check = Random.Range(1,101);
				if(check < 10) {
					GameObject newEnemy = (GameObject)Instantiate(BowRiderPrefab, EnemySpawn.transform.position, Quaternion.identity);
					GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
					GameObject closestPlayer = null;
					float closestDist = 9999999.0f;
					foreach(GameObject unit in players) {
						if(Vector3.Distance(newEnemy.transform.position, unit.transform.position) < closestDist) {
							closestDist = Vector3.Distance(newEnemy.transform.position, unit.transform.position);
							closestPlayer = unit;
						}
					}
					if(closestPlayer != null) {
						newEnemy.GetComponent<EnemyUnit>().target = closestPlayer;
					}
					else {
						newEnemy.GetComponent<EnemyUnit>().target = safety;
					}
					enemiesSpawned++;
				}
				else {
					GameObject newEnemy = (GameObject)Instantiate(SacredBandPrefab, EnemySpawn.transform.position, Quaternion.identity);
					newEnemy.GetComponent<NavMeshAgent>().speed = 30;
					GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
					GameObject closestPlayer = null;
					float closestDist = 9999999.0f;
					foreach(GameObject unit in players) {
						if(Vector3.Distance(newEnemy.transform.position, unit.transform.position) < closestDist) {
							closestDist = Vector3.Distance(newEnemy.transform.position, unit.transform.position);
							closestPlayer = unit;
						}
					}
					if(closestPlayer != null) {
						newEnemy.GetComponent<EnemyUnit>().target = closestPlayer;
					}
					else {
						newEnemy.GetComponent<EnemyUnit>().target = safety;
					}
					enemiesSpawned++;
				}
			}

			time = Time.time;
		}*/
	}
	void OnTriggerEnter(Collider co) {
		if (co.tag == "Player") {
			validTarget = true;
			target = co.gameObject;
		}
	}


	void destroy() {
		Destroy(this.gameObject);
	}
}
