using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public GameObject target = null;
	public GameManager gameManager;
	public float health;
	public float damage;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		Debug.Log (GetComponent<Renderer> ().material.color);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setNavMeshTarget() {
		if(target != null) {
			this.GetComponent<NavMeshAgent>().destination = target.transform.position;
		}
	}

	/*public void OnMouseDown() {
		if (gameManager.selectedUnit == this.gameObject) {
			gameManager.selectedUnit = null;
			GetComponent<Renderer>().material.color = new Color(0.647f, 0.629f, 0f);
		}
		else {
			gameManager.selectedUnit = this.gameObject;
			GetComponent<Renderer>().material.color = Color.white;
		}
	}*/

	public void OnCollisionStay(Collision collisionInfo){
		if (collisionInfo.gameObject.tag == "Enemy") {
			collisionInfo.gameObject.GetComponent<Enemy>().health -= damage * Time.deltaTime;
		}
	}
}
