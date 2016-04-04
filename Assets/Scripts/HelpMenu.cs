using UnityEngine;
using System.Collections;

public class HelpMenu : MonoBehaviour {

	public void Awake()
	{
		DontDestroyOnLoad(this);
		
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}

	}
}
