using UnityEngine;
using System.Collections;

public class spoopy_mover : MonoBehaviour {

	public float speed;
	public Vector3 dir;
	public float accel;

	// Use this for initialization
	void Start () {
		speed = 0.01f;
		accel = 1.0f;
		dir = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (dir * speed * Time.deltaTime);
		//Update Speed 
		speed += 0.01f * accel;

		if (accel > 0) {
			if (speed >= 0.5f) {
				accel = -1.0f;
			}
		} else {
			if (speed <= 0f) {
				accel = 1.0f;
			}
		}

		//When speed hit's 0, change dir
		if (speed <= 0f) {
			speed = 0.01f;
			if (dir == Vector3.up) {
				dir = Vector3.down;
			} else {
				dir = Vector3.up;
			}
		}

	}
}
