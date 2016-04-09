using UnityEngine;
using System.Collections;

public class HelpMenu : MonoBehaviour {

	public void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);


	}
}
