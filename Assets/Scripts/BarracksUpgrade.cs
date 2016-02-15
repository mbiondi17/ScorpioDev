using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarracksUpgrade : MonoBehaviour {
	public Text upgradeTextInfantry;
	public Text upgradeTextArchers;
	public Text upgradeTextArtillery;
	public Text upgradeTextArmor;
	
	public Text currentTextInfantry;
	public Text currentTextArchers;
	public Text currentTextArtillery;
	public Text currentTextArmor;
	
	public Text denariiTextBox;
	
	public int upgradeLevelInfantry = 1;
	public int upgradeLevelArchers = 1;
	public int upgradeLevelArtillery = 1;
	public int upgradeLevelArmor = 1;
	
	public int denarii = 1;
	
	void Start() {
		denariiTextBox.text = "Denarii: " + denarii.ToString ();
		
		currentTextInfantry.text = upgradeInfantry1;
		upgradeTextInfantry.text = upgradeInfantry2;
		
		currentTextArchers.text = "";
		upgradeTextArchers.text = upgradeArchers1;
		
		currentTextArtillery.text = upgradeArtillery1;
		upgradeTextArtillery.text = upgradeArtillery2;
		
		currentTextArmor.text = upgradeArmor1;
		upgradeTextArmor.text = upgradeArmor2;
	}
	
	public void upgradeInfantry() {
		if (upgradeLevelInfantry == 1) {
			currentTextInfantry.text = upgradeInfantry2;
			upgradeTextInfantry.text = upgradeInfantry3;
			upgradeLevelInfantry++;
		} else if (upgradeLevelInfantry == 2) {
			currentTextInfantry.text = upgradeInfantry3;
			upgradeTextInfantry.text = upgradeInfantry4;
			upgradeLevelInfantry++;
		} else if (upgradeLevelInfantry == 3) {
			currentTextInfantry.text = upgradeInfantry4;
			upgradeTextInfantry.text = "No more!";
			upgradeLevelInfantry++;
		}
	}
	public void upgradeArchers() {
		if (upgradeLevelArchers == 1) {
			currentTextArchers.text = upgradeArchers1;
			upgradeTextArchers.text = "No more!";
			upgradeLevelArchers++;
		}
	}
	public void upgradeArtillery() {
		Debug.Log ("Upgrade Infantry");
		if (upgradeLevelArtillery == 1) {
			currentTextArtillery.text = upgradeArtillery2;
			upgradeTextArtillery.text = upgradeArtillery3;
			upgradeLevelArtillery++;
		} else if (upgradeLevelArtillery == 2) {
			currentTextArtillery.text = upgradeArtillery3;
			upgradeTextArtillery.text = upgradeArtillery4;
			upgradeLevelArtillery++;
		} else if (upgradeLevelArtillery == 3) {
			currentTextArtillery.text = upgradeArtillery4;
			upgradeTextArtillery.text = upgradeArtillery5;
			upgradeLevelArtillery++;
		} else if (upgradeLevelArtillery == 4) {
			currentTextArtillery.text = upgradeArtillery5;
			upgradeTextArtillery.text = upgradeArtillery6;
			upgradeLevelArtillery++;
		} else if (upgradeLevelArtillery == 5) {
			currentTextArtillery.text = upgradeArtillery6;
			upgradeTextArtillery.text = upgradeArtillery7;
			upgradeLevelArtillery++;
		} else if (upgradeLevelArtillery == 6) {
			currentTextArtillery.text = upgradeArtillery7;
			upgradeTextArtillery.text = "No more!";
			upgradeLevelArtillery++;
		}
	}
	public void upgradeArmor() {
		if (upgradeLevelArmor == 1) {
			currentTextArmor.text = upgradeArmor2;
			upgradeTextArmor.text = upgradeArmor3;
			upgradeLevelArmor++;
		} else if (upgradeLevelArmor == 2) {
			currentTextArmor.text = upgradeArmor3;
			upgradeTextArmor.text = "No more!";
			upgradeLevelArmor++;
		}
	}
	
	
	private string upgradeInfantry1 = "Level 1 – Roman Legionary – available at start" +
		"\nAttack: 1" +
			"\nLife: 2" +
			"\nDexterity: 10%" +
			"\nSpeed: 5" +
			"\nRange: 1";
	private string upgradeInfantry2 = "Level 2 – Armored Legionary – 1000 denarii to unlock " +
		"\nAttack: 1 " +
			"\nLife: 4 " +
			"\nDexterity: 15% " +
			"\nSpeed: 4 " +
			"\nRange: 1";
	private string upgradeInfantry3 = "Level 3 – Elite Legionary – 1000 denarii to unlock " +
		"\nAttack: 3 " +
			"\nLife: 4 " +
			"\nDexterity: 15% " +
			"\nSpeed: 6 " +
			"\nRange: 1";
	private string upgradeInfantry4 = "Level 4 – Praetorian Guard – 5000 denarii to unlock " +
		"\nAttack: 5 " +
			"\nLife: 5 " +
			"\nDexterity: 25% " +
			"\nSpeed: 7 " +
			"\nRange: 1";
	
	private string upgradeArchers1 = "Roman Archer – 1500 denarii to unlock " +
		"\nAttack: 1 " +
			"\nLife: 1 " +
			"\nDexterity: 15% " +
			"\nSpeed: 5 " +
			"\nRange: 10";
	private string upgradeArchers2 = "";
	private string upgradeArchers3 = "";
	private string upgradeArchers4 = "";
	
	private string upgradeArtillery1 = "Scorpio – basic version available at start" +
		"\nAttack: 2 " +
			"\nLife: 4 " +
			"\nSpeed: 3 " +
			"\nRange: 10";
	private string upgradeArtillery2 = "Poisoned Bolt (A=4) – 500 denarii";
	private string upgradeArtillery3 = "Spiral Fletchings (R=13) – 500 denarii";
	private string upgradeArtillery4 = "High Tension String (can attack stationary objects) -- 750 denarii";
	private string upgradeArtillery5 = "Fiery Bolt (A=5) – 1000 denarii";
	private string upgradeArtillery6 = "Straight Shafts (R=15) – 1000 denarii";
	private string upgradeArtillery7 = "Armor-Piercing Bolt (A=6) – 5000 denarii";
	
	private string upgradeArmor1 = "Level 1 – Battering Rams (vs. stationary objects only) – available at start " +
		"\nAttack: 10 " +
			"\nLife: 5 " +
			"\nSpeed: 4 " +
			"\nRange: 1";
	private string upgradeArmor2 = "Level 2 – Siege Tower – 500 denarii to unlock" +
		"\nAttack: 15 " +
			"\nLife: 10 " +
			"\nSpeed: 2 " +
			"\nRange: 1";
	private string upgradeArmor3 = "Level 3 – Armored Tower – 3000 denarii to unlock " +
		"\nAttack: 15 " +
			"\nLife: 15 " +
			"\nSpeed: 3 " +
			"\nRange: 1";
	private string upgradeArmor4 = "";
}
