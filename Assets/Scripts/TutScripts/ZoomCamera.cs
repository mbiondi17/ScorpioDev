using UnityEngine;
using System.Collections;

public class ZoomCamera : Objective {

	public bool startThisObj;
	public GameManager gameManager;


	private bool zoomOutQ = false;
	private bool zoomInE = false;
	private bool zoomOutMouse = false;
	private bool zoomInMouse = false;
	
	override public bool isComplete() {
		if (zoomOutQ && zoomInE && zoomOutMouse && zoomInMouse)
			return true;
		else
			return false;
	}
	
	void Update() {
		if(!gameManager.isPaused) {
			if (startThisObj) {
				if (Input.GetKeyDown (KeyCode.Q))
					zoomOutQ = true;
				if (Input.GetKeyDown (KeyCode.E))
					zoomInE = true;
				if (Input.GetAxis ("Mouse ScrollWheel") < 0)
					zoomInMouse = true;
				if (Input.GetAxis ("Mouse ScrollWheel") > 0)
					zoomOutMouse = true;
			}
		}
	}
	
	
}

