using UnityEngine;
using System.Collections;

public class __Unit : MonoBehaviour {

	//reference the GameManager for any necessary behaviors
	public GameManager gameManager;

	//target information for the GameManager to do combat checks
	public GameObject target = null;
	public Vector3 targetPoint = new Vector3(0,0,0);

	//Information on how quickly the unit attacks
	public float roundsPerSecond = 1;
	public float nextFire = 0.0f;

	//Unit stats 
	public string className;
	public int health;
	public int attack; 
	public int dex; 
	public float range;
	public float speed;

	//sounds to play during combat on hit or miss
	public AudioSource[] audioList;
	public AudioClip hitClip;
	public AudioClip missClip;

	public bool isSelected;
	public Animator unitAnimator;

//	private float timeClicked = 0.0f;
//	private float selectRadiusDelay = 0.5f;
//	private float selectAllDelay = 1.0f;
//	private bool selectRadius = false;
//	private bool selectAll = false;
	


    //public Unit unit () {
			
    //}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
