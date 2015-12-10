using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public GameObject selectedUnit = null;
	public GameObject objective = null;

	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	public int nextLevel = 1;

	public void Awake()
	{
		DontDestroyOnLoad(this);
		
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		objective = GameObject.FindGameObjectWithTag("Objective");
		gameOver = false;
		restart = false;

		restartText.text = "";
		gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (!Application.loadedLevelName.Equals (("Barracks")) && GameObject.FindGameObjectsWithTag ("Objective").GetLength (0) == 0) {
			Application.LoadLevel ("Barracks");
		}
		if (selectedUnit != null) {
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				
				if (Physics.Raycast (ray, out hit, 10000)) {
					Debug.Log (hit.transform.gameObject.name);
					if (selectedUnit.transform.position.y <= -50) {
						GameObject spawnPoint = GameObject.Find ("Spawn1").GetComponent<Spawn> ().findClosestSpawn ();
						selectedUnit.transform.position = spawnPoint.transform.position;
					}
					if(hit.collider.gameObject.tag.Equals ("Enemy") || 
					   hit.collider.gameObject.tag.Equals ("Objective")){
						selectedUnit.GetComponent<Unit> ().target = hit.transform.gameObject;
						selectedUnit.GetComponent<Unit> ().setNavMeshTarget ();
						selectedUnit = null;
					}
				}
			}
		}

//		if(gameOver) {
//
//			restartText.text = "Press 'R' for Restart";
//			restart = true;
//
//		}

		if(Input.GetKeyDown(KeyCode.R)) {

			Application.LoadLevel (Application.loadedLevel);

		}
	
	}

//	public void GameOver() {
//
//		gameOverText.text = "You win!";
//		gameOver = true;
//
//	}
}	