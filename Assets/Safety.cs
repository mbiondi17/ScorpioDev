using UnityEngine;
using System.Collections;

public class Safety : MonoBehaviour {

	public GameObject Level1Manager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider co) {
		//first check is for null component Unit
		if(co.gameObject.GetComponent<Unit>()) {
			//second check is for actual valid target
			if(co.gameObject.GetComponent<Unit>().isRunning) {
				Destroy(co.gameObject);
				Level1Manager.GetComponent<Level1Manager>().friendliesSaved++;
			}
		}
	}
}
