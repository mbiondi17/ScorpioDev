using UnityEngine;
using System.Collections;

public class CanvasMouseover : MonoBehaviour {

	public GameManager gameManager;

//	public void Awake()
//	{
//		DontDestroyOnLoad(transform.FindChild("Help Menu").gameObject);
//	
//		
//	}

	void Start() {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	public void resetPointer() {
		gameManager.UImouseOver = true;
	}

	public void normalPointer() {
		gameManager.UImouseOver = false;
	}

}
