using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class AttackEnemy : Objective {

	public bool startThisObj;
	public GameManager gameManager;

	private bool enemyKilled = false;
	
	override public bool isComplete() {
		return enemyKilled;
	}
	// Update is called once per frame
	void Update () {
		if(!gameManager.isPaused) {
			if (startThisObj) {
				if (GetComponentInParent<Tutorial> ().enemy == null) {
					enemyKilled = true;
				}
			}
		}
	}
}