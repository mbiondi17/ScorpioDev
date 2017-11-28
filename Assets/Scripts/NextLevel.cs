using UnityEngine;
using UnityEngine.SceneManagement;
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
		if (!SceneManager.GetActiveScene().name.Equals ("Barracks"))
			gameObject.GetComponent<Canvas>().enabled = false;
		else
			gameObject.GetComponent<Canvas>().enabled = true;
	}
	//FOR TEST BUILD, THIS WAS CHANGED TO JUST LOOP ONE LEVEL
	public void LoadScene() {
		SceneManager.LoadScene (GameObject.Find ("GameManager").GetComponent<GameManager>().nextLevel);
	}
}
