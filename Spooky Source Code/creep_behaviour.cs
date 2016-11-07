using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creep_behaviour : MonoBehaviour {

	public int HP;
	public float move_speed;
	public int phase;
	public bool is_last;
	public Vector3 dir;
	public Sprite child_sprite;
	public Sprite teen_sprite;
	public Sprite adult_sprite;

	public Sprite last_sprite;
	public Sprite hurt_sprite;
	public Sprite scared_sprite;

	public int hurt_timer;

	public bool pause;

	public Sprite child_sprite_f;
	public Sprite teen_sprite_f;
	public Sprite adult_sprite_f;
	
	public Sprite child_sprite_w;
	public Sprite teen_sprite_w;
	public Sprite adult_sprite_w;
	
	public Sprite child_sprite_f_w;
	public Sprite teen_sprite_f_w;
	public Sprite adult_sprite_f_w;

	public Sprite child_push_sprite;
	public Sprite teen_push_sprite;
	public Sprite adult_push_sprite;

	public Sprite child_push_spritef;
	public Sprite teen_push_spritef;
	public Sprite adult_push_spritef;

	public Sprite child_hurt_sprite;
	public Sprite teen_hurt_sprite;
	public Sprite adult_hurt_sprite;

	public Sprite child_hurt_spritef;
	public Sprite teen_hurt_spritef;
	public Sprite adult_hurt_spritef;

	public Sprite child_scared_sprite;
	public Sprite teen_scared_sprite;
	public Sprite adult_scared_sprite;

	public Sprite child_scared_spritef;
	public Sprite teen_scared_spritef;
	public Sprite adult_scared_spritef;

	public Sprite child_scaredw_sprite;
	public Sprite teen_scaredw_sprite;
	public Sprite adult_scaredw_sprite;

	public Sprite child_scaredw_spritef;
	public Sprite teen_scaredw_spritef;
	public Sprite adult_scaredw_spritef;

	public AudioClip man_scream;
	public AudioClip woman_scream;

	public AudioClip guy_scream;
	public AudioClip gal_scream;

	public AudioClip boy_scream;
	public AudioClip girl_scream;

	public int knife_def;
	public int book_def;
	public int chand_def;

	public int ghost_def;
	public int zombie_def;
	public int skeleton_def;

	public Sprite stand_sprite;
	public Sprite walk_sprite;

	public bool def_increased;

	public int walk_timer;

	public int SP;

	public int gender;

	public bool done;

	public int age;
	
	public List<GameObject> turret_list;

	public AudioSource aud;

	public GameObject cur_door;

	// Use this for initialization
	void Start () {
		def_increased = false;
		knife_def = 0;
		book_def = 0;
		chand_def = 0;

		ghost_def = 0;
		zombie_def = 0;
		skeleton_def = 0;

		HP = 1;
		phase = 1;
		move_speed = 2f;
		gameObject.tag = "Enemy";
		hurt_timer = 0;

		aud = GetComponent<AudioSource>();

		is_last = false;
		done = false;

		gender = Random.Range (0, 2);

		pause = false;

		walk_timer = 0;

		dir = Vector3.left;

		int num = GameObject.Find ("spawner").GetComponent<spawner_behavior> ().total_spawn;

		int check_type = GameObject.Find ("spawner").GetComponent<spawner_behavior> ().spawn_list [num - 1];
		if (check_type == 1) {
			if (gender == 0) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = child_sprite;
				stand_sprite = child_sprite;
				walk_sprite = child_sprite_w;
				hurt_sprite = child_hurt_sprite;
				scared_sprite = child_scared_sprite;
				aud.clip = boy_scream;

			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = child_sprite_f;
				stand_sprite = child_sprite_f;
				walk_sprite = child_sprite_f_w;
				hurt_sprite = child_hurt_spritef;
				scared_sprite = child_scared_spritef;
				aud.clip = girl_scream;
			}
			move_speed = 3.14f;
			HP = 10;
			age = 1;
			SP = 8;
		} else if (check_type == 2) {
			if (gender == 0) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = teen_sprite;
				stand_sprite = teen_sprite;
				walk_sprite = teen_sprite_w;
				hurt_sprite = teen_hurt_sprite;
				scared_sprite = teen_scared_sprite;
				aud.clip = guy_scream;
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = teen_sprite_f;
				stand_sprite = teen_sprite_f;
				walk_sprite = teen_sprite_f_w;
				hurt_sprite = teen_hurt_spritef;
				scared_sprite = teen_scared_spritef;
				aud.clip = gal_scream;
			}
			move_speed = 2.0f;
			HP = 10;
			age = 2;
			SP = 8;
		} else {
			if (gender == 0) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = adult_sprite;
				stand_sprite = adult_sprite;
				walk_sprite = adult_sprite_w;
				hurt_sprite = adult_hurt_sprite;
				scared_sprite = adult_scared_sprite;
				aud.clip = man_scream;
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = adult_sprite_f;
				stand_sprite = adult_sprite_f;
				walk_sprite = adult_sprite_f_w;
				hurt_sprite = adult_hurt_spritef;
				scared_sprite = adult_scared_spritef;
				aud.clip = woman_scream;
			}
			move_speed = 1.5f;
			HP = 10;
			SP = 8;
			age = 3;
		}

		transform.position = new Vector3(11f,-2f,0.0f);


	}

	public void Check_Death(){
		if (HP <= 0) {
			phase = -1;
			GameObject.Find("spawner").GetComponent<spawner_behavior>().gold += 3;
			gameObject.GetComponent<FadeObjectInOut>().fadeDelay = 1f;
			gameObject.GetComponent<FadeObjectInOut>().fadeTime = 1f;
			gameObject.GetComponent<FadeObjectInOut>().FadeOut();
		}
		if (SP <= 0) {
			phase = -1;
			GameObject.Find("spawner").GetComponent<spawner_behavior>().gold += 3;
			gameObject.GetComponent<FadeObjectInOut>().fadeDelay = 1f;
			gameObject.GetComponent<FadeObjectInOut>().fadeTime = 1f;
			gameObject.GetComponent<FadeObjectInOut>().FadeOut();
		}
	}

	public void Set_Sprite(int d){
		//Set normal sprites
		if (d == 0) {
			//Child
			if (age == 1) {
				//Boy
				if (gender == 0) {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = child_sprite;
					hurt_sprite = child_hurt_sprite;
					scared_sprite = child_scared_sprite;
					stand_sprite = child_sprite;
					walk_sprite = child_sprite_w;
				}
				//Girl
				else {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = child_sprite_w;
					hurt_sprite = child_hurt_spritef;
					scared_sprite = child_scared_spritef;
					stand_sprite = child_sprite_f;
					walk_sprite = child_sprite_f_w;
				}
			}
			//Teen
			else if (age == 2) {
				//Guy
				if (gender == 0) {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = teen_sprite;
					hurt_sprite = teen_hurt_sprite;
					scared_sprite = teen_scared_sprite;
					stand_sprite = teen_sprite;
					walk_sprite = teen_sprite_w;
				}
				//Gal
				else {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = teen_sprite_w;
					hurt_sprite = teen_hurt_spritef;
					scared_sprite = teen_scared_spritef;
					stand_sprite = teen_sprite_f;
					walk_sprite = teen_sprite_f_w;
				}
			}
			//Adult
			else if (age == 3) {
				//Man
				if (gender == 0) {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = adult_sprite;
					hurt_sprite = adult_hurt_sprite;
					scared_sprite = adult_scared_sprite;
					stand_sprite = adult_sprite;
					walk_sprite = adult_sprite_w;
				}
				//Woman
				else {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = adult_sprite_w;
					hurt_sprite = adult_hurt_spritef;
					scared_sprite = adult_scared_spritef;
					stand_sprite = adult_sprite_f;
					walk_sprite = adult_sprite_f_w;
				}
			}
		}
		//Set hurt sprites
		else if (d == 1) {
			//Child
			if (age == 1) {
				//Boy
				if (gender == 0) {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = child_hurt_sprite;
					stand_sprite = child_hurt_sprite;
					walk_sprite = child_hurt_sprite;
				}
				//Girl
				else {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = child_hurt_spritef;
					stand_sprite = child_hurt_spritef;
					walk_sprite = child_hurt_spritef;
				}
			}
			//Teen
			else if (age == 2) {
				//Boy
				if (gender == 0) {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = teen_hurt_sprite;
					stand_sprite = teen_hurt_sprite;
					walk_sprite = teen_hurt_sprite;
				}
				//Girl
				else {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = teen_hurt_spritef;
					stand_sprite = teen_hurt_spritef;
					walk_sprite = teen_hurt_spritef;
				}
			}
			//Adult
			else if (age == 3) {
				//Boy
				if (gender == 0) {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = adult_hurt_sprite;
					stand_sprite = adult_hurt_sprite;
					walk_sprite = adult_hurt_sprite;
				}
				//Girl
				else {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = adult_hurt_spritef;
					stand_sprite = adult_hurt_spritef;
					walk_sprite = adult_hurt_spritef;
				}
			}
		}
		//Set scared sprites
		else if (d == 2) {
			//Child
			if (age == 1) {
				//Boy
				if (gender == 0) {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = child_scared_sprite;
					stand_sprite = child_scared_sprite;
					walk_sprite = child_scaredw_sprite;
				}
				//Girl
				else {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = child_scared_spritef;
					stand_sprite = child_scared_spritef;
					walk_sprite = child_scaredw_spritef;
				}
			}
			//Teen
			else if (age == 2) {
				//Boy
				if (gender == 0) {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = teen_scared_sprite;
					stand_sprite = teen_scared_sprite;
					walk_sprite = teen_scaredw_sprite;
				}
				//Girl
				else {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = teen_scared_spritef;
					stand_sprite = teen_scared_spritef;
					walk_sprite = teen_scaredw_spritef;
				}
			}
			//Adult
			else if (age == 3) {
				//Boy
				if (gender == 0) {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = adult_scared_sprite;
					stand_sprite = adult_scared_sprite;
					walk_sprite = adult_scaredw_sprite;
				}
				//Girl
				else {
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = adult_scared_spritef;
					stand_sprite = adult_scared_spritef;
					walk_sprite = adult_scaredw_spritef;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {

		if (pause == false &&  hurt_timer == 0 && HP > 0 && SP > 0) {

			if (done == false) {
				//Handle Movement here
				transform.Translate (dir * move_speed * Time.deltaTime);
		
				walk_timer += 1;
				if (walk_timer >= 10) {
			
					walk_timer = 0;
					//get current sprite
					Sprite check = this.gameObject.GetComponent<SpriteRenderer> ().sprite;
					if (check == walk_sprite) {
						this.gameObject.GetComponent<SpriteRenderer> ().sprite = stand_sprite;
					} else {
						this.gameObject.GetComponent<SpriteRenderer> ().sprite = walk_sprite;
					}
				}
			}

		} else if(hurt_timer > 0){
			//Handle Movement here
			transform.Translate (dir * move_speed * Time.deltaTime);
			hurt_timer -= 1;
			if (hurt_timer == 8) {
				Check_Death ();
			}
			if (hurt_timer == 0) {
				Set_Sprite (0);
			}
		}
	}
}
