using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void TutorialStart() {
		SceneManager.LoadScene ("Tutorial");
	}

	public void CampagignStart() {
		SceneManager.LoadScene ("Barracks");
	}

	void Update() { 
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
