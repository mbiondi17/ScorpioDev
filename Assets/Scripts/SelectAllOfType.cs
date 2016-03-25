using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SelectAllOfType : Objective {

	private bool selected3 = false;
	
	override public bool isComplete() {
		return selected3;
	}
	// Update is called once per frame
	void Update () {
		if(GetComponentInParent<Tutorial>().gameManager.selectedUnits.Count == 3) {
			selected3 = true;
		}
	}
}
