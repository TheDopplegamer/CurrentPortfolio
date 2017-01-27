using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_script : MonoBehaviour {

	public GameObject fire;
	
	
	void Start(){
		if(gameObject.name == "pendball"){
			gameObject.GetComponent<Rigidbody>().AddForce(5000*Vector3.right);
		}
	}
	
	
	void FixedUpdate(){
		
	}
}
