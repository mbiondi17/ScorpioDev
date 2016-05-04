using UnityEngine;
using System.Collections;

public class EnemyUnit : MonoBehaviour {
	
	public GameObject target = null;
	public Texture2D attackIcon;
	public Texture2D noAttackIcon;

	public int health = 15;
	public int attack = 2; 
	public int dex = 15;
	public float range = 5.0f;
	public int speed = 1;

	public bool isStatic = false;

	public float nextFire = 0.0f;

	//toggles for differing level AI
	private bool level1AI;
	private bool level2AI;
	private bool level3AI;
	
	// Use this for initialization
	void Start () {
		level1AI = false;
		level2AI = false;
		level3AI = false;
		if (Application.loadedLevelName.Equals ("Level1")) {
			level1AI = true;
			health = 15;
			attack = 2;
			dex = 15;
			range = 5.0f;
			speed = 1;
		} else if (Application.loadedLevelName.Equals ("Level2")) {
			level2AI = true;
			health = 16;
			attack = 3;
			dex = 16;
			range = 5.0f;
			speed = 1;
		} else if (Application.loadedLevelName.Equals ("Level3")) {
			level3AI = true;
			health = 16;
			attack = 3;
			dex = 16;
			range = 5.0f;
			speed = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && !isStatic) {
			GetComponent<NavMeshAgent> ().destination = target.transform.position;
		} 

		if(level1AI && target == null) {
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
			GameObject closestPlayer = null;
			float closestDist = 9999999.0f;
			foreach(GameObject unit in players) {
				if(Vector3.Distance(transform.position, unit.transform.position) < closestDist) {
					closestDist = Vector3.Distance(transform.position, unit.transform.position);
					closestPlayer = unit;
				}
			}
			if(closestPlayer != null) {
				target = closestPlayer;
			}
		}

	}

	
	void OnTriggerStay(Collider co) {
		if (this.tag != "Objective") {
			if ((co.tag == "Player") && Time.time > nextFire) {
				GetComponent<NavMeshAgent>().destination = GetComponent<Transform>().position;
				nextFire = Time.time + 1 / speed;
				healthBar health = co.GetComponentInChildren<healthBar> ();
				if (health) {
					int hit = Random.Range (0, 101);
					if (hit <= 100 - co.GetComponent<Unit> ().dex) {
						health.decrease (attack);
					}
				}
				else {
					target = null;
				}
			}
		}
	}

	void OnMouseOver() {
		GameManager gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		bool attackable = false;
		foreach (GameObject unit in gameManager.selectedUnits) {
			if(unit.name.Contains ("Infantry") || unit.name.Contains ("Archer")) {
				attackable = true;
			}
		}

		if (attackable) {
			Cursor.SetCursor(attackIcon, new Vector2((float)(attackIcon.width)/2.0f, (float)(attackIcon.height)/2.0f), CursorMode.Auto);
		}

		if (!attackable && gameManager.selectedUnits.Count > 0) {
			Cursor.SetCursor(noAttackIcon, new Vector2((float)(attackIcon.width)/2.0f, (float)(attackIcon.height)/2.0f), CursorMode.Auto);
		}
	}

	void OnMouseExit() {

		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);

	}


}
