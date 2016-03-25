using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SelectRadius : Objective {
	
	private bool selected2 = false;
	
	override public bool isComplete() {
		return selected2;
	}
	
	void Update() {
		
		if(GetComponentInParent<Tutorial>().gameManager.selectedUnits.Count >= 2) {
			selected2 = true;
		}
	}

	
	
}	