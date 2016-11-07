using UnityEngine;
using System.Collections;

public class door_behavior : MonoBehaviour {

	public int HP;

	public Sprite spoopy_sprite;
	public Sprite spoopy_sprite_1;
	public Sprite spoopy_sprite_2;

	public bool done;


	// Use this for initialization
	void Start () {
		HP = 5;
		done = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void check_death(){
		if (HP <= 0) {
			HP = 0;
			Vector3 new_pos = new Vector3 (transform.position.x, transform.position.y, 4f);
			transform.position = new_pos;

			GameObject.Find ("Spoopy").GetComponent<SpriteRenderer> ().sprite = spoopy_sprite_2;
		} else if (HP == 1) {
			GameObject.Find ("Spoopy").GetComponent<SpriteRenderer> ().sprite = spoopy_sprite_1;
		}


		//Update Icons
		float z1;
		float z2;
		float z3;
		float z4;
		float z5;

		if (HP == 0) {
			z1 = 10f;
			z2 = 10f;
			z3 = 10f;
			z4 = 10f;
			z5 = 10f;
		}
		else if (HP == 1) {
			z1 = 10f;
			z2 = 10f;
			z3 = 10f;
			z4 = 10f;
			z5 = 0f;
		}
		else if (HP == 2) {
			z1 = 10f;
			z2 = 10f;
			z3 = 10f;
			z4 = 0f;
			z5 = 0f;
		}
		else if (HP == 3) {
			z1 = 10f;
			z2 = 10f;
			z3 = 0f;
			z4 = 0f;
			z5 = 0f;
		}
		else if (HP == 4) {
			z1 = 10f;
			z2 = 0f;
			z3 = 0f;
			z4 = 0f;
			z5 = 0f;
		}
		else{
			z1 = 0f;
			z2 = 0f;
			z3 = 0f;
			z4 = 0f;
			z5 = 0f;
		}

		Vector3 pos1 = new Vector3 (2f, 8.5f, z1);
		Vector3 pos2 = new Vector3 (1f, 8.5f, z2);
		Vector3 pos3 = new Vector3 (0f, 8.5f, z3);
		Vector3 pos4 = new Vector3 (-1f, 8.5f, z4);
		Vector3 pos5 = new Vector3 (-2f, 8.5f, z5);

		GameObject.Find ("HP1").transform.position = pos1;
		GameObject.Find ("HP2").transform.position = pos2;
		GameObject.Find ("HP3").transform.position = pos3;
		GameObject.Find ("HP4").transform.position = pos4;
		GameObject.Find ("HP5").transform.position = pos5;


		if (done == false && HP <= 0) {
			GameObject[] en_list = GameObject.FindGameObjectsWithTag ("Enemy");
			int n = 0;
			while (n < en_list.Length) {
				GameObject en = en_list [n];
				en.GetComponent<creep_behaviour> ().pause = true;
				n += 1;
			}
			done = true;
			gameObject.GetComponent<AudioSource> ().Play ();
			GameObject.Find ("game over screen").GetComponent<game_over_scroll> ().Begin_Scroll ();
			GameObject.Find ("Spoopy").GetComponent<AudioSource> ().Stop ();
		}

	}
}
