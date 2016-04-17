using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Deselect : Objective {

	public bool startThisObj = false;
	private bool noneSelected = false;
	
	override public bool isComplete() {
		return noneSelected;
	}
	// Update is called once per frame
	void Update () {
		if(startThisObj) {
			if(GetComponentInParent<Tutorial>().gameManager.selectedUnits.Count == 0) {
				noneSelected = true;
			}
		}
	}
}

