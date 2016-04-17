using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SelectAllOfType : Objective {

	public bool startThisObj;


	private bool selected3 = false;
	
	override public bool isComplete() {
		return selected3;
	}
	// Update is called once per frame
	void Update () {
		if (startThisObj) {
			if (GetComponentInParent<Tutorial> ().gameManager.selectedUnits.Count == 3) {
				selected3 = true;
			}
		}
	}
}
