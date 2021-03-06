using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MoveUnit : Objective {

	public bool startThisObj;
	public GameManager gameManager;

	private bool moved = false;
	
	override public bool isComplete() {
		return moved;
	}

	public bool targetedEnemy = false;


	void Update() {
		if(!gameManager.isPaused) {
			if (startThisObj) {
				GameObject[] listOfUnits = GameObject.FindGameObjectsWithTag ("Player");
				IEnumerable currInfantry = (from unit in listOfUnits where unit.name.Contains ("Infantry") select unit);
				foreach (GameObject inf in currInfantry) {
					if (inf.GetComponent<Unit> ().targetPoint != Vector3.zero &&
						inf.GetComponent<Unit> ().targetPoint != inf.GetComponent<Transform> ().position) {
						moved = true;
					} else if (inf.GetComponent<Unit> ().target != null) {
						targetedEnemy = true;
						if (!moved) {
							inf.GetComponent<UnityEngine.AI.NavMeshAgent> ().destination = inf.GetComponent<Transform> ().position;
						}
					}
				}
			}
		}
	}
	
	
}

