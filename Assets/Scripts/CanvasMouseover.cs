using UnityEngine;
using System.Collections;

public class CanvasMouseover : MonoBehaviour {

	public GameManager gameManager;
	
	public void resetPointer() {
		gameManager.UImouseOver = true;
	}

	public void normalPointer() {
		gameManager.UImouseOver = false;
	}

}
