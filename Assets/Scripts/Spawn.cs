using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject infantryPrefab;
	public GameObject armorPrefab;
	public GameObject artilleryPrefab;
	public GameObject archerPrefab;

	public Button infButton;
	public Button armButton;
	public Button artButton;
	public Button archButton;


	public int infLeft = 5;
	public int armLeft = 1;
	public int artLeft = 1;
	public int archLeft = 1;

	public GameManager gameManager;
	public GameObject newUnit = null;
	public bool targetFound = false;

	public bool isPaused = false;
	
	void Start(){
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		infButton.GetComponentInChildren<Text>().text = "Infantry -- Left: " + infLeft;
		archButton.GetComponentInChildren<Text>().text = "Archers -- Left: " + archLeft;
		armButton.GetComponentInChildren<Text>().text = "Armor -- Left: " + armLeft;
		artButton.GetComponentInChildren<Text>().text = "Artillery -- Left: " + artLeft;
		
	}

	void Update() 
	{
		isPaused = gameManager.getPaused ();
	}


	public void SpawnInfantry() {
		if (infLeft > 0 && !isPaused) {
			newUnit = (GameObject)Instantiate (infantryPrefab, new Vector3 (
			GetComponentInParent<Transform> ().position.x,
	        GetComponentInParent<Transform> ().position.y,
		    GetComponentInParent<Transform> ().position.z),
		    Quaternion.identity);
			gameManager.GetComponent<GameManager> ().selectedUnits.Clear ();
			gameManager.GetComponent<GameManager> ().selectedUnits.Add(newUnit);
			infLeft--;
			infButton.GetComponentInChildren<Text>().text = "Infantry -- Left: " + infLeft;
			//Level of spawned unit
			if (gameManager.upgradeLevelInfantry == 1) {
				newUnit.GetComponent<Unit>().health = 2;
				newUnit.GetComponent<Unit> ().attack = 1;
				newUnit.GetComponent<Unit> ().dex = 10;
				newUnit.GetComponent<Unit>().speed = 4;
				newUnit.GetComponent<Unit> ().range = 6;
			} else if (gameManager.upgradeLevelInfantry == 2) {
				newUnit.GetComponent<Unit>().health = 4;
				newUnit.GetComponent<Unit> ().attack = 1;
				newUnit.GetComponent<Unit> ().dex = 15;
				newUnit.GetComponent<Unit>().speed = 5;
				newUnit.GetComponent<Unit> ().range = 6;
			} else if (gameManager.upgradeLevelInfantry == 3) {
				newUnit.GetComponent<Unit>().health = 4;
				newUnit.GetComponent<Unit> ().attack = 3;
				newUnit.GetComponent<Unit> ().dex = 15;
				newUnit.GetComponent<Unit>().speed = 6;
				newUnit.GetComponent<Unit> ().range = 6;
			} else if (gameManager.upgradeLevelInfantry == 4) {
				newUnit.GetComponent<Unit>().health = 5;
				newUnit.GetComponent<Unit> ().attack = 5;
				newUnit.GetComponent<Unit> ().dex = 25;
				newUnit.GetComponent<Unit>().speed = 7;
				newUnit.GetComponent<Unit> ().range = 6;
			}

		}
	}

	public void SpawnArcher() {
		if (archLeft > 0 && !isPaused) {
			newUnit = (GameObject)Instantiate (archerPrefab, new Vector3 (
				GetComponentInParent<Transform> ().position.x,
				GetComponentInParent<Transform> ().position.y,
				GetComponentInParent<Transform> ().position.z),
			                                   Quaternion.identity);
			gameManager.GetComponent<GameManager> ().selectedUnits.Clear ();
			gameManager.GetComponent<GameManager> ().selectedUnits.Add(newUnit);
			archLeft--;
			archButton.GetComponentInChildren<Text>().text = "Archers -- Left: " + archLeft;
		if (gameManager.upgradeLevelArchers == 1) {
				newUnit.GetComponent<Unit>().health = 1;
				newUnit.GetComponent<Unit> ().attack = 1;
				newUnit.GetComponent<Unit> ().dex = 15;
				newUnit.GetComponent<Unit>().speed = 5;
				newUnit.GetComponent<Unit> ().range = 10;
			}


		}
	}

	public void SpawnArmor() {
		if (armLeft > 0 && !isPaused) {
			newUnit = (GameObject)Instantiate (armorPrefab, new Vector3 (
			GetComponentInParent<Transform> ().position.x,
			GetComponentInParent<Transform> ().position.y,
			GetComponentInParent<Transform> ().position.z), Quaternion.identity);
			gameManager.GetComponent<GameManager> ().selectedUnits.Clear ();
			gameManager.GetComponent<GameManager> ().selectedUnits.Add(newUnit);
			armLeft--;
			armButton.GetComponentInChildren<Text>().text = "Armor -- Left: " + armLeft;

			if (gameManager.upgradeLevelArmor == 1) {
				//Stationary targets only
				newUnit.GetComponent<Unit>().health = 5;
				newUnit.GetComponent<Unit> ().attack = 10;
				newUnit.GetComponent<Unit> ().dex = 0;
				newUnit.GetComponent<Unit>().speed = 4;
				newUnit.GetComponent<Unit> ().range = 5;

			} else if (gameManager.upgradeLevelArmor == 2) {
				newUnit.GetComponent<Unit>().health = 10;
				newUnit.GetComponent<Unit> ().attack = 15;
				newUnit.GetComponent<Unit> ().dex = 0;
				newUnit.GetComponent<Unit>().speed = 2;
				newUnit.GetComponent<Unit> ().range = 5;

			} else if (gameManager.upgradeLevelArmor == 3) {
				newUnit.GetComponent<Unit>().health = 15;
				newUnit.GetComponent<Unit> ().attack = 15;
				newUnit.GetComponent<Unit> ().dex = 0;
				newUnit.GetComponent<Unit>().speed = 3;
				newUnit.GetComponent<Unit> ().range = 5;

			} 

		}
	}

	public void SpawnArtillery() {
		if (artLeft > 0 && !isPaused) {
			newUnit = (GameObject)Instantiate (artilleryPrefab, new Vector3 (
			GetComponentInParent<Transform> ().position.x,
			(GetComponentInParent<Transform> ().position.y + 0.5f),
			GetComponentInParent<Transform> ().position.z), Quaternion.identity);
			gameManager.GetComponent<GameManager> ().selectedUnits.Clear ();
			gameManager.GetComponent<GameManager> ().selectedUnits.Add(newUnit);
			artLeft--;
			artButton.GetComponentInChildren<Text>().text = "Artillery -- Left: " + artLeft;
			if (gameManager.upgradeLevelArtillery == 1) {
				newUnit.GetComponent<Unit>().health = 4;
				newUnit.GetComponent<Unit> ().attack = 2;
				newUnit.GetComponent<Unit> ().dex = 0;
				newUnit.GetComponent<Unit>().speed = 3;
				newUnit.GetComponent<Unit> ().range = 40;

			} else if (gameManager.upgradeLevelArtillery == 2) {
				newUnit.GetComponent<Unit>().health = 4;
				newUnit.GetComponent<Unit> ().attack = 4;
				newUnit.GetComponent<Unit> ().dex = 0;
				newUnit.GetComponent<Unit>().speed = 3;
				newUnit.GetComponent<Unit> ().range = 40;

			} else if (gameManager.upgradeLevelArtillery == 3) {
				newUnit.GetComponent<Unit>().health = 4;
				newUnit.GetComponent<Unit> ().attack = 4;
				newUnit.GetComponent<Unit> ().dex = 0;
				newUnit.GetComponent<Unit>().speed = 3;
				newUnit.GetComponent<Unit> ().range = 43;

			} else if (gameManager.upgradeLevelArtillery == 4) {
				newUnit.GetComponent<Unit>().health = 4;
				newUnit.GetComponent<Unit> ().attack = 4;
				newUnit.GetComponent<Unit> ().dex = 0;
				newUnit.GetComponent<Unit>().speed = 3;
				newUnit.GetComponent<Unit> ().range = 43;
				//stationary units
			} else if (gameManager.upgradeLevelArtillery == 5) {
				newUnit.GetComponent<Unit>().health = 4;
				newUnit.GetComponent<Unit> ().attack = 5;
				newUnit.GetComponent<Unit> ().dex = 0;
				newUnit.GetComponent<Unit>().speed = 3;
				newUnit.GetComponent<Unit> ().range = 43;

			} else if (gameManager.upgradeLevelArtillery == 6) {
				newUnit.GetComponent<Unit>().health = 4;
				newUnit.GetComponent<Unit> ().attack = 5;
				newUnit.GetComponent<Unit> ().dex = 0;
				newUnit.GetComponent<Unit>().speed = 3;
				newUnit.GetComponent<Unit> ().range = 45;

			} else if (gameManager.upgradeLevelArtillery == 7) {
				newUnit.GetComponent<Unit>().health = 4;
				newUnit.GetComponent<Unit> ().attack = 6;
				newUnit.GetComponent<Unit> ().dex = 0;
				newUnit.GetComponent<Unit>().speed = 3;
				newUnit.GetComponent<Unit> ().range = 45;

			}

		}
	}	

	public GameObject findClosestSpawn() {
		return GameObject.Find("Spawn1");
	}



}
