using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button_Behavior : MonoBehaviour {

	public GameObject room_turret;
	public Drawer_Behaviour draw;
	public spawner_behavior spawny;
	public int cost;
	public int turret_type;
	public int times_clicked;

	// Use this for initialization
	void Start () {
		draw = GameObject.Find ("Drawer").GetComponent<Drawer_Behaviour> ();
		spawny = GameObject.Find ("spawner").GetComponent<spawner_behavior> ();
		times_clicked = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GotoMenu(){
		SceneManager.LoadScene (0);
	}

	//Call this function when a room is clicked and we need to open the drawer
	public void Open_Menu(){
		draw.moving_dir = -1;
		draw.cur_turret = room_turret;
		GameObject.Find ("pointer").transform.position = new Vector3(room_turret.transform.position.x,room_turret.transform.position.y,-8);
		//Set the sprite of the drawer based on the status of the turret
		bool active = room_turret.GetComponent<Turret_Behavior>().active;
		if (active) {draw.Change_Mode (2);} 
		else {draw.Change_Mode (1);}

		if (active) {
			Vector3 new_pos = new Vector3 (1000f, 1000f, 0f);
			GameObject.Find ("zombie_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("skeleton_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("ghost_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("book_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("chand_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("knife_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;

			draw.z_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, 260f, 0f);
			draw.s_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, 170f, 0f);
			draw.g_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, 80f, 0f);
			draw.b_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, -70f, 0f);
			draw.k_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, -160f, 0f);
			draw.c_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, -240f, 0f);

			draw.u_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 190f, 0f);
			draw.r_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 10f, 0f);
		} else {
			Vector3 new_pos = new Vector3 (1000f, 1000f, 0f);
			GameObject.Find ("zombie_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("skeleton_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("ghost_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("book_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("chand_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("knife_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;

			draw.u_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 1900f, 0f);
			draw.r_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, -1000f, 0f);
		}

	}

	//Call this function when the turret creation buttons are pressed
	public void Set_Turret(){
		//First make sure we have enough gold
		if (cost <= spawny.gold) {
			spawny.gold -= cost;
			//Set the turret
			room_turret = draw.cur_turret;
			room_turret.GetComponent<Turret_Behavior>().Change_Type(turret_type);
			//Set the drawer to upgrade mode
			draw.Change_Mode (2);
			Vector3 new_pos = new Vector3 (1000f, 1000f, 0f);
			GameObject.Find ("zombie_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("skeleton_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("ghost_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("book_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("chand_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("knife_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;

			draw.z_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, 260f, 0f);
			draw.s_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, 170f, 0f);
			draw.g_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, 80f, 0f);
			draw.b_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, -70f, 0f);
			draw.k_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, -160f, 0f);
			draw.c_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (8500f, -240f, 0f);

			draw.u_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 190f, 0f);
			draw.r_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 10f, 0f);


			//Play sound
			AudioSource aud = GameObject.Find("Turret Data Loader").GetComponent<AudioSource>();
			if (turret_type == 1) {
				aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().book_sound;
			}
			else if (turret_type == 2) {
				aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().knife_sound;
			}
			else if (turret_type == 3) {
				aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().chand_sound;
			}

			else if (turret_type == 4) {
				aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().ghost_sound;
			}

			else if (turret_type == 6) {
				aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().skeleton_sound;
			}

			else if (turret_type == 5) {
				aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().zombie_sound;
			}
			aud.Play ();

		}
	}

	public void Upgrade_Turret(){
		times_clicked += 1;
		//Make sure we have enough gold
		if (20 <= spawny.gold) {
			times_clicked += 1;
			spawny.gold -= 20;
			room_turret = draw.cur_turret;
			//Upgrade the turret
			room_turret.GetComponent<Turret_Behavior>().Upgrade();

			//Close the drawer
			//draw.moving_dir = 1;
			Vector3 new_pos = new Vector3 (1000f, 1000f, 0f);
			GameObject.Find ("zombie_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("skeleton_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("ghost_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("book_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("chand_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
			GameObject.Find ("knife_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;

			draw.u_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 190f, 0f);
			draw.r_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 10f, 0f);

			draw.Change_Mode (2);
		}
	}

	public void Refund_Turret(){
		times_clicked += 1;
		room_turret = draw.cur_turret;
		room_turret.GetComponent<Turret_Behavior> ().Refund ();
		draw.Change_Mode (1);
		draw.u_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 1900f, 0f);
		draw.r_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, -1000f, 0f);
	}


}
