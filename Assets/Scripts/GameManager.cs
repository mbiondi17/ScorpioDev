using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	public List<GameObject> selectedUnits = new List<GameObject>();
	public GameObject objective = null;

	public GameObject HelpMenu;
	public GameObject BarracksCanvas;

//	public GUIText restartText;
//	public GUIText gameOverText;

//	private bool gameOver;
//	private bool restart;

	//Carry stats for upgraded units between levels!
	public int infHealth;
	public int infDex;
	public int infRange;
	public float infSpeed;
	public int infAttack;

	public int archHealth;
	public int archDex;
	public int archRange;
	public float archSpeed;
	public int archAttack;

	public int armHealth;
	public int armDex;
	public int armRange;
	public float armSpeed;
	public int armAttack;	

	public int artHealth;
	public int artDex;
	public int artRange;
	public float artSpeed;
	public int artAttack;

	private bool isPaused = false;

	public string nextLevel = "Level1";
	public int denarii;
	public int kills = 0;
	public int unitsLeft = 0;

	public int freeXMax = 0;
	public int freeZMax = 0;
	public int freeXMin = 0;
	public int freeZMin = 0;

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
		if (infHealth == 0) {
			infHealth = 10;
			infDex = 15;
			infRange = 6;
			infSpeed = 1.0f;
			infAttack = 2;
			
			archHealth = 10;
			archDex = 25;
			archRange = 35;
			archSpeed = 1.25f;
			archAttack = 1;
			
			armHealth = 20;
			armDex = 0;
			armRange = 6;
			armSpeed = 0.5f;
			armAttack = 2;	
			
			artHealth = 15;
			artDex = 0;
			artRange = 30;
			artSpeed = 1.0f;
			artAttack = 2;
		}

		denarii = 100000;
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

		//Fixes issue with Help Menu disappearing after each level is loaded
		if(HelpMenu == null && !Application.loadedLevelName.Equals("main") 
		   && !Application.loadedLevelName.Equals ("Barracks") 
		   && !Application.loadedLevelName.Contains ("Transition")) 
		{
			BarracksCanvas.SetActive(false);
			HelpMenu = GameObject.Find ("Canvas").transform.FindChild("Help Menu").gameObject;

		} 
		if (Application.loadedLevelName.Equals ("Barracks")) {
			BarracksCanvas.SetActive(true);
		}

		//Make cursor into move cursor if the raycast doesn't intersect an invalid destination
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

		//************************************************************************************************************
		//
		// Handling level Progression
		//
		//************************************************************************************************************

		if (GameObject.FindGameObjectsWithTag ("Objective").GetLength (0) == 0) {

			//The tutorial Level, when beaten, loops back to the main menu
			if (Application.loadedLevelName.Equals ("Tutorial")) {
				Application.LoadLevel ("main");
			}

			//Every other level progresses as follows: Level -> Next Level Exposition --> Barracks --> Next Level
			else if (Application.loadedLevelName.Equals ("Level1")) {
				nextLevel = "Level2";
				Spawn spawn = GameObject.Find ("Spawn1").GetComponent<Spawn> ();
				unitsLeft = spawn.archLeft + spawn.infLeft + spawn.artLeft + spawn.armLeft;
				denarii += kills * 100 + unitsLeft * 100;
				Application.LoadLevel ("Transition1-2");
			}
			else if (Application.loadedLevelName.Equals ("Level2")) {
				nextLevel = "Level3";
				Spawn spawn = GameObject.Find ("Spawn1").GetComponent<Spawn> ();
				unitsLeft = spawn.archLeft + spawn.infLeft + spawn.artLeft + spawn.armLeft;
				denarii += kills * 100 + unitsLeft * 100;
				Application.LoadLevel ("Transition2-3");
			}

		}



		//************************************************************************************************************
		//
		// Actual Game Handling
		//
		//************************************************************************************************************
		
		
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


		//Reset the current level.
		if(Input.GetKeyDown(KeyCode.R) && !isPaused) 
		{
			Debug.Log ("Reset");
			Application.LoadLevel (Application.loadedLevel);

		}

		//Quit the level on "ESC"
		if (Input.GetKey("escape") && !isPaused) {
			if(!Application.loadedLevelName.Equals("main")) {
				Application.LoadLevel("main");
			}
			else {
				Application.Quit();
			}
		}
		//
		// keys 1, 2, 3, and 4 also spawn units
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