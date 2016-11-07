using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret_Behavior : MonoBehaviour {

	//The amount of damage being dealt
	public int damage;
	//The type of damage being dealt
	public bool lethal;
	//Whether or not the turret has been upgraded
	public bool upgraded;
	//The attacking status of the turret
	public bool attacking;
	//The amount of gold revieced from refunds
	public int refund;

	//Whether or not the turret is active at the moment
	public bool active;

	public int timer;
	public int cd_timer;

	public Sprite wait_sprite;
	public Sprite attack_sprite;
	public Sprite cooldown_sprite;


	
	public int upgrade_cost;

	public int entered;

	public int phase;

	//The type of turret
	//-------------------
	// 1 - Books
	// 2 - Knives
	// 3 - Chandeliers
	// 4 - Zombies
	// 5 - Ghosts
	// 6 - Skeletons
	public int type;


	//The door object that holds the creep list for the room
	public GameObject room_door;

	public GameObject[] last_target_list;
	public int last_targ_size;

	SpriteRenderer sprite_r;
	Animator animate;

	Turret_Animator slist;

	// Use this for initialization
	void Start () {
		upgrade_cost = 20;
		sprite_r = gameObject.GetComponent<SpriteRenderer> ();
		animate = gameObject.GetComponent<Animator> ();
		animate.speed = 0;
		transform.position = new Vector3 (transform.position.x, transform.position.y, 5);
		slist = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ();
		phase = 1;
		timer = 1;
		entered = 0;
		attacking = false;
		last_target_list = new GameObject[99];
		last_targ_size = 0;
		refund = 5;


	}


	
	// Update is called once per frame
	void Update () {
		if (active) {
			//Check to see if we are attacking
			//Check for constant DPS turrets
			if (type <= 2) {
				if (attacking) {
					timer -= 1;
					if (timer <= 0) {
						Attack_Group ();
					}
				}
				if(sprite_r == wait_sprite){
					bool check = Check_Group();
					if(check){
						
					}
					else{
						Swap_Animation(false);
					}
				}
			} 
			//Check the phase for springing traps
			else {
				//The waiting phase, do nothing
				if (phase == 1) {
				}
				//The windup phase, Check animation progress and decide when to attack and pause
				else if (phase == 2) {
					if (sprite_r.sprite == attack_sprite) {
						Attack_Group ();
					} else if (sprite_r.sprite == cooldown_sprite) {
						phase = 3;
						Next_Phase ();
					}
				}
				//The cooldown phase, move on to next phase once timer reaches 0
				else if (phase == 3) {
					timer -= 1;
					if (timer <= 0) {
						phase = 4;
						Next_Phase ();
					}
				}
				//The wind down phase, check animation progress and decide when to reset the loop
				else {
					if (sprite_r.sprite == wait_sprite) {
						phase = 1;
						Next_Phase ();
					}
				}
			}
		}
	}

	
	//Attack a number of creeps at the same time
	bool Check_Group(){
		int targ_size = 0;

		Doorway_Behaviour script = room_door.GetComponent<Doorway_Behaviour> ();

		//Determine the number of targets hit by the attack
		if (type == 1) {targ_size = 3;} 
		else if (type == 2) {targ_size = 2;} 
		else {targ_size = 99;}

		//Keep the target size capped at the number of creeps actually in the room
		if (targ_size > script.room_list.Count) {
			targ_size = script.room_list.Count;
		}

		//If we are actually attacking someone, reset the cooldown timer, not applicable for non lethal turrets
		if (lethal) {
			if (targ_size > 0) {
	
				return true;
			} else {
				return false;
			}
		} else {
			
		}

		return false;
	}
	
	

	//Attack a number of creeps at the same time
	void Attack_Group(){
		int targ_size = 0;

		Doorway_Behaviour script = room_door.GetComponent<Doorway_Behaviour> ();

		//Determine the number of targets hit by the attack
		if (type == 1) {targ_size = 3;} 
		else if (type == 2) {targ_size = 2;} 
		else {targ_size = 99;}

		//Keep the target size capped at the number of creeps actually in the room
		if (targ_size > script.room_list.Count) {
			targ_size = script.room_list.Count;
		}

		//If we are actually attacking someone, reset the cooldown timer, not applicable for non lethal turrets
		if (lethal) {
			if (targ_size > 0) {
				timer = cd_timer;
				Swap_Animation(true);
			} else {
				timer = 1;
			}
		} else {
			timer = cd_timer;
		}

		GameObject[] target_list = new GameObject[99];
		script.room_list.CopyTo (target_list);
		last_targ_size = targ_size;
		script.room_list.CopyTo (last_target_list);


		int n = 0;

		//If the type is 1 or 2, start to divide the damage among the hit targets, then hit them
		if (type <= 2) {
			int dam_1 = 0;
			int dam_2 = 0;
			int dam_3 = 0;
			n = 0;
			int dam_left = damage;
			while (dam_left > 0) {
				if (n == 0) {dam_1 += 1;} 
				else if (n == 1) {dam_2 += 1;}
				else {dam_3 += 1;}

				if (n == 0) {n += 1;} 
				else if (n == 1) {
					if (targ_size == 3) {n += 1;} 
					else {n = 0;}
				} 
				else {n = 0;}
				dam_left -= 1;
			}
			if (targ_size > 0) {Attack_Creep (target_list [0], dam_1);}
			if (targ_size > 1) {Attack_Creep (target_list [1], dam_2);}
			if (targ_size > 2) {Attack_Creep (target_list [2], dam_3);}
		}
		//Otherwise, hit every target with the damage value
		else {
			n = 0;
			while (n < script.room_list.Count) {
				GameObject new_targ = target_list [n];
				Attack_Creep (new_targ, damage);
				n += 1;
			}
		}
	}


		
	//Attack individual creeps
	void Attack_Creep(GameObject human, int amount){
		creep_behaviour hs = human.GetComponent<creep_behaviour>();
		hs.last_sprite = human.GetComponent<SpriteRenderer> ().sprite;
		//First deal damage to the creep
		
		int multi = 1;
		if(!lethal){
			if(type == 4){
				if(hs.age == 1){
					multi = 1;
				}
				else if(hs.age == 2){
					multi = 2;
				}
				else{
					multi = 4;
				}
			}
			else if(type == 5){
				if(hs.age == 1){
					multi = 2;
				}
				else if(hs.age == 2){
					multi = 4;
				}
				else{
					multi = 1;
				}
			}
			else{
				if(hs.age == 1){
					multi = 4;
				}
				else if(hs.age == 2){
					multi = 1;
				}
				else{
					multi = 2;
				}
			}
		}

		//Play sound if not triggered in this room
		if (!hs.def_increased) {
			hs.aud.Play ();
		}

		//Check for defense
		int defense = 0;
		if (type == 1) {
			defense = hs.book_def;
			//Increase book defense afterward
			if(!hs.def_increased){hs.book_def += 2;}
		}
		else if (type == 2) {
			defense = hs.knife_def;
			//Increase book defense afterward
			if(!hs.def_increased){hs.knife_def += 2;}
		}
		else if (type == 3) {
			defense = hs.chand_def;
			//Increase book defense afterward
			if(!hs.def_increased){hs.chand_def += 2;}
		}
		else if (type == 4) {
			defense = hs.ghost_def;
			//Increase book defense afterward
			if(!hs.def_increased){hs.ghost_def += 2;}
		}
		else if (type == 5) {
			defense = hs.zombie_def;
			//Increase book defense afterward
			if(!hs.def_increased){hs.zombie_def += 2;}
		}
		else if (type == 6) {
			defense = hs.skeleton_def;
			//Increase book defense afterward
			if(!hs.def_increased){hs.skeleton_def += 2;}
		}

		hs.def_increased = true;

		int total = 0;

		if (lethal) {
			total = amount - defense;
			if (total < 0) {
				total = 0;
			}
		} else {
			total = (amount*multi) - defense;
			if (total < 0) {
				total = 0;
			}
		}

		
		if (lethal) {human.GetComponent<creep_behaviour> ().HP -= total;} 
		else {human.GetComponent<creep_behaviour> ().SP -= total;}
		//Now, we need to check if it was the last one in the room for knives and books
		if (type <= 2) {
			if (human.GetComponent<creep_behaviour> ().HP <= 0 || human.GetComponent<creep_behaviour> ().SP <= 0) {
				//To do this, see if the size of the list is only 1
				if (room_door.GetComponent<Doorway_Behaviour> ().room_list.Count == 1) {
					//If all the above conditions are met, the turret is done attacking
					attacking = false;
				}
				//Regardless, remove the human from the door's list
				room_door.GetComponent<Doorway_Behaviour> ().Remove_From_List(human);
			}
		}
		//Check for death from the human now
		if (lethal) {
			hs.hurt_timer = 30;
			hs.Set_Sprite (1);
		} else {
			hs.hurt_timer = 30;
			hs.Set_Sprite (2);
		}
	}


	//"Destroy" the turret and refund the player's money
	public void Refund(){
		active = false;
		Vector3 gone = new Vector3 (transform.position.x, transform.position.y, 100);
		transform.position = gone;
		GameObject.Find ("spawner").GetComponent<spawner_behavior> ().gold += refund;
		refund = 5;
	}



	public void Triggered(){
		if (type > 2) {
			//If the trap is waiting, begin to spring it
			if (phase == 1) {
				phase = 2;
				Next_Phase ();
			}
			else if(phase == 2){
				string path = "";
				if(type == 3){
					if(upgraded){
						path = "chand2attack";
					}
					else{
						path = "chand1attack";
					}
					animate.Play(path);
				}
			}
		}	
		//If this is a constant DPS turret, start the attack
		else {
			attacking = true;
		}
	}

	//Set parameters of phase
	void Next_Phase(){
		//The waiting phase, set to idle sprite for chandelier, or set speed to 0 for monsters
		if (phase == 1) {
			if (type == 3) {
				animate.speed = 1f;
			} else {
				sprite_r.sprite = wait_sprite;
				animate.speed = 0f;
			}
		} 
		//The windup phase, simply start the animation up
		else if (phase == 2) {
			if (type == 3) {
				animate.speed = 1f;
				string path = "";
				if(upgraded){
					path = "chand2attack";
				}
				else{
					path = "chand1attack";
				}
				animate.Play(path);
			} else {
				animate.speed = 3.0f;
			}
		}
		//The Cooldown phase, pause the animation
		else if (phase == 3) {
			sprite_r.sprite = cooldown_sprite;
			animate.speed = 0f;
			entered = 67;
			if (type == 3) {
				timer = 90;
			} else {
				timer = 60;
			}
		}
		//The wind down phase, resume the animation
		else if (phase == 4) {
			if (type == 3) {
				animate.speed = 1f;
				phase = 1;
			} else {
				animate.speed = 3.0f;
			}
		}
	}
	
	
	public void Swap_Animation(bool a){
		int t = type;
		string path = "";
		string s1,s2,s3;
		s1 = "";
		s2 = "";
		s3 = "";
		if(t == 1){
			s1 = "book";
		}
		else if(t == 2){
			s1 = "knife";
		}
		else if(t == 3){
			s1 = "chand";
		}
		if(upgraded){
			s2 = "2";
		}
		else{
			s2 = "1";
		}
		if(a){
			s3 = "attack";
		}
		else{
			s3 = "idle";
		}
		path =s1+s2+s3;
		animate.Play (path);
		
	}
	
	

	//Set the turret to active, and set it's type
	public void Change_Type(int t){
		type = t;
		upgraded = false;
		string path = "";
		if (t <= 3) {lethal = true;} 
		else {lethal = false;}

		if (t == 1) {
			path = "book1idle";
			wait_sprite = slist.b_sprite;
			animate.speed = 1f;
			lethal = true;
			damage = 1;
			cd_timer = 20;
		}
		//Upgrade knife
		else if (t == 2) {
			path = "knife1idle";
			wait_sprite = slist.k_sprite;
			animate.speed = 1f;
			lethal = true;
			damage = 2;
			cd_timer = 40;
		}
		//Upgrade chandelier
		else if (t == 3) {
			path = "chand1idle";
			animate.speed = 1f;
			wait_sprite = slist.chand_1_wait;
			attack_sprite = slist.chand_1_attack;
			cooldown_sprite = slist.chand_1_cooldown;
			lethal = true;
			damage = 4;
			cd_timer = 90;
		}
		//Upgrade ghost
		else if (t == 4) {
			path = "ghost1attack";
			animate.speed = 0f;
			wait_sprite = slist.ghost_1_wait;
			attack_sprite = slist.ghost_1_attack;
			cooldown_sprite = slist.ghost_1_cooldown;
			lethal = false;
			damage = 1;
			cd_timer = 60;
		}
		//Upgrade zombie
		else if (t == 5) {
			path = "zombie1attack";
			animate.speed = 0f;
			wait_sprite = slist.zombie_1_wait;
			attack_sprite = slist.zombie_1_attack;
			cooldown_sprite = slist.zombie_1_cooldown;
			lethal = false;
			damage = 1;
			cd_timer = 60;
		}
		//Upgrade skeleton
		else if (t == 6) {
			path = "skeleton1attack";
			animate.speed = 0f;
			wait_sprite = slist.skeleton_1_wait;
			attack_sprite = slist.skeleton_1_attack;
			cooldown_sprite = slist.skeleton_1_cooldown;
			lethal = false;
			damage = 1;
			cd_timer = 60;
		}
		active = true;
		Vector3 here = new Vector3 (transform.position.x, transform.position.y, 1);
		transform.position = here;
		animate.Play (path);
	}


	public void Upgrade(){
		upgraded = true;
		int t = type;
		string path = "";
		//Upgrade book
		if (t == 1) {
			path = "book2idle";
			animate.speed = 1f;
			wait_sprite = slist.b_2_sprite;
		}
		//Upgrade knife
		else if (t == 2) {
			path = "knife2idle";
			animate.speed = 1f;
			wait_sprite = slist.k_2_sprite;
		}
		//Upgrade chandelier
		else if (t == 3) {
			path = "chand2idle";
			animate.speed = 1f;
			wait_sprite = slist.chand_2_wait;
			attack_sprite = slist.chand_2_attack;
			cooldown_sprite = slist.chand_2_cooldown;
		}
		//Upgrade ghost
		else if (t == 4) {
			path = "ghost2attack";
			animate.speed = 0f;
			wait_sprite = slist.ghost_2_wait;
			attack_sprite = slist.ghost_2_attack;
			cooldown_sprite = slist.ghost_2_cooldown;
		}
		//Upgrade zombie
		else if (t == 5) {
			path = "zombie2attack";
			animate.speed = 0f;
			wait_sprite = slist.zombie_2_wait;
			attack_sprite = slist.zombie_2_attack;
			cooldown_sprite = slist.zombie_2_cooldown;
		}
		//Upgrade skeleton
		else if (t == 6) {
			path = "skeleton2attack";
			animate.speed = 0f;
			wait_sprite = slist.skeleton_2_wait;
			attack_sprite = slist.skeleton_2_attack;
			cooldown_sprite = slist.skeleton_2_cooldown;
		}
		animate.Play (path);
		refund = 15;

		//Play sound
		AudioSource aud = GameObject.Find("Turret Data Loader").GetComponent<AudioSource>();
		if (type == 1) {
			aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().book_sound;
		}
		else if (type == 2) {
			aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().knife_sound;
		}
		else if (type == 3) {
			aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().chand_sound;
		}

		else if (type == 4) {
			aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().ghost_sound;
		}

		else if (type == 6) {
			aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().skeleton_sound;
		}

		else if (type == 5) {
			aud.clip = GameObject.Find ("Turret Data Loader").GetComponent<Turret_Animator> ().zombie_sound;
		}
		aud.Play ();

	}

}
