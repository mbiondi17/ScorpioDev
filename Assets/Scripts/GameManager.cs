using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	public List<GameObject> selectedUnits = new List<GameObject>();
	public GameObject objective = null;

	public GameObject HelpMenu;

//	public GUIText restartText;
//	public GUIText gameOverText;

//	private bool gameOver;
//	private bool restart;

	private bool isPaused = false;

	public int nextLevel = 1;
	public int denarii;
	public int kills = 0;
	public int unitsLeft = 0;

	public int freeXMax = 0;
	public int freeZMax = 0;
	public int freeXMin = 0;
	public int freeZMin = 0;
	
	public int upgradeLevelInfantry;
	public int upgradeLevelArchers;
	public int upgradeLevelArtillery;
	public int upgradeLevelArmor;

	public Texture2D moveIcon;
	public GameObject unitToRemove = null;
	public bool UImouseOver = false;
	public bool getPaused() {
		return this.isPaused;
	}

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
		upgradeLevelInfantry = 2;
		upgradeLevelArchers = 2;
		upgradeLevelArtillery = 2;
		upgradeLevelArmor = 2;
		denarii = 10000;

		kills = 0;
		unitsLeft = 0;

//		gameOver = false;
//		restart = false;
//
//		restartText.text = "";
//		gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		if(HelpMenu == null && !Application.loadedLevelName.Equals("main")) {
			HelpMenu = GameObject.Find ("Canvas").transform.FindChild("Help Menu").gameObject;
		} 

		Ray tryRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit thisHit;

		if (Physics.Raycast (tryRay, out thisHit, 5000)) {
			if (selectedUnits.Count == 0 || UImouseOver) {
				Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
			} else if (!(thisHit.transform.gameObject.tag == "Enemy" || thisHit.transform.gameObject.tag == "Objective"
				|| thisHit.transform.gameObject.tag == "Player" || thisHit.transform.gameObject.tag == "Wall")) {
				Cursor.SetCursor (moveIcon, Vector2.zero, CursorMode.Auto);
			}
		}


		if (Application.loadedLevelName.Equals("Tutorial") && GameObject.FindGameObjectsWithTag ("Objective").GetLength (0) == 0) {
			Spawn spawn = GameObject.Find ("Spawn1").GetComponent<Spawn>();
			Application.LoadLevel ("main");
		}
		//Check if the level has been beaten (that is, there's no objective)
		else if (Application.loadedLevelName.Equals ("Level1") && GameObject.FindGameObjectsWithTag ("Objective").GetLength (0) == 0) {
			Spawn spawn = GameObject.Find ("Spawn1").GetComponent<Spawn>();
			unitsLeft = spawn.archLeft + spawn.infLeft + spawn.artLeft + spawn.armLeft;
			denarii = kills*100 + unitsLeft*100;
			Application.LoadLevel ("main");
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
			if (Input.GetMouseButtonDown (0) && !isPaused) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				
				if (Physics.Raycast (ray, out hit, 5000)) {
					//Debug.Log(hit.point);
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
							    (hit.transform.tag.Equals ("Enemy") || hit.collider.gameObject.tag.Equals ("Objective")))
							   	  || ((selectedUnit.name.Contains ("Artillery") || selectedUnit.name.Contains("Armor")) 
							    && (hit.collider.gameObject.tag.Equals ("Wall"))|| hit.collider.gameObject.tag.Equals("Objective"))){
								selectedUnit.GetComponent<Unit> ().target = hit.transform.gameObject;
								selectedUnit.GetComponent<Unit> ().setNavMeshTarget ();
							}

							else {
//								if((hit.point.x > freeXMin) && (hit.point.x < freeXMax) 
//							        && (hit.point.z > freeZMin) && (hit.point.z < freeZMax)){
								selectedUnit.GetComponent<Unit> ().target = null;
								selectedUnit.GetComponent<Unit> ().targetPoint = hit.point;
								selectedUnit.GetComponent<Unit> ().setNavMeshTarget();
							}
						}
						selectedUnits.Clear();
					}
					else {
						foreach(GameObject unit in selectedUnits) {
							unit.GetComponent<NavMeshAgent>().destination = unit.transform.position;
							unit.GetComponent<Unit>().target = null;
							unit.GetComponent<Unit>().targetPoint = unit.transform.position;

						}
					}
				}
			}
		}

		if(unitToRemove != null) {
			selectedUnits.Remove(unitToRemove);
			unitToRemove = null;
		}

		foreach (GameObject unit in selectedUnits) {
			if(unit == null) {
				selectedUnits.Remove(unit);
			}
		}


		//Reset the current level. For development purposes.
		if(Input.GetKeyDown(KeyCode.R) && !isPaused) 
		{

			Application.LoadLevel (Application.loadedLevel);

		}

		//Quit the level on "ESC"
		if (Input.GetKey("escape") && !isPaused)
			Application.Quit();

		//
		// keys 1, 2, and 3 also spawn units
		//
		if(Input.GetKeyDown(KeyCode.Alpha1) && !isPaused) {
			
			GameObject.Find("Spawn1").GetComponent<Spawn>().SpawnInfantry();

		}

		if(Input.GetKeyDown(KeyCode.Alpha2) && !isPaused) {
			
			GameObject.Find("Spawn1").GetComponent<Spawn>().SpawnArcher();
			
		}

		if(Input.GetKeyDown(KeyCode.Alpha3) && !isPaused) {
			
			GameObject.Find("Spawn1").GetComponent<Spawn>().SpawnArmor();

		}

		if(Input.GetKeyDown(KeyCode.Alpha4) && !isPaused) {
			
				GameObject.Find("Spawn1").GetComponent<Spawn>().SpawnArtillery();

		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			isPaused = !isPaused;
			if(isPaused) {
				Time.timeScale = 0.0f;
				HelpMenu.GetComponent<RectTransform>().localPosition = new Vector3(100, 0, 0);
			}
			else {
				Time.timeScale = 1.0f;
				HelpMenu.GetComponent<RectTransform>().localPosition = new Vector3(1000, 1000, 0);
				
			}
		}
	
	}

}	