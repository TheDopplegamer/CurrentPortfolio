using UnityEngine;
using System.Collections;

public class TrafficBehaviour : MonoBehaviour {

	//The type of intersection
	//------------------------
	// 0 - T junction
	// 1 - X crossing
	// 2 - Corner
	public int type;

	//The status of the traffic lights, 1 being vertical, and 2 being horizontal
	//--------------------------------------------------------------------------
	// 0 - Red Light
	// 1 - Yellow Light
	// 2 - Green Light

	public int light_1;
	public int light_2;

	//References to the intersection's lights
	public GameObject right_light;
	public GameObject left_light;
	public GameObject up_light;
	public GameObject down_light;
	
	//The illegal rotation variable is used to prevent trucks from driving through a t-junction
	public float illegal_rotation;

	//The light for the timer
	int timer;
	int max_timer;

	// Use this for initialization
	void Start () {
		timer = 0;
		Set_Light ();
		max_timer = 240;
		gameObject.tag = "light";
		//Manually set references to lights
		if(gameObject.name == "TrafficLight1"){
			right_light = GameObject.Find("light2");
			left_light = GameObject.Find("light0");
			up_light = GameObject.Find("light1");
			down_light = GameObject.Find("light1");
		}
		else{
			right_light = GameObject.Find("light5");
			left_light = GameObject.Find("light4");
			up_light = GameObject.Find("light6");
			down_light = GameObject.Find("light3");
		}
		right_light.GetComponent<IntersectScript>().illegal_rotation = illegal_rotation;
		left_light.GetComponent<IntersectScript>().illegal_rotation = illegal_rotation;
		up_light.GetComponent<IntersectScript>().illegal_rotation = illegal_rotation;
		down_light.GetComponent<IntersectScript>().illegal_rotation = illegal_rotation;
	}

	
	//Open and close the traffic lights based on the light variables
	public void Set_Light(){
		if (light_1 == 0) {
			up_light.GetComponent<IntersectScript> ().open = false;
			down_light.GetComponent<IntersectScript> ().open = false;
			right_light.GetComponent<IntersectScript> ().open = true;
			left_light.GetComponent<IntersectScript> ().open = true;
		} else {
			up_light.GetComponent<IntersectScript> ().open = true;
			down_light.GetComponent<IntersectScript> ().open = true;
			right_light.GetComponent<IntersectScript> ().open = false;
			left_light.GetComponent<IntersectScript> ().open = false;
		}
		if (light_1 == 1) {
			up_light.GetComponent<IntersectScript> ().open = false;
			down_light.GetComponent<IntersectScript> ().open = false;
		}
		if (light_2 == 1) {
			right_light.GetComponent<IntersectScript> ().open = false;
			left_light.GetComponent<IntersectScript> ().open = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
			//All the traffic object has to do is regulate the traffic lights
			timer += 1;
			//Once the timer hits the 3/4 mark, switch to yellow lights
			if (timer == 210) {
				if (light_2 == 2) {
					light_2 = 1;
				} else {
					light_1 = 1;
				}
				Set_Light ();
			} else if (timer == max_timer) {
				if (light_1 == 0) {
					light_1 = 2;
					light_2 = 0;
				} else {
					light_1 = 0;
					light_2 = 2;
				}
				timer = 0;
				Set_Light ();
			}
			
	}
}
