using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SpawnOneUnitWithButton : Objective {

	public bool startThisObj;
	public GameManager gameManager;

	private bool spawnedWithButton = false;
	
	override public bool isComplete() {
		return spawnedWithButton;
	}
	
	void Update() {
		if(!gameManager.isPaused) {
			if (startThisObj) {
				GameObject[] listOfUnits = GameObject.FindGameObjectsWithTag ("Player");
				IEnumerable currInfantry = (from unit in listOfUnits where unit.name.Contains ("Infantry") select unit);
				List<GameObject> infList = new List<GameObject> ();
				foreach (GameObject inf in currInfantry) {
					infList.Add (inf);
				}

				if (infList.Count >= 1)
					spawnedWithButton = true;
			}
		}
	}
	
	
}

