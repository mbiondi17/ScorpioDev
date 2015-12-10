using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	

	public void Awake()
	{
		DontDestroyOnLoad(this);
		
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	public void Update(){
		if (!Application.loadedLevelName.Equals ("Barracks"))
			gameObject.GetComponent<Canvas>().enabled = false;
		else
			gameObject.GetComponent<Canvas>().enabled = true;
	}
	public void LoadScene() {
		Application.LoadLevel (GameObject.Find ("GameManager").GetComponent<GameManager>().nextLevel++);
	}
}
