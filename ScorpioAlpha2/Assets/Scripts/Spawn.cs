using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject infantryPrefab;
	public GameObject armorPrefab;
	public GameObject artilleryPrefab;
	public GameObject gameManager;
	public GameObject newUnit = null;
	public bool targetFound = false;
	
	void Start(){
		gameManager = GameObject.Find ("GameManager");
	}

	public void SpawnInfantry() {
		newUnit = (GameObject)Instantiate(infantryPrefab, new Vector3(0, -50, 0), Quaternion.identity);
		gameManager.GetComponent<GameManager>().selectedUnit = newUnit;
	}

	public GameObject findClosestSpawn() {
		return GameObject.Find("Spawn1");
	}



}
