using UnityEngine;
using System.Collections;

public class TruckBehaviour : MonoBehaviour {

	public float speed;
	public Vector3 dir;
	public Vector3 new_dir;

	public Vector3 angle;
	
	public GameObject test_truck;
	public bool is_test;
	public GameObject stopped_light;
	public GameObject origin;
	//The array of turns the truck needs to take
	public int[] turn_array;

	public int num_turns;

	public GameObject creator;
	
	//A reference to the truck ahead
	GameObject front_truck;
	public GameObject tlight;
	public int rotate_timer;

	//Whether or not the truck is the frontmost in a line
	bool is_front;

	//The mode variable states what the truck is currently doing
	//----------------------------------------------------------
	// 0 - Moving at normal speed
	// 1 - Speeding up
	// 2 - Slowing down
	// 3 - Waiting
	// 4 - Making left turn
	// 5 - Making right turn
	public int mode;
	
	public bool find_path_called;
	public bool test_path_called;
	public int recursions_done;
	public GameObject the_goal;
	public GameObject last_traffic;
	public bool Result;
	public float pub_f;
	// Use this for initialization
	void Start () {
		mode = 0;
		speed = 2f;
		rotate_timer = 0;
		angle = new Vector3 (0, 0, 0);
		gameObject.tag = "truck";
	}
	
	public void Find_Path(){
		find_path_called = true;
		GameObject[] goal_list = GameObject.FindGameObjectsWithTag("erase");
		int g = Random.Range(0,goal_list.Length);
		while(goal_list[g] == origin){
			g = Random.Range(0,goal_list.Length);
		}
		the_goal = goal_list[g];
		GameObject new_test = Instantiate(test_truck);
		new_test.transform.position = transform.position;
		new_test.transform.rotation = transform.rotation;
		new_test.GetComponent<TruckBehaviour>().creator = gameObject;
		new_test.GetComponent<TruckBehaviour>().Test_Path(goal_list[g]);
	}
	
	//Called by the test clone to find the proper turn array for the creator
	public void Test_Path(GameObject g){
		is_test = true;
		turn_array = new int[10];
		creator.GetComponent<TruckBehaviour>().test_path_called = true;
		bool goal_found = recursive_check(gameObject, transform.rotation.z, g, 0, 0);
		creator.GetComponent<TruckBehaviour>().turn_array = turn_array;
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(!is_test){
			//Decide what to do based on mode
			if (mode == 0) {Drive ();}
			else if (mode == 3) {Waiting ();} 
			else if (mode == 4) {Make_Left_Turn ();} 
			else if (mode == 5) {Make_Right_Turn ();}
		}
	}



	//Simply move the truck along
	void Drive(){

		bool brake = false;
		Vector3 startp = new Vector3(transform.position.x,transform.position.y,-2);
		angle = transform.right;
		Ray new_ray = new Ray (startp, angle);
		brake = Physics.Raycast (new_ray,0.8f);
		Debug.DrawRay (startp,angle);

		if (!brake) {transform.Translate (dir * speed * Time.deltaTime);}
	}
		

	//Wait until it is safe to advance
	void Waiting(){
		if (stopped_light.GetComponent<IntersectScript> ().open == true) {mode = 0;}
	}

	void OnTriggerEnter(Collider other){
	
		if(!is_test){

			if (other.tag == "intersection") {
				if (other.gameObject.GetComponent<IntersectScript> ().open) {other.gameObject.GetComponent<IntersectScript> ().passed += 1;}
				else {
					other.gameObject.GetComponent<IntersectScript> ().passed += 1;
					mode = 3;
					stopped_light = other.gameObject;
				}
			}

			if (other.tag == "light") {
				mode = turn_array [num_turns];
				num_turns += 1;
			} 
			else if (other.tag == "erase") {Destroy (gameObject);}
		
		}
	}
	

	//Make a left turn
	void Make_Left_Turn(){
		
		bool brake = false;
		Vector3 startp = new Vector3(transform.position.x,transform.position.y,-2);
		angle = transform.right;
		Ray new_ray = new Ray (startp, angle);
		brake = Physics.Raycast (new_ray,0.5f);
		Debug.DrawRay (startp,angle);
		
		if(!brake){
		
			rotate_timer += 1;
			transform.Rotate (0, 0, 2);
			transform.Translate (dir * (2.4f) * Time.deltaTime);
			if (rotate_timer >= 45) {
				rotate_timer = 0;
				mode = 0;
			}
		
		}
	}

	//Make a right turn
	void Make_Right_Turn(){
	
		bool brake = false;
		Vector3 startp = new Vector3(transform.position.x,transform.position.y,-2);
		angle = transform.right;
		Ray new_ray = new Ray (startp, angle);
		brake = Physics.Raycast (new_ray,0.5f);
		Debug.DrawRay (startp,angle);
		
		if(!brake){
	
			rotate_timer += 1;
			transform.Rotate (0, 0, -3);
			transform.Translate (dir * (0.8f) * Time.deltaTime);
			if (rotate_timer >= 30) {
				rotate_timer = 0;
				mode = 0;
			}
		
		}
	}
	
	
	//Checks to see if the truck can make a certain turn
	bool can_turn(GameObject obj,GameObject traffic,float f){
		last_traffic = traffic;
		//Determine what the new direction will be
		float new_direction = obj.transform.rotation.z + f;
		if(new_direction < 0f){
			new_direction = 90f;
		}
		else if(new_direction >= 360f){
			new_direction = 0f;
		}
		//To account for slight angular error, force the new direction into a whole number
			 if(new_direction < 1f)  {new_direction = 0f;}
		else if(new_direction < 91f) {new_direction = 90f;}
		else if(new_direction < 181f){new_direction = 180f;}
		else                         {new_direction = 270f;}
		pub_f = new_direction;
		//obj.GetComponent<TruckBehaviour>().creator.GetComponent<TruckBehaviour>().recursions_done += 100;
		//Once the direction has been solidified, make sure that it is a legal direction for the traffic
		if(new_direction == traffic.GetComponent<IntersectScript>().illegal_rotation){
			return(false);
		}
		else{
			return true;
		}
	}
	
	
	
	
	//Keeps the rotation of the truck between 0 and 360
	void Correct_Rotation(){
		float old_z = transform.rotation.z;
		float new_z = transform.rotation.z;
		if(old_z < 0f){
			new_z = 90f;
		}
		else if(old_z >= 360f){
			new_z = 0f;
		}
		transform.Rotate(0,0,new_z);
	}
	
	
	//This is the function that will recursively determine the turns neccessary to reach the goal
	bool recursive_check(GameObject obj, float rot, GameObject goal, int turn_level, int depth){
		//If the recursion has gone on too long, end the search
		obj.GetComponent<TruckBehaviour>().creator.GetComponent<TruckBehaviour>().recursions_done += 1;
		if(depth >= 1000){
			return false;
		}
		TruckBehaviour tb = obj.GetComponent<TruckBehaviour>();
		//Check the list of every collider we are currently colliding with
		Collider[] impact = Physics.OverlapBox(transform.position,new Vector3(0.9f,0.9f,5f));
		int n = 0;
		while(n < impact.Length){
			//We have reached a goal, check to see if it's the correct one
			if(impact[n].gameObject.tag == "erase" && impact[n].gameObject != obj.GetComponent<TruckBehaviour>().creator.GetComponent<TruckBehaviour>().origin){
				obj.GetComponent<TruckBehaviour>().creator.GetComponent<TruckBehaviour>().the_goal = impact[n].gameObject;
				return(impact[n].gameObject == goal);
			}
			//We have reached an intersection, recursively check the straight, right, and left turns
			else if(impact[n].gameObject.tag == "intersection"){
				//Record the original position and rotation
				Vector3 og_pos = obj.transform.position;
				Vector3 og_rot = obj.transform.rotation.eulerAngles;
				//Check if the straight path leads to the goal
				Result = can_turn(obj,impact[n].gameObject,0.0f);
				if(Result){
					obj.transform.Translate(new Vector3(3,0,0));
					tb.turn_array[turn_level] = 0;
					if(recursive_check(obj,rot,goal,turn_level+1,depth+1)){
						return true;
					}
				}
				obj.GetComponent<TruckBehaviour>().creator.GetComponent<TruckBehaviour>().recursions_done += 80;
				obj.transform.position = og_pos;
				obj.transform.rotation = Quaternion.Euler(og_rot);
				Result = can_turn(obj,impact[n].gameObject,90.0f);
				//Check if the right turn leads to the goal
				if(Result){
					obj.transform.Translate(new Vector3(2,0,0));
					obj.transform.Rotate(new Vector3(0,0,90));
					obj.transform.Translate(new Vector3(1,0,0));
					tb.turn_array[turn_level] = 4;
					if(recursive_check(obj,rot+90,goal,turn_level+1,depth+1)){
						return true;
					}
				}
				obj.transform.position = og_pos;
				obj.transform.rotation = Quaternion.Euler(og_rot);
				//Check if the left path leads to the goal
					obj.transform.Translate(new Vector3(2,0,0));
					obj.transform.Rotate(new Vector3(0,0,-90));
					obj.transform.Translate(new Vector3(1,0,0));
					tb.turn_array[turn_level] = 5;
					if(recursive_check(obj,rot-90,goal,turn_level+1,depth+1)){
						return true;
					}
			}
			n += 1;
		}
		//Since we are not hitting an intersection or eraser, simply advance the truck test and recursion loop
		obj.transform.Translate(new Vector3(1,0,0));
		return recursive_check(obj,rot,goal,turn_level,depth+1);
		
	}
	
	
	
}
