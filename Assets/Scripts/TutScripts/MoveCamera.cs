using UnityEngine;
using System.Collections;

public class MoveCamera : Objective {

	public bool startThisObj;
	public GameManager gameManager;

	private bool movedLeft = false;
	private bool movedRight = false;
	private bool movedUp = false;
	private bool movedDown = false;

	override public bool isComplete() {
		if (movedLeft && movedUp && movedDown && movedRight)
			return true;
		else
			return false;
	}

	void Update() {
		if(!gameManager.isPaused) {
			if (startThisObj) {
				if (Input.GetKeyDown (KeyCode.W))
					movedUp = true;
				if (Input.GetKeyDown (KeyCode.S))
					movedDown = true;
				if (Input.GetKeyDown (KeyCode.A))
					movedLeft = true;
				if (Input.GetKeyDown (KeyCode.D))
					movedRight = true;
			}

		}
	}
}

