using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegscript : MonoBehaviour {

	public GameObject poof;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag != "safe"){
		//When the object is above the pegasus, see if it is crushed
		float angle = Vector3.Angle(transform.position,other.gameObject.transform.position);
		Debug.Log("Angle: "+angle.ToString());
		if(angle > 10f && angle < 90f){
			Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
			float mass = rb.mass;
			if(mass >= 4){
				
			GameObject.Find("target").GetComponent<targetscript>().Play_Sound(4);	
			GameObject.Find("target").GetComponent<targetscript>().Win();	
			GameObject p = Instantiate(poof);
			p.transform.position = transform.position;
			Destroy(gameObject);
			}
		}
		}
	}
	
	public void Die(){
		GameObject.Find("target").GetComponent<targetscript>().Play_Sound(4);	
			GameObject.Find("target").GetComponent<targetscript>().Win();	
			GameObject p = Instantiate(poof);
			p.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -10f){
			Die();
		}
	}
}
