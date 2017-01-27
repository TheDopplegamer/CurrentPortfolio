using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class platform_script : MonoBehaviour {

	public float spd;
	public int timer;
	public int dir;
	public float max_y;
	public float min_y;

	List<GameObject> passenger;

	// Use this for initialization
	void Start () {
		dir = 0;
		timer = 60;
		passenger = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		//Waiting for timer to hit 0
		if (dir == 0) {
			timer -= 1;
			if (timer <= 0) {
				timer = 60;
				if (transform.position.y == max_y) {
					dir = -1;
				} else {
					dir = 1;
				}
			}
		}
		//Moving
		else {
			//Moving up
			if (dir == 1) {
				transform.Translate (Vector3.up * spd * Time.deltaTime);
				if (passenger != null) {
					foreach (GameObject p in passenger) {
						p.transform.Translate (Vector3.up * spd * Time.deltaTime);
					}
				}
				if (transform.position.y >= max_y) {
					transform.position =  (new Vector3 (transform.position.x, max_y, transform.position.z));
					dir = 0;
					timer = 60;
				}
			}
			//Moving down
			else {
				if (passenger != null) {
					foreach (GameObject p in passenger) {
						p.transform.Translate (Vector3.down * spd * Time.deltaTime);
					}
				}
				transform.Translate (Vector3.down * spd * Time.deltaTime);
				if (transform.position.y <= min_y) {
					transform.position =  (new Vector3 (transform.position.x, min_y, transform.position.z));
					dir = 0;
					timer = 60;
				}
			}

		}
	}

	void OnTriggerEnter(Collider other){
		passenger.Add (other.gameObject);
	}

	void OnTriggerExit(Collider other){
		passenger.Remove (other.gameObject);
	}
}
