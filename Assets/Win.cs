using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Win : Objective {
	
	private bool objectiveDestroyed = false;
	
	override public bool isComplete() {
		return objectiveDestroyed;
	}
	// Update is called once per frame
	void Update () {
		if(GetComponentInParent<Tutorial>().stronghold == null) {
			objectiveDestroyed = true;
		}
	}
}