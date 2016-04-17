using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SelectRadius : Objective {

	public bool startThisObj;

	private bool selected2 = false;
	
	override public bool isComplete() {
		return selected2;
	}
	
	void Update() {
		if (startThisObj) {

			if (GetComponentInParent<Tutorial> ().gameManager.selectedUnits.Count >= 2) {
				selected2 = true;
			}
		}
	}

	
	
}	