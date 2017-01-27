using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icescript : MonoBehaviour {

	public Sprite[] explode_spr = new Sprite[12]; 
	bool exploding;
	int timer;
	int ind;
	bool kill;
	int kill_timer;
	bool start;
	int start_timer;

	SpriteRenderer render;
	
	// Use this for initialization
	void Start () {
		render = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		
		if(start){
			start_timer += 1;
			if(start_timer == 2){
				Rigidbody rb = gameObject.GetComponent<Rigidbody>();
				rb.isKinematic = true;
				rb.detectCollisions = false;
				render.sprite = explode_spr[0];
				exploding = true;
			}
		}
		
		if(kill){
			kill_timer += 1;
			if(kill_timer >= 2){
				Destroy(gameObject);
			}
		}
		else if(exploding){
			Animate();
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject != gameObject && gameObject.GetComponent<Rigidbody>().useGravity){
		start = true;
		if(other.gameObject.tag == "toy"){
			Rigidbody body = other.gameObject.GetComponent<Rigidbody>();
			Vector3 dir = (other.gameObject.transform.position-transform.position).normalized;
			body.AddForce(6000*dir);
		}
		else if(other.gameObject.name == "pegasus"){
			other.gameObject.GetComponent<pegscript>().Die();
			Destroy(other.gameObject);
		}
		}
	}
	void Animate(){
		timer += 1;
		if(timer >= 1){
			timer = 0;
			ind += 1;
			if(ind >= 12){
				kill = true;
			}
			else{
				render.sprite = explode_spr[ind];
			}
		}
	}
}
