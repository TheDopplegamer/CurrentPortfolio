using UnityEngine;
using System.Collections;

public class move_point_behavior : MonoBehaviour {

	public Vector3 new_pos;
	public Vector3 new_dir;
	public int dir_set;
	public int num_entered;

	// Use this for initialization
	void Start () {
		//new_pos = new Vector3 (0, 0, 0);
		//new_dir = new Vector3 (0, 0, 0);
		//dir_set = 1;
		num_entered = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Call this when a creep enters its box
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			if (dir_set == 5) {

				//Widen the box collider
				BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
				box.offset = new Vector2 (box.offset.x + 0.0945721f, box.offset.y);
				box.size = new Vector2 (box.size.x + 0.1891405f, box.size.y);

				num_entered += 1;
				GameObject.Find ("door").GetComponent<door_behavior> ().HP -= 1;
				GameObject.Find ("door").GetComponent<door_behavior> ().check_death ();
				GameObject enemy = other.gameObject;
				enemy.GetComponent<creep_behaviour> ().done = true;
				int g = enemy.GetComponent<creep_behaviour> ().age;


				if (enemy.GetComponent<creep_behaviour> ().gender == 0) {
					if (g == 1) {
						enemy.GetComponent<SpriteRenderer> ().sprite = enemy.GetComponent<creep_behaviour> ().child_push_sprite;
					} else if (g == 2) {
						enemy.GetComponent<SpriteRenderer> ().sprite = enemy.GetComponent<creep_behaviour> ().teen_push_sprite;
					} else {
						enemy.GetComponent<SpriteRenderer> ().sprite = enemy.GetComponent<creep_behaviour> ().adult_push_sprite;
					}
				} else {
					if (g == 1) {
						enemy.GetComponent<SpriteRenderer> ().sprite = enemy.GetComponent<creep_behaviour> ().child_push_spritef;
					} else if (g == 2) {
						enemy.GetComponent<SpriteRenderer> ().sprite = enemy.GetComponent<creep_behaviour> ().teen_push_spritef;
					} else {
						enemy.GetComponent<SpriteRenderer> ().sprite = enemy.GetComponent<creep_behaviour> ().adult_push_spritef;
					}
				}

			} else {




				num_entered += 1;
				other.gameObject.GetComponent<creep_behaviour> ().dir = new_dir;
				other.gameObject.transform.position = this.gameObject.transform.position;
	

				//Moving Left
				if (dir_set == 1) {
					other.gameObject.GetComponent<SpriteRenderer> ().flipX = false;
				}
		//Moving Right
		else if (dir_set == 2) {
					other.gameObject.GetComponent<SpriteRenderer> ().flipX = true;
				}

			}
		}

	}
}
