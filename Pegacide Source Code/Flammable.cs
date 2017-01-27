using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour {

	
	public GameObject The_Mighty_Flame;
	public GameObject we_didnt_start_this_fire;
	public bool burn_baby_burn;
	public int life_on_fire;
	public int fire_limit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(burn_baby_burn){
			if(fire_limit > 0){
				life_on_fire += 1;
				if(life_on_fire >= fire_limit){
					if(gameObject.name == "pegasus"){
						gameObject.GetComponent<pegscript>().Die();
					}
					Destroy(we_didnt_start_this_fire);
					Destroy(gameObject);
				}
			}
		}
	}
	
	public void Birth_Mighty_Flame(){
		if(we_didnt_start_this_fire == null){
			we_didnt_start_this_fire = Instantiate(The_Mighty_Flame);
			we_didnt_start_this_fire.transform.position = transform.position;
			we_didnt_start_this_fire.transform.position = new Vector3(transform.position.x,transform.position.y,-1);
			we_didnt_start_this_fire.transform.parent = transform;
			burn_baby_burn = true;
		}
	}
	
}
