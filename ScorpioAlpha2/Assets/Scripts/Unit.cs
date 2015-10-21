using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public GameObject target = null;
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (target);
	}

	public void setNavMeshTarget() {
		if(target != null) {
			this.GetComponent<NavMeshAgent>().destination = target.transform.position;
		}
	}

	public void OnMouseDown() {
		Debug.Log ("I am Clicked");
		if (gameManager.selectedUnit == this.gameObject)
			gameManager.selectedUnit = null;
		else {
			gameManager.selectedUnit = this.gameObject;
		}
	}

}
