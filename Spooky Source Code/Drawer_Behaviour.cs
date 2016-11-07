using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drawer_Behaviour : MonoBehaviour {

	public Sprite option_sprite;
	public Sprite upgrade_sprite;
	public Sprite minion_sprite;
	public int moving_dir;
	public GameObject cur_turret;
	bool played;

	public GameObject z_b;
	public GameObject g_b;
	public GameObject s_b;
	public GameObject b_b;
	public GameObject k_b;
	public GameObject c_b;

	public GameObject u_b;
	public GameObject r_b;

	// Use this for initialization
	void Start () {
		moving_dir = 0;
		played = false;
	}

	public void S_P(){
		if (!played) {
			gameObject.GetComponent<AudioSource> ().Play ();
			played = true;
		}
	}


	// Update is called once per frame
	void Update () {
		//Handle movement
		if(moving_dir != 0){
			//Move to the right
			if(moving_dir == 1){
				transform.Translate(Vector3.right * 6f * Time.deltaTime);
				if(transform.position.x >= 12.39f){
					moving_dir = 0;
					gameObject.transform.position = new Vector3(12.39f, 3.61f, -3f);
				}
			}
			//Move to the left
			else if(moving_dir == -1){
				S_P ();
				transform.Translate(Vector3.left * 6f * Time.deltaTime);
				if(transform.position.x <= 8.02f){
					moving_dir = 0;
					gameObject.transform.position = new Vector3(8.02f, 3.61f, -3f);
					if (gameObject.GetComponent<SpriteRenderer> ().sprite == minion_sprite) {
						Vector3 new_pos = new Vector3 (634f, 15f, 0f);
						GameObject.Find ("zombie_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
						GameObject.Find ("skeleton_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
						GameObject.Find ("ghost_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
						GameObject.Find ("book_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
						GameObject.Find ("chand_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
						GameObject.Find ("knife_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;

						z_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 260f, 0f);
						s_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 170f, 0f);
						g_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 80f, 0f);
						b_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, -70f, 0f);
						k_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, -160f, 0f);
						c_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, -240f, 0f);

					}
				}
			}
		}
	}

	//Change the mode of the drawer
	public void Change_Mode(int m){
		//Minion mode
		if (m == 1) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = minion_sprite;
			if (transform.position.x <= 8.02f) {
				Vector3 new_pos = new Vector3 (634f, 15f, 0f);
				GameObject.Find ("zombie_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
				GameObject.Find ("skeleton_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
				GameObject.Find ("ghost_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
				GameObject.Find ("book_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
				GameObject.Find ("chand_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;
				GameObject.Find ("knife_button").GetComponent<RectTransform> ().anchoredPosition3D = new_pos;

				z_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 260f, 0f);
				s_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 170f, 0f);
				g_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, 80f, 0f);
				b_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, -70f, 0f);
				k_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, -160f, 0f);
				c_b.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (850f, -240f, 0f);

				GameObject.Find ("upgrade button").GetComponent<RectTransform> ().anchoredPosition3D = new Vector3(7240f,50f,0f);
				GameObject.Find ("refund button").GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (7240f, 50f, 0f);

			}
		}
		//Upgrade Mode
		else if (m == 2) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = upgrade_sprite;
			if (transform.position.x <= 8.02f) {
				GameObject.Find ("upgrade button").GetComponent<RectTransform> ().anchoredPosition3D = new Vector3(724f,50f,0f);
				GameObject.Find ("refund button").GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (724f, 50f, 0f);

			}
		}
		//Options Mode
		else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = option_sprite;
		}
	}
		
		
}
