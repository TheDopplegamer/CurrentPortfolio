using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//The game manager is used to keep global variables between scenes, such as player stats and game info

	//The player's stats
	public int CON;
	public int STR;
	public int INT;
	public int DEX;
	public int LCK;

	public Sprite player_image;
	public Sprite warrior_image;
	public Sprite mage_image;
	public Sprite joker_image;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Used to increase or decrease a specific stat in the custom user creation menu
	public void Change_Stat(int stat,int amount){
		if (stat == 1) {
			CON += amount;
		}
		else if (stat == 2) {
			STR += amount;
		}
		else if (stat == 3) {
			INT += amount;
		}
		else if (stat == 4) {
			DEX += amount;
		}
		else{
			LCK += amount;
		}
	}

	public void Set_Image(int index){
		if (index == 1) {
			player_image = warrior_image;
		} else if (index == 2) {
			player_image = mage_image;
		} else {
			player_image = joker_image;
		}
	}

}
