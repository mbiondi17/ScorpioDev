using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BarracksTransfer : MonoBehaviour {

	public void LoadBarracks() {
		Debug.Log ("Clicked");
		SceneManager.LoadScene ("Barracks");
	}
	
}
