using UnityEngine;
using System.Collections;

public class level1Cam : MonoBehaviour {
	
	public int speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey("w") && this.transform.position.z < 350)
			transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
		if (Input.GetKey("s") && this.transform.position.z > -350)
			transform.Translate(-Vector3.forward * Time.deltaTime * speed, Space.World);
		if (Input.GetKey("a") && this.transform.position.x > -350)
			transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
		if (Input.GetKey("d") && this.transform.position.x < 350)
			transform.Translate(-Vector3.left * Time.deltaTime * speed, Space.World);
		if (Input.GetKey("q") && this.transform.position.y < 300)
			transform.Translate(0, Time.deltaTime * speed, Time.deltaTime * speed, Space.World);
		if (Input.GetKey("e") && this.transform.position.y > 15)
			transform.Translate(0, -(Time.deltaTime * speed), -(Time.deltaTime * speed), Space.World);
		if ((Input.GetAxis("Mouse ScrollWheel") < 0) && this.transform.position.y < 300)
			transform.Translate(0, Time.deltaTime * 3 * speed, Time.deltaTime * 3 * speed, Space.World);
		if ((Input.GetAxis("Mouse ScrollWheel") > 0) && this.transform.position.y > 15)
			transform.Translate(0, -(Time.deltaTime * 3 * speed), -(Time.deltaTime * 3 * speed), Space.World);
		
		
		
	}
}