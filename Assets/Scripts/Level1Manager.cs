using UnityEngine;
using System.Collections;

public class Level1Manager : MonoBehaviour {

	public GameObject EnemySpawn;
	public GameObject PlayerSpawn1;
	public GameObject PlayerSpawn2;
	public GameObject InfantryPrefab;
	public GameObject SacredBandPrefab;
	public GameObject BowRiderPrefab;
	public GameObject safety;

	public GameObject victoryTextObj;

	private int friendliesSpawned;
	private int enemiesSpawned;
	public int friendliesSaved;
	private float time;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		time = Time.time;
		victoryTextObj.GetComponent<RectTransform>().localPosition = new Vector3(1000,1000,0);
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(friendliesSaved >= 10) {
			victoryTextObj.GetComponent<RectTransform>().localPosition = new Vector3(100,0,0);
			Invoke("destroy", 5.0f);
		}

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
		}
	}

	void destroy() {
		Destroy(this.gameObject);
	}
}
