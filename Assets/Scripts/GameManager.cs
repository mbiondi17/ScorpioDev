using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	public List<GameObject> selectedUnits = new List<GameObject>();
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

		//Check if the level has been beaten (that is, there's no objective)
		if (!Application.loadedLevelName.Equals (("Barracks")) && GameObject.FindGameObjectsWithTag ("Objective").GetLength (0) == 0) {
			Application.LoadLevel ("Barracks");
		}

		//deselect units when ctrl+click or cmd+click is registered.
		if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)
		   || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand))
		{
			if (Input.GetMouseButtonDown (0))
			{
				//Debug.Log("Ctrl or Cmd + Click");
				this.selectedUnits.Clear();
			}
		}


		if (selectedUnits.Count > 0) {
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				
				if (Physics.Raycast (ray, out hit, 5000)) {
					if(!selectedUnits.Contains(hit.transform.gameObject)) {
						//Spawn script places units at y = -50
						//No particular reason this comes after the above if statement. Perhaps take out
						//later for speed.
						foreach (GameObject selectedUnit in selectedUnits) {
							if (selectedUnit.transform.position.y <= -45) {
								GameObject spawnPoint = GameObject.Find ("Spawn1").GetComponent<Spawn> ().findClosestSpawn ();
								selectedUnit.transform.position = spawnPoint.transform.position;
							}
						}

						//If the selected unit can target the clicked gameObject, set that unit's 
						//NavMeshTarget accordingly.
						foreach (GameObject selectedUnit in selectedUnits) {
							if( (selectedUnit.name.Contains("Infantry") && 
							    (hit.collider.gameObject.tag.Equals ("Enemy") || hit.collider.gameObject.tag.Equals ("Objective")))
							   	  || ((selectedUnit.name.Contains ("Artillery") || selectedUnit.name.Contains("Armor")) 
							    	&& hit.collider.gameObject.tag.Equals ("Wall"))){
								selectedUnit.GetComponent<Unit> ().target = hit.transform.gameObject;
								selectedUnit.GetComponent<Unit> ().setNavMeshTarget ();
							}

							else {
								selectedUnit.GetComponent<Unit> ().target = null;
								selectedUnit.GetComponent<Unit> ().targetPoint = hit.point;
								selectedUnit.GetComponent<Unit> ().setNavMeshTarget();
							}
						}
						selectedUnits.Clear();
					}
				}
			}
		}

		//Reset the current level. For development purposes.
		if(Input.GetKeyDown(KeyCode.R)) 
		{

			Application.LoadLevel (Application.loadedLevel);

		}

		//Quit the level on "ESC"
		if (Input.GetKey("escape"))
			Application.Quit();

		//
		// keys 1, 2, and 3 also spawn units
		//
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

}	