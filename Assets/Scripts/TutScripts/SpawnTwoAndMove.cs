using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SpawnTwoAndMove : Objective {

	public bool startThisObj = false;
	public GameManager gameManager;

	private bool moved1 = false;
	private bool moved2 = false;
	private bool spawnedBoth = false;
	public bool movedTooFar = false;

	override public bool isComplete() {
		return spawnedBoth && moved1 && moved2;
	}
	
	void Update() {
		if(!gameManager.isPaused) {
			if (startThisObj) {
				GameObject[] listOfUnits = GameObject.FindGameObjectsWithTag ("Player");
				IEnumerable currInf = (from unit in listOfUnits where unit.name.Contains ("Infantry") select unit);
				List<GameObject> infList = new List<GameObject> ();
				foreach (GameObject inf in currInf) {
					infList.Add (inf);
					if (inf.GetComponent<Unit> ().targetPoint != Vector3.zero &&
						inf.GetComponent<Unit> ().targetPoint != inf.GetComponent<Transform> ().position) {
						if (inf.GetComponent<Unit> ().targetPoint.x > -160 
							&& inf.GetComponent<Unit> ().targetPoint.x < -120
							&& inf.GetComponent<Unit> ().targetPoint.z > -40
							&& inf.GetComponent<Unit> ().targetPoint.z < 0) {
							if (!moved1)
								moved1 = true;
							if (moved1)
								moved2 = true;
						} else {
							inf.GetComponent<UnityEngine.AI.NavMeshAgent> ().destination = inf.GetComponent<Transform> ().position;
							movedTooFar = true;
						}
					}
				}
				
				if (infList.Count >= 3) {
					spawnedBoth = true;
					startThisObj = false;
				}
			}
		}
	}
	
	
}

