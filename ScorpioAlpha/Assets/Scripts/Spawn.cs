using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject infantryPrefab;
	public GameObject armorPrefab;
	public GameObject artilleryPrefab;

	public int infLeft = 10;
	public int armLeft = 3;
	public int artLeft = 3;

	public GameObject gameManager;
	public GameObject newUnit = null;
	public bool targetFound = false;
	
	void Start(){
		gameManager = GameObject.Find ("GameManager");
	}

	public void SpawnInfantry() {
		newUnit = (GameObject)Instantiate(infantryPrefab, new Vector3(
			GetComponentInParent<Transform>().position.x,
	        GetComponentInParent<Transform>().position.y,
		    GetComponentInParent<Transform>().position.z),
		    Quaternion.identity);

		gameManager.GetComponent<GameManager>().selectedUnit = newUnit;
	}

	public void SpawnArmor() {
		newUnit = (GameObject)Instantiate(armorPrefab, new Vector3(
			GetComponentInParent<Transform>().position.x,
			GetComponentInParent<Transform>().position.y,
			GetComponentInParent<Transform>().position.z), Quaternion.identity);
		gameManager.GetComponent<GameManager>().selectedUnit = newUnit;
	}

	public void SpawnArtillery() {
		newUnit = (GameObject)Instantiate(artilleryPrefab, new Vector3(
			GetComponentInParent<Transform>().position.x,
			GetComponentInParent<Transform>().position.y,
			GetComponentInParent<Transform>().position.z), Quaternion.identity);
		gameManager.GetComponent<GameManager>().selectedUnit = newUnit;
	}

	public GameObject findClosestSpawn() {
		return GameObject.Find("Spawn1");
	}



}
