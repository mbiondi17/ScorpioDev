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
	public Objective Deselect;
	public Objective AttackEnemy;
	public Objective Win;

	public Text MoveCam;
	public Text ZoomCam;
	public Text SpawnOneUnitWithButt;
	public Text MvUnit;
	public Text SpawnUnitWithKey;
	public Text SpawnTwoAndMove;
	public Text SelectRad;
	public Text SelectType;
	public Text Dslct;
	public Text AtkEnemy;
	public Text WinTut;

	private List<Objective> objectiveList = new List<Objective>();
	private bool tutComplete;

	public GameManager gameManager;
	public GameObject enemy;
	public GameObject stronghold;


	// Use this for initialization
	void Start () {
		objectiveList.Add (MoveCamera);
		objectiveList.Add (ZoomCamera);
		objectiveList.Add (SpawnOneUnitWithButton);
		objectiveList.Add (MoveUnit);
		objectiveList.Add (SpawnOneUnitWithKey);
		objectiveList.Add (SpawnTwoUnitsAndMove);
		objectiveList.Add (SelectRadius);
		objectiveList.Add (Deselect);
		objectiveList.Add (SelectAllOfType);
		objectiveList.Add (AttackEnemy);
		objectiveList.Add (Win);

		MoveCam.enabled = false;
		ZoomCam.enabled = false;
		SpawnOneUnitWithButt.enabled = false;
		MvUnit.enabled = false;
		SpawnUnitWithKey.enabled = false;
		SpawnTwoAndMove.enabled = false;
		SelectRad.enabled = false;
		Dslct.enabled = false;
		SelectType.enabled = false;
		AtkEnemy.enabled = false;
		WinTut.enabled = false;

	}
		
	void Update () {

		if (!MoveCamera.isComplete ()) {
				MoveCamera.GetComponent<MoveCamera>().startThisObj = true;
				MoveCam.enabled = true;
		}

		if (MoveCamera.isComplete () && !ZoomCamera.isComplete ()) {
				ZoomCamera.GetComponent<ZoomCamera>().startThisObj = true;
				MoveCam.enabled = false;
				ZoomCam.enabled = true;
		}

		if(ZoomCamera.isComplete () && !SpawnOneUnitWithButton.isComplete()) {
				SpawnOneUnitWithButton.GetComponent<SpawnOneUnitWithButton>().startThisObj = true;
				ZoomCam.enabled = false;
				SpawnOneUnitWithButt.enabled = true;
		}

		if (SpawnOneUnitWithButton.isComplete () && !MoveUnit.isComplete()) {
			MoveUnit.GetComponent<MoveUnit>().startThisObj = true;
			SpawnOneUnitWithButt.enabled = false;
			MvUnit.enabled = true;
		}

		if (MoveUnit.GetComponent<MoveUnit> ().targetedEnemy) {
			MvUnit.text = "Let's not get hasty, General! \nThere will be plenty of time for combat later! \n" +
				"For now, just send your legionnaire to an \nempty spot on the battlefield.";
		}

		if (MoveUnit.isComplete () && !SpawnOneUnitWithKey.isComplete()) {
			SpawnOneUnitWithKey.GetComponent<SpawnUnitWithKey>().startThisObj = true;
			MvUnit.enabled = false;
			SpawnUnitWithKey.enabled = true;
		}

		if (SpawnOneUnitWithKey.GetComponent<SpawnUnitWithKey> ().targetedEnemy) {
			SpawnUnitWithKey.text = "Let's not get hasty, General! \nThere will be plenty of time for combat later! \n" +
				"For now, just send your battering ram to an \nempty spot on the battlefield.";
		}

		if (SpawnOneUnitWithKey.isComplete () && !SpawnTwoUnitsAndMove.isComplete()) {
			SpawnTwoUnitsAndMove.GetComponent<SpawnTwoAndMove>().startThisObj = true;
			SpawnUnitWithKey.enabled = false;
			SpawnTwoAndMove.enabled = true;
		}

		if(SpawnTwoUnitsAndMove.isComplete () && !SelectRadius.isComplete()) {
			SelectRadius.GetComponent<SelectRadius>().startThisObj = true;
			SpawnTwoAndMove.enabled = false;
			SelectRad.enabled = true;
		}

		if(SelectRadius.isComplete() && !Deselect.isComplete()) {
			Deselect.GetComponent<Deselect>().startThisObj = true;
			SelectRad.enabled = false;
			Dslct.enabled = true;
		}

		if(Deselect.isComplete() && !SelectAllOfType.isComplete()) {
			SelectAllOfType.GetComponent<SelectAllOfType>().startThisObj = true;
			Dslct.enabled = false;
			SelectType.enabled = true;
		}

		if(SelectAllOfType.isComplete() && !AttackEnemy.isComplete()) {
			AttackEnemy.GetComponent<AttackEnemy>().startThisObj = true;
			SelectType.enabled = false;
			AtkEnemy.enabled = true;
		}

		if(AttackEnemy.isComplete() && !Win.isComplete()) {
			Win.GetComponent<Win>().startThisObj = true;
			AtkEnemy.enabled = false;
			WinTut.enabled = true;
		}
	}
}







