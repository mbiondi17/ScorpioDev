using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarracksUpgrade : MonoBehaviour {

	//Text Fields that contain information about the next purchasable upgrade 
	public Text upgradeAtkInfantry;
	public Text upgradeSpdInfantry;
	public Text upgradeDexInfantry;
	public Text upgradeLifeInfantry;

	public Text upgradeAtkArchers;
	public Text upgradeLifeArchers;
	public Text upgradeDexArchers;
	public Text upgradeRngArchers;
	
	public Text upgradeAtkArtillery;
	public Text upgradeLifeArtillery;
	public Text upgradeRngArtillery;

	public Text upgradeAtkArmor;
	public Text upgradeLifeArmor;
	public Text upgradeSpdArmor;

	//Text Fields that display current unit stats (with all purchased upgrades applied)
	public Text currentTextInfantry;
	public Text currentTextArchers;
	public Text currentTextArtillery;
	public Text currentTextArmor;

	//Displays remaining currency
	public Text denariiTextBox;
	
	public int denarii;
	
	public GameManager gameManager;

	void Update() {
		GameObject[] bCanv = GameObject.FindGameObjectsWithTag ("BarracksCanvas");
		if (bCanv.Length > 1) {
			foreach (GameObject bcanv in bCanv) {
				if (bcanv.transform.FindChild ("Denarii").GetComponent<Text> ().text == "<Denarii>") {
					Destroy (bcanv);
				}
			}
		}

	}
	
	//Initialize all upgrade buttons to display the proper stats and available upgrades
	void Start() {
		//GameManager used to edit denarii remaining and get/change stats
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

		denarii = gameManager.denarii;
		Debug.Log ("Denarii: " + denarii);

		denariiTextBox.text = "Denarii: " + denarii;

		//Set all upgrade texts to the proper values
		updateCurrInfText ();
		updateCurrArchText ();
		updateCurrArmText ();
		updateCurrArtText ();

		//Initial Upgrades text
		upgradeAtkInfantry.text = "Next Upgrade: Fine Steel (+1 Atk) Cost: 500";
		upgradeSpdInfantry.text = "Next Upgrade: Lightweight Armor (+0.5 Speed) Cost: 600";
		upgradeDexInfantry.text = "Next Upgrade: Wooden Shield (+3% Dex) Cost: 200";
		upgradeLifeInfantry.text = "Next Upgrade: Leather Armor (+2 Life) Cost: 400";

		upgradeLifeArchers.text = "Next Upgrade: Leather Armor (+2 Life) Cost: 400";
		upgradeAtkArchers.text = "Next Upgrade: Barbed Arrowheads (+1 Damage) Cost: 600";
		upgradeRngArchers.text = "Next Upgrade: Recurve Bow (+5 Range) Cost: 500";
		upgradeDexArchers.text = "Next Upgrade: Footwork Training (+5% Dex) Cost: 300";

		upgradeLifeArmor.text = "Next Upgrade: Iron Sides (+3 Life) Cost: 500";
		upgradeAtkArmor.text = "Next Upgrade: Hardwood Ram (+1 Atk) Cost: 300";
		upgradeSpdArmor.text = "Next Upgrade: Greased Gears (+ 0.5 Spd) Cost: 600";

		upgradeAtkArtillery.text = "Next Upgrade: Heavy Bolt (+1 Atk) Cost: 300";
		upgradeRngArtillery.text = "Next Upgrade: Supple Wood (+5 Rng) Cost: 500";
		upgradeLifeArtillery.text = "Next Upgrade: Iron Reinforced (+3 Life) Cost: 400";
	}

	public void upgradeInfantryAtk() {

		int currAtk = gameManager.infAttack;

		if (currAtk == 2 && gameManager.denarii >= 500) {
			gameManager.denarii -= 500;
			gameManager.infAttack = 3;
			updateCurrInfText ();
			upgradeAtkInfantry.text = "Next Upgrade: Honed Blades (+1 Atk) Cost: 750";
		} else if (currAtk == 3 && gameManager.denarii >= 750) {
			gameManager.denarii -= 750;
			gameManager.infAttack = 4;
			upgradeAtkInfantry.text = "Next upgrade: Damascus Steel (+2 Atk) Cost: 1000";
		} else if (currAtk == 4 && gameManager.denarii >= 1000) {
			gameManager.denarii -= 1000;
			gameManager.infAttack = 6;
			upgradeAtkInfantry.text = "All Upgrades Purchased!";
		}

		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();

	}

	public void upgradeInfantrySpd() {
		
		float currSpd = gameManager.infSpeed;
		if (currSpd == 1.0f && gameManager.denarii >= 600) {
			gameManager.denarii -= 600;
			gameManager.infSpeed = 1.5f;
			updateCurrInfText ();
			upgradeSpdInfantry.text = "Next Upgrade: Adv. Cardio (+0.5 Speed) Cost: 1000";
		} else if (currSpd == 1.5f && gameManager.denarii >= 1000) {
			gameManager.denarii -= 1000;
			gameManager.infSpeed = 2.0f;
			updateCurrInfText ();
			upgradeSpdInfantry.text = "All Upgrades Purchased!";
		}

		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeInfantryDex() {
		
		int currDex = gameManager.infDex;
		
		if (currDex == 15 && gameManager.denarii >= 300) {
			gameManager.denarii -= 300;
			gameManager.infDex = 18;
			updateCurrInfText ();
			upgradeDexInfantry.text = "Next Upgrade: Iron Shield (+3% Dex) Cost: 500";
		} else if (currDex == 18 && gameManager.denarii >= 500) {
			gameManager.denarii -= 500;
			gameManager.infDex = 21;
			updateCurrInfText ();
			upgradeDexInfantry.text = "Next upgrade: Steel Shield (+ 4% Dex) Cost: 750";
		} else if (currDex == 21 && gameManager.denarii >= 750) {
			gameManager.denarii -= 750;
			gameManager.infDex = 25;
			updateCurrInfText ();
			upgradeDexInfantry.text = "Next upgrade: Broad Shield (+ 5% Dex) Cost: 1000";
		} else if (currDex == 25 && gameManager.denarii >= 1000) {
			gameManager.denarii -= 1000;
			gameManager.infDex = 30;
			updateCurrInfText ();
			upgradeDexInfantry.text = "All Upgrades Purchased!";
		}
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeInfantryLife() {
		
		int currHealth = gameManager.infHealth;
		
		if (currHealth == 10 && gameManager.denarii >= 400) {
			gameManager.denarii -= 400;
			gameManager.infHealth = 12;
			updateCurrInfText ();
			upgradeLifeInfantry.text = "Next Upgrade: Chain Mail (+3 Life) Cost: 600";
		} else if (currHealth == 12 && gameManager.denarii >= 600) {
			gameManager.denarii -= 600;
			gameManager.infHealth = 14;
			updateCurrInfText ();
			upgradeLifeInfantry.text = "Next upgrade: Plate Armor (+4 Life) Cost: 750";
		} else if (currHealth == 14 && gameManager.denarii >= 750) {
			gameManager.denarii -= 750;
			gameManager.infHealth = 17;
			updateCurrInfText ();
			upgradeLifeInfantry.text = "Next upgrade: Beaten Steel Plate (+5 Life) Cost: 1000";
		} else if (currHealth == 17 && gameManager.denarii >= 1000) {
			gameManager.denarii -= 1000;
			gameManager.infHealth = 22;
			updateCurrInfText ();
			upgradeLifeInfantry.text = "All Upgrades Purchased";
		}
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeArcherLife() {
		
		int currHealth = gameManager.archHealth;
		
		if (currHealth == 10 && gameManager.denarii >= 400) {
			gameManager.denarii -= 400;
			gameManager.archHealth = 12;
			updateCurrArchText ();
			upgradeLifeArchers.text = "Next Upgrade: Bracers (+2 Life) Cost: 500";
		} else if (currHealth == 12 && gameManager.denarii >= 500) {
			gameManager.denarii -= 500;
			gameManager.archHealth = 14;
			updateCurrArchText ();
			upgradeLifeArchers.text = "Next upgrade: Light Chain Mail (+2 Life) Cost: 600";
		} else if (currHealth == 14 && gameManager.denarii >= 600) {
			gameManager.denarii -= 600;
			gameManager.archHealth = 16;
			updateCurrArchText ();
			upgradeLifeArchers.text = "All Upgrades Purchased!";
		} 

		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeArcherAtk() {
		
		int currAtk = gameManager.archAttack;
		
		if (currAtk == 1 && gameManager.denarii >= 600) {
			gameManager.denarii -= 600;
			gameManager.archAttack = 2;
			updateCurrArchText ();
			upgradeAtkArchers.text = "Next Upgrade: Bodkin Tips (+1 Atk) Cost: 600";
		} else if (currAtk == 2 && gameManager.denarii >= 600) {
			gameManager.denarii -= 600;
			gameManager.archAttack = 3;
			updateCurrArchText ();
			upgradeAtkArchers.text = "Next upgrade: Fire Arrows (+1 Atk) Cost: 700";
		} else if (currAtk == 3 && gameManager.denarii >= 700) {
			gameManager.denarii -= 700;
			gameManager.archAttack = 4;
			updateCurrArchText ();
			upgradeAtkArchers.text = "All Upgrades Purchased!";
		} 
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeArcherDex() {
		
		int currDex = gameManager.archDex;
		
		if (currDex == 25 && gameManager.denarii >= 300) {
			gameManager.denarii -= 300;
			gameManager.archDex = 30;
			updateCurrArchText ();
			upgradeDexArchers.text = "All Upgrades Purchased!";
		}
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeArcherRng() {
		
		int currRng = gameManager.archRange;
		
		if (currRng == 35 && gameManager.denarii >= 500) {
			gameManager.denarii -= 500;
			gameManager.archRange = 40;
			updateCurrArchText ();
			upgradeRngArchers.text = "Next Upgrade: Straight Shafts (+5 Range) Cost: 750";
		} else if (currRng == 40 && gameManager.denarii >= 750) {
			gameManager.denarii -= 750;
			gameManager.archRange = 45;
			updateCurrArchText ();
			upgradeRngArchers.text = "Next upgrade: Spiraled Fletching (+5 Range) Cost: 750";
		} else if (currRng == 45 && gameManager.denarii >= 750) {
			gameManager.denarii -= 750;
			gameManager.archRange = 50;
			updateCurrArchText ();
			upgradeRngArchers.text = "All Upgrades Purchased!";
		} 
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeArmorLife() {
		
		int currHealth = gameManager.armHealth;
		
		if (currHealth == 20 && gameManager.denarii >= 500) {
			gameManager.denarii -= 500;
			gameManager.armHealth = 23;
			updateCurrArmText ();
			upgradeLifeArmor.text = "Next Upgrade: Fire-Resistant Wood (+3 Life) Cost: 750";
		} else if (currHealth == 23 && gameManager.denarii >= 750) {
			gameManager.denarii -= 750;
			gameManager.armHealth = 26;
			updateCurrArmText ();
			upgradeLifeArmor.text = "Next upgrade: Spear Defenses (+ 4 Life) Cost: 1000";
		} else if (currHealth == 26 && gameManager.denarii >= 1000) {
			gameManager.denarii -= 1000;
			gameManager.armHealth = 30;
			updateCurrArmText ();
			upgradeLifeArmor.text = "All Upgrades Purchased!";
		} 
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeArmorAtk() {
		
		int currAtk = gameManager.armAttack;
		
		if (currAtk == 2 && gameManager.denarii >= 300) {
			gameManager.denarii -= 300;
			gameManager.armAttack = 3;
			updateCurrArmText ();
			upgradeAtkArmor.text = "Next Upgrade: Iron-Tipped Ram (+1 Atk) Cost: 500";
		} else if (currAtk == 3 && gameManager.denarii >= 500) {
			gameManager.denarii -= 500;
			gameManager.armAttack = 4;
			updateCurrArmText ();
			upgradeAtkArmor.text = "Next upgrade: Steel-Tipped Ram (+ 1 Atk) Cost: 700";
		} else if (currAtk == 4 && gameManager.denarii >= 700) {
			gameManager.denarii -= 700;
			gameManager.armAttack = 5;
			updateCurrArmText ();
			upgradeAtkArmor.text = "Next Upgrade: Heavy Ram (+1 Atk) Cost: 900";
		} else if (currAtk == 5 && gameManager.denarii >= 900) {
			gameManager.denarii -= 900;
			gameManager.armAttack = 6;
			updateCurrArmText ();
			upgradeAtkArmor.text = "Next Upgrade: Massive Ram (+1 Atk) Cost: 1000";
		} else if (currAtk == 6 && gameManager.denarii >= 1000) {
			gameManager.denarii -= 1000;
			gameManager.armAttack = 7;
			updateCurrArmText ();
			upgradeAtkArmor.text = "All Upgrades Purchased!";
		}
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeArmorSpeed() {
		
		float currSpd = gameManager.armSpeed;
		
		if (currSpd == 0.5f && gameManager.denarii >= 600) {
			gameManager.denarii -= 600;
			gameManager.armSpeed = 1.0f;
			updateCurrArmText ();
			upgradeSpdArmor.text = "Next Upgrade: Lightweight Materials (+0.5 Spd) Cost: 800";
		} else if (currSpd == 1.0f && gameManager.denarii >= 800) {
			gameManager.denarii -= 800;
			gameManager.armSpeed = 1.5f;
			updateCurrArmText ();
			upgradeSpdArmor.text = "All Upgrades Purchased!";
		} 
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeArtilleryAtk() {
		
		int currAtk = gameManager.artAttack;
		
		if (currAtk == 2 && gameManager.denarii >= 300) {
			gameManager.denarii -= 300;
			gameManager.artAttack = 3;
			updateCurrArtText ();
			upgradeAtkArtillery.text = "Next Upgrade: Barbed Tip (+1 Atk) Cost: 500";
		} else if (currAtk == 3 && gameManager.denarii >= 500) {
			gameManager.denarii -= 500;
			gameManager.artAttack = 4;
			updateCurrArtText ();
			upgradeAtkArtillery.text = "Next Upgrade: Precise Shot (+1 Atk) Cost: 700";
		} else if (currAtk == 4 && gameManager.denarii >= 700) {
			gameManager.denarii -= 700;
			gameManager.artAttack = 5;
			updateCurrArtText ();
			upgradeAtkArtillery.text = "Next Upgrade: Taut Strings (+1 Atk) Cost: 900";
		} else if (currAtk == 5 && gameManager.denarii >= 900) {
			gameManager.denarii -= 900;
			gameManager.artAttack = 6;
			updateCurrArtText ();
			upgradeAtkArtillery.text = "Next Upgrade: Fire Bolt (+1 Atk) Cost: 1000";
		} else if (currAtk == 6 && gameManager.denarii >= 1000) {
			gameManager.denarii -= 1000;
			gameManager.artAttack = 7;
			updateCurrArtText ();
			upgradeAtkArtillery.text = "All Upgrades Purchased!";
		}
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeArtilleryRng() {
		
		int currRng= gameManager.artRange;
		
		if (currRng == 30 && gameManager.denarii >= 500) {
			gameManager.denarii -= 500;
			gameManager.artRange = 35;
			updateCurrArtText ();
			upgradeRngArtillery.text = "Next Upgrade: High-Tension Strings (+5 Rng) Cost: 750";
		} else if (currRng == 35 && gameManager.denarii >= 750) {
			gameManager.denarii -= 750;
			gameManager.artRange = 40;
			updateCurrArtText ();
			upgradeRngArtillery.text = "Next Upgrade: Stronger Arms (+5 Rng) Cost: 1000";
		} else if (currRng == 40 && gameManager.denarii >= 0-00) {
			gameManager.denarii -= 1000;
			gameManager.artRange = 45;
			updateCurrArtText ();
			upgradeRngArtillery.text = "All Upgrades Purchased!";
		}
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	public void upgradeArtilleryLife() {
		
		int currLif = gameManager.artHealth;
		
		if (currLif == 15 && gameManager.denarii >= 400) {
			gameManager.denarii -= 400;
			gameManager.artHealth = 18;
			updateCurrArtText ();
			upgradeLifeArtillery.text = "Next Upgrade: Sturdy Construction (+3 Life) Cost: 600";
		} else if (currLif == 18 && gameManager.denarii >= 600) {
			gameManager.denarii -= 600;
			gameManager.artHealth = 21;
			updateCurrArtText ();
			upgradeLifeArtillery.text = "Next Upgrade: Treated Wood (+4 Life) Cost: 800";
		} else if(currLif == 21 && gameManager.denarii >= 800) {
			gameManager.denarii -= 800;
			gameManager.artHealth = 25;
			updateCurrArtText ();
			upgradeLifeArtillery.text = "All Upgrades Purchased!";
		} 
		
		denariiTextBox.text = "Denarii: " + gameManager.denarii.ToString ();
		
	}

	private void updateCurrInfText () {
		currentTextInfantry.text = 
			"Roman Legionary" +
			"\nAttack: " + gameManager.infAttack +
			"\nLife: " + gameManager.infHealth +
			"\nDexterity: " + gameManager.infDex + "%" +
			"\nSpeed: " + gameManager.infSpeed +
			"\nRange: " + gameManager.infRange;
	}
	private void updateCurrArchText () {
		currentTextArchers.text = 
			"Roman Archer" +
			"\nAttack: " + gameManager.archAttack + 
			"\nLife: " + gameManager.archHealth + 
			"\nDexterity: " + gameManager.archDex + "%" +
			"\nSpeed: " + gameManager.archSpeed +
			"\nRange: " + gameManager.archRange;
	}
	private void updateCurrArtText () {
		currentTextArtillery.text =
			"Scorpio" +
			"\nAttack: " + gameManager.artAttack +
			"\nLife: " + gameManager.artHealth +
			"\nSpeed: " + gameManager.artSpeed +
			"\nRange: " + gameManager.artRange;
	}
	private void updateCurrArmText () {
		currentTextArmor.text = 
			"Battering Rams" +
			"\nAttack: " + gameManager.armAttack +
			"\nLife: " + gameManager.armHealth +
			"\nSpeed: " + gameManager.armSpeed +
			"\nRange: " + gameManager.armRange;
	}

}
