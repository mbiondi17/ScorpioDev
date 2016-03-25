using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	
	public GameObject target = null;
	public Vector3 targetPoint = new Vector3(0,0,0);
	public GameManager gameManager;
	
	public float roundsPerSecond = 1;
	public float nextFire = 0.0f;
	
	public int health = 10;
	public int attack = 2; 
	public int dex = 15;
	public float range = 5.0f;
	public float speed = 1;
	
	public AudioSource[] audio;
	public AudioClip hitClip;
	public AudioClip missClip;
	
	public Material[] woodMaterials = new Material[4];
	public Material[] brickMaterials = new Material[4];
	
	private int on = 0;
	private float timeClicked = 0.0f;
	private float selectRadiusDelay = 0.5f;
	private float selectAllDelay = 1.0f;
	private bool selectRadius = false;
	private bool selectAll = false;

	public Animator superAnimu;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		audio = GetComponentsInParent<AudioSource>();
		hitClip = audio [0].clip;
		missClip = audio [1].clip;
		superAnimu = GetComponentInChildren<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.name.Contains("Infantry")) {
			if(Vector3.Distance(this.transform.position, GetComponent<NavMeshAgent>().destination) < 8.0f) {
				superAnimu.SetBool("Walk", false);
			}

			if(target == null) {
				superAnimu.SetBool ("Attack", false);

			}
		}

		if (gameManager.selectedUnits.Contains(this.gameObject)) {
			if (on == 0) {
				this.GetComponentInParent<healthBar>().GetComponentInChildren<healthBar>().m_FullHealthColor = Color.blue;
				this.GetComponentInParent<healthBar>().Invoke("SetHealthUI", 0.0f);
				on = 1;
			}
		} else {
			if(on == 1) {
				this.GetComponentInParent<healthBar>().GetComponentInChildren<healthBar>().m_FullHealthColor = Color.green;
				this.GetComponentInParent<healthBar>().Invoke("SetHealthUI", 0.0f);
				on = 0;
			}
		}

	}
	
	public void setNavMeshTarget() {
		if(target != null) {
			Vector3 direction = (target.transform.position - transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 1.0f);
			this.GetComponent<NavMeshAgent>().destination = target.transform.position;
		}
		else if(targetPoint != new Vector3(0,0,0)) {
			Vector3 direction = (targetPoint - transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 1.0f);
			this.GetComponent<NavMeshAgent>().destination = targetPoint;
		}
		if(this.name.Contains("Infantry")) superAnimu.SetBool ("Walk", true);
	}

	public void OnMouseOver() {

		if (gameManager.selectedUnits.Count > 0) {
			Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		}

		if(Input.GetMouseButton (0) && !gameManager.getPaused()) {
			if (timeClicked == 0.0f) {
				timeClicked = Time.time;
			}
			else if ((Time.time - timeClicked) >= selectAllDelay) {
				selectAll = true;
			}

			else if ((Time.time - timeClicked) >= selectRadiusDelay) {
				selectRadius = true;
			}

			if(selectRadius) {
				GameObject[] toAdd = GameObject.FindGameObjectsWithTag("Player");
				foreach(GameObject unit in toAdd) {
					if(unit.name == this.name && (Vector3.Distance(this.transform.position, unit.transform.position) < 30.0f)) {
						if(!gameManager.selectedUnits.Contains(unit)) {
							gameManager.selectedUnits.Add(unit);
						}
					}
				}
				selectRadius = false;
			}
			if(selectAll) {
				GameObject[] toAdd = GameObject.FindGameObjectsWithTag("Player");
				foreach(GameObject unit in toAdd) {
					if(unit.name == this.name) {
						if(!gameManager.selectedUnits.Contains(unit)) {
							gameManager.selectedUnits.Add(unit);
						}
					}
				}
				selectRadius = false;
				selectAll = false;
				timeClicked = 0.0f;
			}
		}
		
		else timeClicked = 0.0f;

		if(Input.GetMouseButtonDown (0) && !gameManager.getPaused()) {
			if(gameManager.selectedUnits.Contains(this.gameObject)) {
				gameManager.unitToRemove = this.gameObject;
			} else {
				gameManager.selectedUnits.Add(this.gameObject);
			}
		}
	}
}

