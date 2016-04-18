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

			//Set stats of spawned unit with proper stats from GameManager
			newUnit.GetComponent<Unit>().health = gameManager.GetComponent<GameManager> ().infHealth;
			newUnit.GetComponent<Unit> ().attack = gameManager.GetComponent<GameManager> ().infAttack;
			newUnit.GetComponent<Unit> ().dex = gameManager.GetComponent<GameManager> ().infDex;
			newUnit.GetComponent<Unit>().speed = gameManager.GetComponent<GameManager> ().infSpeed;
			newUnit.GetComponent<Unit> ().range = gameManager.GetComponent<GameManager> ().infRange;

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
				
			newUnit.GetComponent<Unit>().health = gameManager.GetComponent<GameManager> ().archHealth;
			newUnit.GetComponent<Unit> ().attack = gameManager.GetComponent<GameManager> ().archAttack;
			newUnit.GetComponent<Unit> ().dex = gameManager.GetComponent<GameManager> ().archDex;
			newUnit.GetComponent<Unit>().speed = gameManager.GetComponent<GameManager> ().archSpeed;
			newUnit.GetComponent<Unit> ().range = gameManager.GetComponent<GameManager> ().archRange;


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

			newUnit.GetComponent<Unit>().health = gameManager.GetComponent<GameManager> ().armHealth;
			newUnit.GetComponent<Unit> ().attack = gameManager.GetComponent<GameManager> ().armAttack;
			newUnit.GetComponent<Unit> ().dex = gameManager.GetComponent<GameManager> ().armDex;
			newUnit.GetComponent<Unit>().speed = gameManager.GetComponent<GameManager> ().armSpeed;
			newUnit.GetComponent<Unit> ().range = gameManager.GetComponent<GameManager> ().armRange;

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

			newUnit.GetComponent<Unit>().health = gameManager.GetComponent<GameManager> ().artHealth;
			newUnit.GetComponent<Unit> ().attack = gameManager.GetComponent<GameManager> ().artAttack;
			newUnit.GetComponent<Unit> ().dex = gameManager.GetComponent<GameManager> ().artDex;
			newUnit.GetComponent<Unit>().speed = gameManager.GetComponent<GameManager> ().artSpeed;
			newUnit.GetComponent<Unit> ().range = gameManager.GetComponent<GameManager> ().artRange;
		}
	}	

	public GameObject findClosestSpawn() {
		return GameObject.Find("Spawn1");
	}



}
