using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Tutorial : MonoBehaviour {

	public Objective MoveCamera;
	public Objective ZoomCamera;
	public Objective SpawnOneUnitWithButton;
	public Objective MoveUnit;
	public Objective SpawnOneUnitWithKey;
	public Objective SpawnTwoUnitsAndMove;
	public Objective SelectRadius;
	public Objective SelectAllOfType;
	public Objective SelectAll;
	public Objective Deselect;
	public Objective MoveMany;
	public Objective AttackEnemy;
	public Objective DestroyWall;
	public Objective Win;

	public Text MoveCam;
	public Text ZoomCam;
	public Text SpawnOneUnitWithButt;
	public Text MvUnit;
	public Text SpawnUnitWithKey;
	public Text SpawnTwoAndMove;
	public Text SelectRad;
	public Text SelectType;
	public Text SlctAll;
	public Text Dslct;
	public Text MovMany;
	public Text AtkEnemy;
	public Text DestWall;
	public Text WinTut;
	public Text VictoryText;


	private List<Objective> objectiveList = new List<Objective>();
	private bool tutComplete;


	// Use this for initialization
	void Start () {
		objectiveList.Add (MoveCamera);
		objectiveList.Add (ZoomCamera);
		objectiveList.Add (SpawnOneUnitWithButton);
		objectiveList.Add (MoveUnit);
		objectiveList.Add (SpawnOneUnitWithKey);
		objectiveList.Add (SpawnTwoUnitsAndMove);
		objectiveList.Add (SelectRadius);
		objectiveList.Add (SelectAllOfType);
		objectiveList.Add (SelectAll);
		objectiveList.Add (Deselect);
		objectiveList.Add (MoveMany);
		objectiveList.Add (AttackEnemy);
		objectiveList.Add (DestroyWall);
		objectiveList.Add (Win);

		MoveCam.enabled = false;
		ZoomCam.enabled = false;
		SpawnOneUnitWithButt.enabled = false;
		MvUnit.enabled = false;
		SpawnUnitWithKey.enabled = false;
		SpawnTwoAndMove.enabled = false;
		SelectRad.enabled = false;
		SelectType.enabled = false;
		SlctAll.enabled = false;
		Dslct.enabled = false;
		MovMany.enabled = false;
		AtkEnemy.enabled = false;
		DestWall.enabled = false;
		WinTut.enabled = false;
		VictoryText.enabled = false;

	}
		
	void Update () {

		if (!MoveCamera.isComplete ()) {
				MoveCam.enabled = true;
		}

		if (MoveCamera.isComplete () && !ZoomCamera.isComplete ()) {
				MoveCam.enabled = false;
				ZoomCam.enabled = true;
		}

		if(ZoomCamera.isComplete () && !SpawnOneUnitWithButton.isComplete()) {
				ZoomCam.enabled = false;
				SpawnOneUnitWithButt.enabled = true;
		}

		if (SpawnOneUnitWithButton.isComplete () && !MoveUnit.isComplete()) {
			SpawnOneUnitWithButt.enabled = false;
			MvUnit.enabled = true;
		}

		if (MoveUnit.GetComponent<MoveUnit> ().targetedEnemy) {
			MvUnit.text = "Let's not get hasty, General! \nThere will be plenty of time for combat later! \n" +
				"For now, just send your legionnaire to an \nempty spot on the battlefield.";
		}

		if (MoveUnit.isComplete ()) {
			MvUnit.enabled = false;
		}

	}
}







