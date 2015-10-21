using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public GameObject selectedUnit = null;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (selectedUnit != null) {
			Debug.Log ("SelectedUnit" + selectedUnit.name);
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				
				if (Physics.Raycast (ray, out hit, 100)) {
					Debug.Log (hit.transform.gameObject.name);
					if (selectedUnit.transform.position.y <= -50) {
						GameObject spawnPoint = GameObject.Find ("Spawn1").GetComponent<Spawn> ().findClosestSpawn ();
						selectedUnit.transform.position = spawnPoint.transform.position;
					}
					if(hit.collider.gameObject.tag.Equals ("Enemy")){
						selectedUnit.GetComponent<Unit> ().target = hit.transform.gameObject;
						selectedUnit.GetComponent<Unit> ().setNavMeshTarget ();
						selectedUnit = null;
					}
				}
			}
		}
	}
}	