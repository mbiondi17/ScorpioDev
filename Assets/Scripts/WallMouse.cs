using UnityEngine;
using System.Collections;

public class WallMouse : MonoBehaviour {

	public Texture2D attackIcon;
	public Texture2D noAttackIcon;

	void OnMouseOver() {
		GameManager gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		bool attackable = false;
		foreach (GameObject unit in gameManager.selectedUnits) {
			if(unit.name.Contains ("Artillery") || unit.name.Contains ("Armor")) {
				attackable = true;
			}
		}
		
		if (attackable) {
			Cursor.SetCursor(attackIcon, new Vector2((float)(attackIcon.width)/2.0f, (float)(attackIcon.height)/2.0f), CursorMode.Auto);
		}
		
		if (!attackable && gameManager.selectedUnits.Count > 0) {
			Cursor.SetCursor(noAttackIcon, new Vector2((float)(attackIcon.width)/2.0f, (float)(attackIcon.height)/2.0f), CursorMode.Auto);
		}
	}
	
	void OnMouseExit() {
		
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		
	}

}
