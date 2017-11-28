using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level1Manager : MonoBehaviour {

	public GameObject EnemySpawn;
	public GameObject PlayerSpawn1;
	public GameObject PlayerSpawn2;
	public GameObject InfantryPrefab;
	public GameObject SacredBandPrefab;
	public GameObject BowRiderPrefab;
	public GameObject safety;
	public float timeLimit;

	public GameObject victoryTextObj;
	public GameObject defeatTextObj;

	private int friendliesSpawned;
	private int enemiesSpawned;
	public int friendliesSaved;
	private float time;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		time = Time.timeSinceLevelLoad;
		victoryTextObj.GetComponent<RectTransform>().localPosition = new Vector3(1000,1000,0);
		defeatTextObj.GetComponent<RectTransform>().localPosition = new Vector3(1000,1000,0);		
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		if( timeLimit < 110.0f) timeLimit = 110.0f; // 15 (spawn occurrences) * 5 (time between spawns) = 75, + 5 (start time) = 80, + 30 for travel to spawn.
	}	
	
	// Update is called once per frame
	void Update () {

		if(friendliesSaved >= 8) {
			victoryTextObj.GetComponent<RectTransform>().localPosition = new Vector3(100,0,0);
			Invoke("destroy", 5.0f);
		}

		if(Time.timeSinceLevelLoad >= 5.0f + time) {

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
					newEnemy.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 30;
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

			time = Time.timeSinceLevelLoad;
		}
		if(Time.timeSinceLevelLoad > timeLimit) {
			defeatTextObj.GetComponent<RectTransform>().localPosition = new Vector3(100,0,0);
			Invoke("restart", 5.0f);
		}
	}

	void destroy() {
		Destroy(this.gameObject);
	}

	void restart() {
		SceneManager.LoadScene("Barracks");
	}
}
