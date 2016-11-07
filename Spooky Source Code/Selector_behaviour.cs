using UnityEngine;
using System.Collections;

public class Selector_behaviour : MonoBehaviour {

	public int room_x;
	public int room_y;
	public GameObject cur_turret;

	public string up_key = "w";
	public string down_key = "s";
	public string left_key = "a";
	public string right_key = "d";

	 


	// Use this for initialization
	void Start () {
		room_x = 1;
		room_y = 1;
	}
	
	// Update is called once per frame
	void Update () {
		//Check for user input
		if (Input.GetKeyDown (up_key)) {
			if(room_y == 3){room_y = 1;}
			else{room_y += 1;}
			Change_Pos();
		}
		if (Input.GetKeyDown (down_key)) {
			if(room_y == 1){room_y = 3;}
			else{room_y -= 1;}
			Change_Pos();
		}
		if (Input.GetKeyDown (right_key)) {
			if(room_x == 3){room_x = 1;}
			else{room_x += 1;}
			Change_Pos();
		}
		if (Input.GetKeyDown (left_key)) {
			if(room_x == 1){room_x = 3;}
			else{room_x -= 1;}
			Change_Pos();
		}
	}


	void Change_Pos(){

	}
}
