using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	public List<GameObject> selectedUnit = new List<GameObject>();


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
		if (selectedUnit != null) {
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				
				if (Physics.Raycast (ray, out hit, 100)) {
					if (selectedUnit.transform.position.y <= -50) {
						GameObject spawnPoint = GameObject.Find ("Spawn1").GetComponent<Spawn> ().findClosestSpawn ();
						selectedUnit.transform.position = spawnPoint.transform.position;
					}
					if(hit.collider.gameObject.tag.Equals ("Enemy")){
						selectedUnit.GetComponent<Unit> ().target = hit.transform.gameObject;
						selectedUnit.GetComponent<Unit> ().setNavMeshTarget ();
						selectedUnit.GetComponent<Renderer>().material.color = new Color(0.647f, 0.629f, 0f);
						selectedUnit = null;
					}
				}
			}
		}
	}*/

	void Update() {
		if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift)) {
			Debug.Log ("Multiple Selection");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.collider.gameObject.tag == "Friendly" && selectedUnit.Find (thing => thing = hit.collider.gameObject) == null) {
					Debug.Log ("Hit");
					selectedUnit.Add (hit.collider.gameObject);
					hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.white;
				}
			}
		}

		else if (Input.GetMouseButtonDown (0)){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.collider.gameObject.tag == "Friendly"){
					clearSelectedUnits();
					selectedUnit.Add (hit.collider.gameObject);
					hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.white;
				}
				else if (hit.collider.gameObject.tag == "Enemy"){
					for (int x = 0; x < selectedUnit.Count; x++){
						selectedUnit[x].GetComponent<Unit>().target = hit.collider.gameObject;
						selectedUnit[x].GetComponent<Unit>().setNavMeshTarget();
					}
					clearSelectedUnits();
				}
				else{
					clearSelectedUnits ();
				}
			}
		}
	}

	void clearSelectedUnits(){
		for (int x = 0; x < selectedUnit.Count; x++)
			selectedUnit[x].GetComponent<Renderer> ().material.color = new Color(0.647f, 0.629f, 0f);
		selectedUnit.Clear();
	}
}