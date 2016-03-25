using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SpawnUnitWithKey : Objective {
	
	private bool spawnedWithKey = false;
	private bool moved = false;
	public bool targetedEnemy = false;

	
	override public bool isComplete() {
		return spawnedWithKey && moved;
	}
	
	void Update() {
		
		GameObject[] listOfUnits = GameObject.FindGameObjectsWithTag ("Player");
		IEnumerable currArmor = (from unit in listOfUnits where unit.name.Contains ("Armor") select unit);
		List<GameObject> armList = new List<GameObject>();
		foreach (GameObject arm in currArmor) {
			armList.Add(arm);
			if( arm.GetComponent<Unit>().targetPoint != Vector3.zero &&
			   arm.GetComponent<Unit>().targetPoint != arm.GetComponent<Transform>().position) {
				moved = true;
			}
			else if(arm.GetComponent<Unit>().target != null) {
				targetedEnemy = true;
				if(!moved){
					arm.GetComponent<NavMeshAgent>().destination = arm.GetComponent<Transform>().position;
				}
			}
		}
		
		if (armList.Count >= 1)
			spawnedWithKey = true;
	}
	
	
}

