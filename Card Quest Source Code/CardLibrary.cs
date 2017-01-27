using UnityEngine;
using System.Collections;

public class CardLibrary : MonoBehaviour {

	//The Card Library is used to hold the scripts for every card function
	TextScript TextBox;



	void Start(){
		TextBox = GameObject.Find ("Text_Display").GetComponent<TextScript> ();
	}


	//Constitution Skills
	//--------------------------------------------------------------------------

	//Use a shield to block incoming attack
	public void Shield(){

	}

	//Heal some HP
	public void Light_Heal(){

	}

	//Lifesteal attack
	public void Lifesteal(){

	}

	//Recover card from discard pile
	public void Recover(){

	}

	//Constitution Special Interaction


	//Strength Skills
	//--------------------------------------------------------------------------

	//Attack with fists
	public void Hit(){

	}

	//Berzerk Rush with recoil damage
	public void Berzerk_Rush(){

	}

	//Attack with weapon
	public void Swing(){

	}

	//Draw more cards from the deck
	public void Power_Up(){

	}

	//Strength Special Interaction


	//Intelligence Skills
	//--------------------------------------------------------------------------

	//Weak Fire Attack
	public void Burn(){

	}

	//Strong Fire Attack
	public void Eruption(){

	}

	//Weak Water Attack
	public void Wave(){

	}

	//Strong Water Attack
	public void Maelstrom(){

	}

	//Weak Earth Attack
	public void Stone(){

	}

	//Strong Earth Attack
	public void Quake(){

	}

	//Weak Wind Attack
	public void Air(){

	}

	//Strong Wind Attack
	public void Lightning(){

	}

	//Intelligence Special Interaction


	//Dexterity Skills
	//--------------------------------------------------------------------------

	//Escape from Encounter
	public void Escape(){

	}

	//Deal Damage based on encounter strength
	public void Redirect(){

	}

	//Use several weak attacks
	public void Multislash(){

	}

	//Steal from encounter
	public void Steal(){

	}

	//Dexterity Special Interaction

	//Luck Skills
	//--------------------------------------------------------------------------

	//Deal a random amount of damage
	public void Jackbox(){

	}

	//Attack by throwing money
	public void Coin_Toss(){

	}

	//Gamble money
	public void Gamble(){

	}

	//Randomly Transform Cards
	public void Surprise_Box(){

	}

	//Throw the banana at the encounter
	public void The_Banana(){

	}
		

}
