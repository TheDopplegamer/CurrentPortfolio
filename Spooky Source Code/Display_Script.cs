using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display_Script : MonoBehaviour {

	public int type;
	Drawer_Behaviour draw;
	spawner_behavior spawny;
	public int cost;

	// Use this for initialization
	void Start () {
		draw = GameObject.Find ("Drawer").GetComponent<Drawer_Behaviour> ();
		spawny = GameObject.Find ("spawner").GetComponent<spawner_behavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Display gold
		if (type == 1) {
			string display = spawny.gold.ToString ();
			gameObject.GetComponent<Text> ().text = "SOULS: " + display;
		}
		//Display Wave Number
		else if (type == 2) {
			string display = spawny.level.ToString ();
			gameObject.GetComponent<Text> ().text = "WAVE: " + display;
		}

		//Display Upgrade Cost
		else if (type == 3) {
			string display = "";
			if (draw.cur_turret.GetComponent<Turret_Behavior> ().upgraded) {
				display = "UPGRADED!";
			} else {
				display = draw.cur_turret.GetComponent<Turret_Behavior> ().upgrade_cost.ToString ();
			}
			gameObject.GetComponent<Text> ().text = display;
		}
		//Display Create Cost
		else if (type == 4) {
			string display = cost.ToString ();
			gameObject.GetComponent<Text> ().text = display;
		}
		//Display Refund Cost
		else if (type == 5) {
			string display = draw.cur_turret.GetComponent<Turret_Behavior> ().refund.ToString ();
			gameObject.GetComponent<Text> ().text = display;
		}
	}
}
