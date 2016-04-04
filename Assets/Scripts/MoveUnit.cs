using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MoveUnit : Objective {

	public bool startThisObj;

	private bool moved = false;
	
	override public bool isComplete() {
		return moved;
	}

	public bool targetedEnemy = false;


	void Update() {

		if (startThisObj) {
			GameObject[] listOfUnits = GameObject.FindGameObjectsWithTag ("Player");
			IEnumerable currInfantry = (from unit in listOfUnits where unit.name.Contains ("Infantry") select unit);
			List<GameObject> infList = new List<GameObject> ();
			foreach (GameObject inf in currInfantry) {
				if (inf.GetComponent<Unit> ().targetPoint != Vector3.zero &&
					inf.GetComponent<Unit> ().targetPoint != inf.GetComponent<Transform> ().position) {
					moved = true;
				} else if (inf.GetComponent<Unit> ().target != null) {
					targetedEnemy = true;
					if (!moved) {
						inf.GetComponent<NavMeshAgent> ().destination = inf.GetComponent<Transform> ().position;
					}
				}
			}
		}
	}
	
	
}

