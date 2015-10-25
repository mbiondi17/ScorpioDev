using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public int speed;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("w"))
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        if (Input.GetKey("s"))
            transform.Translate(-Vector3.forward * Time.deltaTime * speed, Space.World);
        if (Input.GetKey("a"))
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        if (Input.GetKey("d"))
            transform.Translate(-Vector3.left * Time.deltaTime * speed, Space.World);
    }
}