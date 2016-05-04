using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void TutorialStart() {
		Application.LoadLevel ("Tutorial");
	}

	public void CampagignStart() {
		Application.LoadLevel ("Barracks");
	}

	void Update() { 
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
