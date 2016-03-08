﻿using UnityEngine;
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

	public GameObject gameManager;
	public GameObject newUnit = null;
	public bool targetFound = false;
	
	void Start(){
		gameManager = GameObject.Find ("GameManager");
		infButton.GetComponentInChildren<Text>().text = "Infantry -- Left: " + infLeft;
		archButton.GetComponentInChildren<Text>().text = "Archers -- Left: " + archLeft;
		armButton.GetComponentInChildren<Text>().text = "Armor -- Left: " + armLeft;
		artButton.GetComponentInChildren<Text>().text = "Artillery -- Left: " + artLeft;

	}

	public void SpawnInfantry() {
		if (infLeft > 0) {
			newUnit = (GameObject)Instantiate (infantryPrefab, new Vector3 (
			GetComponentInParent<Transform> ().position.x,
	        GetComponentInParent<Transform> ().position.y,
		    GetComponentInParent<Transform> ().position.z),
		    Quaternion.identity);
			gameManager.GetComponent<GameManager> ().selectedUnits.Clear ();
			gameManager.GetComponent<GameManager> ().selectedUnits.Add(newUnit);
			infLeft--;
			infButton.GetComponentInChildren<Text>().text = "Infantry -- Left: " + infLeft;
		}
	}

	public void SpawnArcher() {
		if (archLeft > 0) {
			newUnit = (GameObject)Instantiate (archerPrefab, new Vector3 (
				GetComponentInParent<Transform> ().position.x,
				GetComponentInParent<Transform> ().position.y,
				GetComponentInParent<Transform> ().position.z),
			                                   Quaternion.identity);
			gameManager.GetComponent<GameManager> ().selectedUnits.Clear ();
			gameManager.GetComponent<GameManager> ().selectedUnits.Add(newUnit);
			archLeft--;
			archButton.GetComponentInChildren<Text>().text = "Archers -- Left: " + archLeft;
		}
	}

	public void SpawnArmor() {
		if (armLeft > 0) {
			newUnit = (GameObject)Instantiate (armorPrefab, new Vector3 (
			GetComponentInParent<Transform> ().position.x,
			GetComponentInParent<Transform> ().position.y,
			GetComponentInParent<Transform> ().position.z), Quaternion.identity);
			gameManager.GetComponent<GameManager> ().selectedUnits.Clear ();
			gameManager.GetComponent<GameManager> ().selectedUnits.Add(newUnit);
			armLeft--;
			armButton.GetComponentInChildren<Text>().text = "Armor -- Left: " + armLeft;
		}
	}

	public void SpawnArtillery() {
		if (artLeft > 0) {
			newUnit = (GameObject)Instantiate (artilleryPrefab, new Vector3 (
			GetComponentInParent<Transform> ().position.x,
			(GetComponentInParent<Transform> ().position.y + 0.5f),
			GetComponentInParent<Transform> ().position.z), Quaternion.identity);
			gameManager.GetComponent<GameManager> ().selectedUnits.Clear ();
			gameManager.GetComponent<GameManager> ().selectedUnits.Add(newUnit);
			artLeft--;
			artButton.GetComponentInChildren<Text>().text = "Artillery -- Left: " + artLeft;
		}
	}	

	public GameObject findClosestSpawn() {
		return GameObject.Find("Spawn1");
	}



}
