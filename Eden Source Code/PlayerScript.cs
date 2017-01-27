using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {


	Animator animate;

	//Modify Jump height and speed, as well as the modifier for jump momentum
	public float jump_height;
	public float jump_speed;
	public float momentum_modifier;
	bool can_jump;
	float cur_jump_speed;

	//Modify falling and running speed
	public float fall_speed;
	public float run_speed;
	public float run_drift;

	//Modify speed, distance, and amount of drift after dodge
	public float dodge_speed;
	public float dodge_distance;
	public float dodge_drift;
	public int dodge_cooldown;
	int dodge_timer;

	Vector3 dodge_dir;
	float dodge_target;
	bool distance_reached;

	float ani_time;
	SpriteRenderer sprite;
	Vector3 dir;
	int previous_state;
	float drift;

	Quaternion right_vector = Quaternion.Euler(0f,0f,0f);
	Quaternion left_vector = Quaternion.Euler(0f,180f,0f);
	RaycastHit[] ray_list;
	GameObject child;
	Vector3 dodging;


	GameObject arrow_effect;

	//The stats for the three hitboxes for quickshot detection
	public Vector3 quick_box_1_pos;
	public Vector3 quick_box_2_pos;
	public Vector3 quick_box_3_pos;

	public Vector3 quick_box_1_len;
	public Vector3 quick_box_2_len;
	public Vector3 quick_box_3_len;

	GameObject target_found;
	public string cur_shot;

	//States
	//--------------
	// 0 - Standing Idle
	// 1 - Running
	// 2 - Jumping
	// 3 - Falling
	// 4 - Landing
	// 5 - Dodging
	// 6 - Stopping
	// 7 - Crouching
	// 8 - Quick Shooting
	public int state;

	void Awake(){
		Application.targetFrameRate = 30;
	}
		
	//Initialize variables
	void Start () {
		animate = gameObject.GetComponent<Animator> ();
		sprite = gameObject.GetComponent<SpriteRenderer> ();
		can_jump = true;
		dir = Vector3.right;
		if (state == 3) {
			Switch_Animation ("fall");
		}
		child = GameObject.Find ("Main Camera");
		arrow_effect = GameObject.Find ("arrow_effect");
	}

	void FixedUpdate () {
		//Cycle through every state 

		Idle ();
		Running ();
		Jump ();
		Fall ();
		Landing_Animation ();
		Dodge ();
		Stopping ();
		Crouching ();
		Quick_Shot ();
		Force_Z ();
		Check_Shot ();
	}

	private void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (transform.position + quick_box_1_pos, quick_box_1_len);

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (transform.position + quick_box_2_pos, quick_box_2_len);

		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (transform.position + quick_box_3_pos, quick_box_3_len);
	}



	//Standing Still, wait for input
	void Idle(){
		if (state == 0) {
			Check_Run ();
			Check_Jump ();
			Check_Dodge ();
			Check_Crouch ();

			bool checker = Look_Below ();
			if (!checker) {
				previous_state = 0;
				state = 3;
				can_jump = false;
				Switch_Animation ("fall");
			}

		}
	}

	//Moving, move along and wait for alternate input
	void Running(){
		if (state == 1) {
			bool checker = false;
			if (transform.rotation.y == 0f) {
				checker = Look_Right ();
			} else {
				checker = Look_Left ();
			}
			if (!checker) {
				transform.Translate (dir * run_speed * Time.deltaTime);
			}
			//Check to see if we need to stop
			if (!Input.GetKey ("a") && !Input.GetKey ("d")) {
				state = 6;
				previous_state = 1;
				drift = run_drift;
				dodge_dir = transform.rotation.eulerAngles;
				Switch_Animation ("stop");
			}
			//Check for cancels
			Check_Run ();
			Check_Dodge ();
			Check_Jump ();
			Check_Crouch ();

			checker = Look_Below ();
			if (!checker) {
				previous_state = 0;
				state = 3;
				can_jump = false;
				Switch_Animation ("fall");
			}
		}
	}

	//The Jumping State, take horizontal input and wait for the max height to be reached
	void Jump(){
		if (state == 2) {
			//Deccelerate until jump speed hits 0, then enter falling phase
			Vector3 jump_vector = new Vector3 (0f, cur_jump_speed, 0);

			bool checker = Look_Up ();
			if (!checker) {
				transform.Translate (jump_vector * run_speed * Time.deltaTime);
			} 
			if (cur_jump_speed <= 0) {
				state = 3;
				previous_state = 2;
				Switch_Animation ("fall");
			} else {
				cur_jump_speed -= 0.2f;
			}

			//Check for horizontal movement
			//If both keys are pressed, don't do anything
			if (Input.GetKey ("a") && Input.GetKey ("d")) {} else {
				//If only the a key is pressed, start moving left
				if (Input.GetKey ("a")) {
					//Only move left if there is nothing to the left
					checker = Look_Left();
					if (!checker) {
						if (transform.rotation == right_vector) {
							Flip_Sprite ();
						}
						transform.Translate (Vector3.right * (run_speed * momentum_modifier) * Time.deltaTime);
					}
				}
				//If only the d key is pressed, start moving right
				if (Input.GetKey ("d")) {
					//Only move right if there is nothing to the right
					checker = Look_Right();
					if (!checker) {
						if (transform.rotation == left_vector) {
							Flip_Sprite ();
						}
						transform.Translate (Vector3.right * (run_speed * momentum_modifier) * Time.deltaTime);
					}
				}
			}
			Check_Dodge ();
		}
	}

	//The falling state after a jump, take horizontal input and wait for the ground to be reached
	void Fall(){
		if (state == 3) {
			//Accelerate towards the ground
			cur_jump_speed += (fall_speed/20f);
			//Check for terminal velocity
			if (cur_jump_speed >= fall_speed) {
				cur_jump_speed = fall_speed;
			}

			bool checker = Look_Below ();
			if (!checker) {
				transform.Translate (Vector3.down * cur_jump_speed * Time.deltaTime);
			} else {
				previous_state = 3;
				state = 4;
				Switch_Animation ("land");
				can_jump = true;
			}

			//Check for horizontal movement
			//If both keys are pressed, don't do anything
			if (Input.GetKey ("a") && Input.GetKey ("d")) {} else {
				//If only the a key is pressed, start moving left
				if (Input.GetKey ("a")) {
					//Only move left if there is nothing to the left
					checker = Look_Left();
					if (!checker) {
						if (transform.rotation == right_vector) {
							Flip_Sprite ();
						}
						transform.Translate (Vector3.right * (run_speed * momentum_modifier) * Time.deltaTime);
					}
				}
				//If only the d key is pressed, start moving right
				if (Input.GetKey ("d")) {
					//Only move right if there is nothing to the right
					checker = Look_Right();
					if (!checker) {
						if (transform.rotation == left_vector) {
							Flip_Sprite ();
						}
						transform.Translate (Vector3.right * (run_speed * momentum_modifier) * Time.deltaTime);
					}
				}
			}
			Check_Dodge ();
		}
	}

	//The landing state, wait for animation to end or for cancel
	void Landing_Animation(){
		if (state == 4) {
			bool checker = false;
			//When animation ends, move to idle state
			if(animate.GetCurrentAnimatorStateInfo(0).IsName("archer_land") && animate.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
				state = 0;
				previous_state = 4;
				Switch_Animation ("idle");
			}
			//If we are landing after a dodge, allow for slight drift
			if (previous_state == 5) {
				if (dodging == Vector3.left) {
					checker = Look_Left ();
				} else {
					checker = Look_Right ();
				}
				if (!checker) {
					transform.Translate (Vector3.left * (drift) * Time.deltaTime);
				}
				drift -= 0.2f;
				if (drift <= 0) {
					drift = 0f;
				}
			}
			//Check for cancels
			Check_Run ();
			Check_Jump ();
			Check_Dodge ();
			Check_Crouch ();

			checker = Look_Below ();
			if (!checker) {
				previous_state = 0;
				state = 3;
				can_jump = false;
				Switch_Animation ("fall");
			}
		}
	}

	//The dodging state, control movement and wait for the dodge to end
	void Dodge(){
		if (state == 5) {
			//Move along in the dodge

			bool checker = false;
			if (dodge_dir.y == 180f) {
				dodging = Vector3.left;
				checker = Look_Left ();
			} else {
				dodging = Vector3.right;
				checker = Look_Right ();
			}
				
			if (!checker) {
				transform.Translate (Vector3.left * (dodge_speed) * Time.deltaTime); 
				//Check to see if the distance has been reached
				if (dodge_dir.y == 180f) {
					if (transform.position.x <= dodge_target) {
						distance_reached = true;
					} else {
						distance_reached = false;
					}
				} else {
					if (transform.position.x >= dodge_target) {
						distance_reached = true;
					} else {
						distance_reached = false;
					}
				}
			} else {
				distance_reached = true;
			}

			//Prevent dodge from exceeding distance	
			if (distance_reached && !checker) {
				transform.position = new Vector3 (dodge_target, transform.position.y, transform.position.z);
			}

			//Once we have reached frame 5, pause the animation until the distance has been reached
			if (!distance_reached && animate.GetCurrentAnimatorStateInfo (0).IsName ("archer_dodge") && animate.GetCurrentAnimatorStateInfo (0).normalizedTime >= ((1f / 8f) * 4f)) {
				animate.Play ("archer_dodge", 0, ((1f / 8f) * 5f));
			} 
			//Once the distance has been reached, the animation can be resumed
			if (distance_reached) {
				//Once the animation has finished, move on to the landing state
				if (animate.GetCurrentAnimatorStateInfo (0).IsName ("archer_dodge") && animate.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1.0f) {
					if (can_jump == false) {
						state = 3;
					} else {
						state = 4;
					}
					if (previous_state == 2 || previous_state == 3) {
						drift = 0f;
					} else {
						drift = dodge_drift;
					}
					previous_state = 5;
					if (state == 3) {
						Switch_Animation ("fall");
					}
					else{
						Switch_Animation ("land");
					}
				}
			}

		}
		if (dodge_timer > 0) {
			dodge_timer -= 1;
		}
	}

	//The stopping state, either wait for cancel ar animation to end
	void Stopping(){
		if (state == 6) {
			//Move to idle state once animation ends
			if (animate.GetCurrentAnimatorStateInfo (0).IsName ("archer_stop") && animate.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1.0f) {
				previous_state = state;
				state = 0;
				Switch_Animation ("idle");
			}

			bool checker = false;
			if (transform.rotation.y == 0f) {
				checker = Look_Right ();
			} else {
				checker = Look_Left ();
			}
			if (!checker) {
				transform.Translate (Vector3.right * (drift) * Time.deltaTime);
			}
			drift -= 0.2f;
			if (drift <= 0) {
				drift = 0f;
			}
			//Check for cancels
			Check_Run ();
			Check_Jump ();
			Check_Dodge ();
			Check_Crouch ();

			checker = Look_Below ();
			if (!checker) {
				previous_state = 0;
				state = 3;
				can_jump = false;
				Switch_Animation ("fall");
			}
		}
	}

	//The crouching state
	void Crouching(){
		if (state == 7) {
			//Check if the crouch is to be exited
			if (Input.GetKeyUp ("s")) {
				state = 4;
				previous_state = 7;
				animate.Play ("archer_land", 0, ((1f / 18f) * 9f));
			}
			//Check for dodge and jump cancels
			Check_Dodge ();
			//Check_Run ();
			Check_Jump ();
		}
	}

	//The quick shot state, wait for the animation to finish
	void Quick_Shot(){
		if (state == 8) {
			//Wait for animation to end
			if (animate.GetCurrentAnimatorStateInfo (0).IsName (cur_shot) && animate.GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.8f) {
				if (previous_state == 2 || previous_state == 3) {
					state = 3;
					previous_state = 8;
					Switch_Animation ("fall");
				} else {
					state = 4;
					previous_state = 8;
					Switch_Animation ("land");
				}
			}
		}
	}
		
	//Check for Jump input
	void Check_Jump(){
		if(can_jump && Input.GetKeyDown ("w")){
			
			//Start Jump state
			can_jump = false;
			previous_state = state;
			state = 2;
			cur_jump_speed = jump_height;
			Switch_Animation ("jump");
		}
	}

	//Check for run input
	void Check_Run(){
		//If both keys are pressed, don't do anything
		if (Input.GetKey ("a") && Input.GetKey ("d")) {
			previous_state = state;
			state = 0;
			Switch_Animation ("idle");
		} else {
			//If only the a key is pressed, start moving left
			if (Input.GetKey ("a")) {
				if (transform.rotation == right_vector) {
					Flip_Sprite ();
				}
				previous_state = state;
				state = 1;
				Switch_Animation ("run");
			}
			//If only the d key is pressed, start moving right
			if (Input.GetKey ("d")) {
				if (transform.rotation == left_vector) {
					Flip_Sprite ();
				}
				previous_state = state;
				state = 1;
				Switch_Animation ("run");
			}
		}
	}

	//Check for dodge input
	void Check_Dodge(){
		if (dodge_timer == 0) {
			if (Input.GetKey ("j")) {
				Switch_Animation ("dodge");
				//When running, flip the sprite first
				if (state == 1) {
					dodge_dir = transform.rotation.eulerAngles;
					Flip_Sprite ();
				} 
				//When in the air
				else if (state == 2 || state == 3) {
					//Moving to the left
					if (Input.GetKey ("a") && !Input.GetKey ("d")) {
						dodge_dir = transform.rotation.eulerAngles;
						Flip_Sprite ();
					}
					//Moving to the right
					else if (!Input.GetKey ("a") && Input.GetKey ("d")) {
						dodge_dir = transform.rotation.eulerAngles;
						Flip_Sprite ();
					}
					//Not pressing anything
					else {
						if (transform.rotation == right_vector) {
							dodge_dir = left_vector.eulerAngles;
						} else {
							dodge_dir = right_vector.eulerAngles;
						}
					}

				} else {
					if (transform.rotation == right_vector) {
						dodge_dir = left_vector.eulerAngles;
					} else {
						dodge_dir = right_vector.eulerAngles;
					}
				}

				int nega;
				if (dodge_dir.y == 180f) {
					nega = -1;
				} else {
					nega = 1;
				}

				//Determine the end position of the dodge
				dodge_target = transform.position.x + (dodge_distance * (nega));
				previous_state = state;
				state = 5;
				dodge_timer = dodge_cooldown;
			}
		}
	}

	//Check for crouch input
	void Check_Crouch(){
		if (Input.GetKeyDown ("s")) {
			previous_state = state;
			state = 7;
			Switch_Animation ("crouch");
		}
	}

	void Check_Shot(){
		if (Input.GetKeyDown (KeyCode.Return)) {
			target_found = Determine_Target ();
			if (target_found != null) {
				target_found.GetComponent<EnemyBehaviour> ().Start_Hit ();
				string shot_animation = find_shot_angle ();
				shot_animation = "quick_" + shot_animation;
				//If we are in the air, make it a jump shot
				if (state == 2 || state == 3) {
					cur_shot = "archer_jump_" + shot_animation;
					Switch_Animation ("jump_"+shot_animation);
				} else {
					cur_shot = "archer_" + shot_animation;
					Switch_Animation (shot_animation);
				}
				previous_state = state;
				state = 8;
				arrow_effect.GetComponent<SpriteRenderer> ().enabled = true;
				arrow_effect.GetComponent<Animator> ().enabled = true;
			}
		}
	}
		
	//Switch to the correct animation
	public void Switch_Animation(string ani){
		string path = "archer_" + ani;
		animate.Play (path);
	}
		
	// Flip the sprite when turning around
	void Flip_Sprite(){
		child.transform.parent = null;
		if (transform.rotation == right_vector) {transform.rotation = left_vector;} 
		else                      {transform.rotation = right_vector;}
		child.transform.parent = gameObject.transform;
	}

	void Force_Z(){
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
	}


	bool Look_Below(){
		//Check the three rays
		bool found_1 = false;
		bool found_2 = false;
		bool found_3 = false;

		//left ray
		Vector3 coll_vect = new Vector3 (transform.position.x-0.5f,transform.position.y+2f,transform.position.z);
		Ray created_ray = new Ray (coll_vect, Vector3.down);
		Debug.DrawRay (coll_vect, Vector3.down * 1f);
		ray_list = Physics.RaycastAll (created_ray,1f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_1 = true;
				//Set the y value
				//transform.position = new Vector3(transform.position.x,ray_list [r].collider.gameObject.transform.position.y-1.2f,transform.position.z);
				r = ray_list.Length;
			}
		}
		//Center ray
		coll_vect = new Vector3 (transform.position.x,transform.position.y+2f,transform.position.z);
		created_ray = new Ray (coll_vect, Vector3.down);
		Debug.DrawRay (coll_vect, Vector3.down * 1f);
		ray_list = Physics.RaycastAll (created_ray,1f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_2 = true;
				//Set the y value
				transform.position = new Vector3(transform.position.x,ray_list [r].collider.gameObject.transform.position.y-1.4f,transform.position.z);
				r = ray_list.Length;
			}
		}
		//Right ray
		coll_vect = new Vector3 (transform.position.x+0.5f,transform.position.y+2f,transform.position.z);
		created_ray = new Ray (coll_vect, Vector3.down);
		Debug.DrawRay (coll_vect, Vector3.down * 1f);
		ray_list = Physics.RaycastAll (created_ray,1f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_3 = true;
				//Set the y value
				//transform.position = new Vector3(transform.position.x,ray_list [r].collider.gameObject.transform.position.y-1.2f,transform.position.z);
				r = ray_list.Length;
			}
		}

		return (found_1 || found_2 || found_3);
	}

	bool Look_Up(){
		bool found_1 = false;
		bool found_2 = false;
		bool found_3 = false;

		//left ray
		Vector3 coll_vect = new Vector3 (transform.position.x-0.5f,transform.position.y+2f,transform.position.z);
		Ray created_ray = new Ray (coll_vect, Vector3.up);
		Debug.DrawRay (coll_vect, Vector3.up * 1.3f);
		ray_list = Physics.RaycastAll (created_ray,1.3f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_1 = true;
				r = ray_list.Length;
			}
		}
		//Center ray
		coll_vect = new Vector3 (transform.position.x,transform.position.y+2f,transform.position.z);
		created_ray = new Ray (coll_vect, Vector3.up);
		Debug.DrawRay (coll_vect, Vector3.up * 1.3f);
		ray_list = Physics.RaycastAll (created_ray,1.3f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_2 = true;
				r = ray_list.Length;
			}
		}
		//Right ray
		coll_vect = new Vector3 (transform.position.x+0.5f,transform.position.y+2f,transform.position.z);
		created_ray = new Ray (coll_vect, Vector3.up);
		Debug.DrawRay (coll_vect, Vector3.up * 1.3f);
		ray_list = Physics.RaycastAll (created_ray,1.3f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_3 = true;
				r = ray_list.Length;
			}
		}

		return (found_1 || found_2 || found_3);
	}

	bool Look_Right(){
		bool found_1 = false;
		bool found_2 = false;
		bool found_3 = false;

		//bottom ray
		Vector3 coll_vect = new Vector3 (transform.position.x,transform.position.y+1f,transform.position.z);
		Ray created_ray = new Ray (coll_vect, Vector3.right);
		Debug.DrawRay (coll_vect, Vector3.right * 1f);
		ray_list = Physics.RaycastAll (created_ray,1f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_1 = true;
				r = ray_list.Length;
			}
		}
		//Center ray
		coll_vect = new Vector3 (transform.position.x,transform.position.y+2f,transform.position.z);
		created_ray = new Ray (coll_vect, Vector3.right);
		Debug.DrawRay (coll_vect, Vector3.right * 1f);
		ray_list = Physics.RaycastAll (created_ray,1f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_2 = true;
				r = ray_list.Length;
			}
		}
		//top ray
		coll_vect = new Vector3 (transform.position.x,transform.position.y+3f,transform.position.z);
		created_ray = new Ray (coll_vect, Vector3.right);
		Debug.DrawRay (coll_vect, Vector3.right * 1f);
		ray_list = Physics.RaycastAll (created_ray,1f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_3 = true;
				r = ray_list.Length;
			}
		}


		return (found_1 || found_2 || found_3);
	}

	bool Look_Left(){
		bool found_1 = false;
		bool found_2 = false;
		bool found_3 = false;

		//bottom ray
		Vector3 coll_vect = new Vector3 (transform.position.x+0f,transform.position.y+1f,transform.position.z);
		Ray created_ray = new Ray (coll_vect, Vector3.left);
		Debug.DrawRay (coll_vect, Vector3.left * 1f);
		ray_list = Physics.RaycastAll (created_ray,1f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_1 = true;
				r = ray_list.Length;
			}
		}
		//Center ray
		coll_vect = new Vector3 (transform.position.x+0f,transform.position.y+2f,transform.position.z);
		created_ray = new Ray (coll_vect, Vector3.left);
		Debug.DrawRay (coll_vect, Vector3.left * 1f);
		ray_list = Physics.RaycastAll (created_ray,1f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_2 = true;
				r = ray_list.Length;
			}
		}
		//top ray
		coll_vect = new Vector3 (transform.position.x+0f,transform.position.y+3f,transform.position.z);
		created_ray = new Ray (coll_vect, Vector3.left);
		Debug.DrawRay (coll_vect, Vector3.left * 1f);
		ray_list = Physics.RaycastAll (created_ray,1f);
		for(int r = 0;r < ray_list.Length;r += 1){
			if (ray_list [r].collider.gameObject.tag == "terrain") {
				found_3 = true;
				r = ray_list.Length;
			}
		}

		return (found_1 || found_2 || found_3);
	}


	//Calculates a target for the quick shot
	GameObject Determine_Target(){
		List<GameObject> targ_list = new List<GameObject>();
		//First, just check inside the first box
		Collider[] coll_list;

		if (transform.rotation.y == 0f) {
			coll_list = Physics.OverlapBox (transform.position + quick_box_1_pos, quick_box_1_len / 2f);
		} else {
			coll_list = Physics.OverlapBox (transform.position + quick_box_2_pos, quick_box_2_len / 2f);
		}
		//Go through the list until an enemy is found
		bool found = false;
		for (int e = 0; e < coll_list.Length; e += 1) {
			GameObject cur_obj = coll_list [e].gameObject;
			//If the current object in the list is an enemy, add it to the list
			if (cur_obj.GetComponent<EnemyBehaviour> () != null) {
				found = true;
				targ_list.Add (cur_obj);
			}
		}
		//If we've found at least 1 target, return the shortest distance target in the list
		if (found) {return Pick_Target (targ_list);} 

		//If not, check the second box
		if (transform.rotation.y == 0f) {
			coll_list = Physics.OverlapBox (transform.position + quick_box_2_pos, quick_box_2_len / 2f);
		} else {
			coll_list = Physics.OverlapBox (transform.position + quick_box_1_pos, quick_box_1_len / 2f);
		}
		//Go through the list until an enemy is found
		found = false;
		for (int e = 0; e < coll_list.Length; e += 1) {
			GameObject cur_obj = coll_list [e].gameObject;
			//If the current object in the list is an enemy, add it to the list
			if (cur_obj.GetComponent<EnemyBehaviour> () != null) {
				found = true;
				targ_list.Add (cur_obj);
			}
		}
		//If we've found at least 1 target, return the shortest distance target in the list
		if (found) {return Pick_Target (targ_list);} 

		//If not, check the third box
		coll_list = Physics.OverlapBox(transform.position+quick_box_3_pos,quick_box_3_len/2f);
		//Go through the list until an enemy is found
		found = false;
		for (int e = 0; e < coll_list.Length; e += 1) {
			GameObject cur_obj = coll_list [e].gameObject;
			//If the current object in the list is an enemy, add it to the list
			if (cur_obj.GetComponent<EnemyBehaviour> () != null) {
				found = true;
				targ_list.Add (cur_obj);
			}
		}
		//If we've found at least 1 target, return the shortest distance target in the list
		if (found) {
			return Pick_Target (targ_list);
		} 

		//If we haven't found anything, return null
		else {
			return null;
		}
	}

	//Picks the closest target in a list
	GameObject Pick_Target(List<GameObject> lst){
		//Keep the shortest distance and object for reference
		float shortest_len = 1000f;
		GameObject shortest_target = null;

		Vector3 base_pos = new Vector3 (transform.position.x, transform.position.y + 2f, transform.position.z);

		for (int i = 0; i < lst.Count; i += 1) {
			//Get the distance from the base to the current object
			GameObject cur_obj = lst [i];
			float cur_len = Vector3.Distance (base_pos, cur_obj.transform.position);
			//See if this is the new shortest distance
			if (cur_len < shortest_len) {
				shortest_len = cur_len;
				shortest_target = cur_obj;
			}
		}

		//Return the shortest target
		return shortest_target;
	}


	//Calculate the angle between the target and player, and return the correct animation
	string find_shot_angle(){
		//Find the angle between the two positions
		Vector3 base_pos = new Vector3 (transform.position.x, transform.position.y + 2f, transform.position.z);
		Vector3 sum = target_found.transform.position - base_pos;
		float angle = Mathf.Atan2 (sum.y, sum.x) * Mathf.Rad2Deg;
		if (angle < 0f) {
			angle = 360f + angle;
		}

		//Make sure the sprite rotation matches the angle
		if (transform.rotation.y == 0f) {
			if (angle > 90f && angle < 270f) {
				Flip_Sprite ();
			}
		} else {
			if (angle <= 90f || angle >= 270f) {
				Flip_Sprite ();
			}
		}


		//Determine the general angle, down, front, up, sky
		string rs = "";

		if (transform.rotation.y == 0f) {
			if (angle >= 270f && angle < 315f) {
				rs = "down";
				arrow_effect.GetComponent<arrow_effect_script> ().Set_Z (-45f);
			} else if (angle <= 30f || angle >= 315f) {
				rs = "front";
				arrow_effect.GetComponent<arrow_effect_script> ().Set_Z (0f);
			} else if (angle <= 70f) {
				rs = "up";
				arrow_effect.GetComponent<arrow_effect_script> ().Set_Z (45f);
			} else {
				rs = "sky";
				arrow_effect.GetComponent<arrow_effect_script> ().Set_Z (80f);
			}
		} else {
			if (angle <= 270f && angle > 225f) {
				rs = "down";
				arrow_effect.GetComponent<arrow_effect_script> ().Set_Z (-45f);
			} else if (angle >= 150f) {
				rs = "front";
				arrow_effect.GetComponent<arrow_effect_script> ().Set_Z (0f);
			} else if (angle >= 110f) {
				rs = "up";
				arrow_effect.GetComponent<arrow_effect_script> ().Set_Z (45f);
			} else {
				rs = "sky";
				arrow_effect.GetComponent<arrow_effect_script> ().Set_Z (80f);
			}
		}

		Debug.Log ("Angle: " + angle.ToString () + " : " + rs);
		return rs;

	}

}
