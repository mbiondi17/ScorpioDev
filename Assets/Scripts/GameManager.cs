using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public GameObject selectedUnit = null;
	public GameObject objective = null;

//	public GUIText restartText;
//	public GUIText gameOverText;

//	private bool gameOver;
//	private bool restart;
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

//		gameOver = false;
//		restart = false;
//
//		restartText.text = "";
//		gameOverText.text = "";
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
					if(hit.transform.gameObject != selectedUnit.gameObject) {
						if (selectedUnit.transform.position.y <= -50) {
							GameObject spawnPoint = GameObject.Find ("Spawn1").GetComponent<Spawn> ().findClosestSpawn ();
							selectedUnit.transform.position = spawnPoint.transform.position;
						}
						if( (selectedUnit.name.Contains("Infantry") && 
						    (hit.collider.gameObject.tag.Equals ("Enemy") || hit.collider.gameObject.tag.Equals ("Objective")))
						   	  || ((selectedUnit.name.Contains ("Artillery") || selectedUnit.name.Contains("Armor")) 
						    	&& hit.collider.gameObject.tag.Equals ("Wall"))){
							selectedUnit.GetComponent<Unit> ().target = hit.transform.gameObject;
							selectedUnit.GetComponent<Unit> ().setNavMeshTarget ();
							selectedUnit = null;
						}

						else {
							selectedUnit.GetComponent<Unit> ().targetPoint = hit.point;
							selectedUnit.GetComponent<Unit> ().setNavMeshTarget ();
							selectedUnit = null;
						}
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

		if (Input.GetKey("escape"))
			Application.Quit();

		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			
			GameObject.Find("Spawn1").GetComponent<Spawn>().SpawnInfantry();

		}

		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			
			GameObject.Find("Spawn1").GetComponent<Spawn>().SpawnArmor();

		}

		if(Input.GetKeyDown(KeyCode.Alpha3)) {
			
				GameObject.Find("Spawn1").GetComponent<Spawn>().SpawnArtillery();

		}
	
	}

//	public void GameOver() {
//
//		gameOverText.text = "You win!";
//		gameOver = true;
//
//	}
}	