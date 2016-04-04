using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void TutorialStart() {
		Application.LoadLevel ("Tutorial");
	}

	public void CampagignStart() {
		Application.LoadLevel ("Level1");
	}
}
