using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public int speed;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
	public float zMin;
	public float zMax;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("w") && this.transform.position.z < zMax)
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
		if (Input.GetKey("s") && this.transform.position.z > zMin)
            transform.Translate(-Vector3.forward * Time.deltaTime * speed, Space.World);
		if (Input.GetKey("a") && this.transform.position.x > xMin)
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
		if (Input.GetKey("d") && this.transform.position.x < xMax)
            transform.Translate(-Vector3.left * Time.deltaTime * speed, Space.World);
		if (Input.GetKey("q") && this.transform.position.y < yMax)
			transform.Translate(0, Time.deltaTime * speed, Time.deltaTime * speed, Space.World);
		if (Input.GetKey("e") && this.transform.position.y > yMin)
			transform.Translate(0, -(Time.deltaTime * speed), -(Time.deltaTime * speed), Space.World);
		if ((Input.GetAxis("Mouse ScrollWheel") < 0) && this.transform.position.y < yMax)
			transform.Translate(0, Time.deltaTime * 3 * speed, Time.deltaTime * 3 * speed, Space.World);
		if ((Input.GetAxis("Mouse ScrollWheel") > 0) && this.transform.position.y > yMin)
			transform.Translate(0, -(Time.deltaTime * 3 * speed), -(Time.deltaTime * 3 * speed), Space.World);



	}
}