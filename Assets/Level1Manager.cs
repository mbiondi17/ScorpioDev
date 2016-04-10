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

	private int friendliesSpawned;
	private int enemiesSpawned;
	private float time;

	// Use this for initialization
	void Start () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.time >= 5.0f + time) {

			if(enemiesSpawned < 15 && friendliesSpawned < 15) {
				if(friendliesSpawned % 2 == 0) {
					GameObject newFriendly = (GameObject)Instantiate(InfantryPrefab, PlayerSpawn1.transform.position, Quaternion.identity);
					newFriendly.GetComponent<Unit>().target = safety;
					newFriendly.GetComponent<Unit>().setNavMeshTarget();
					friendliesSpawned++;
				}
				else {
					GameObject newFriendly = (GameObject)Instantiate(InfantryPrefab, PlayerSpawn2.transform.position, Quaternion.identity);
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
}
