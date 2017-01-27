using UnityEngine;
using System.Collections;

public class Spawn_Script : MonoBehaviour {

	public GameObject new_truck;
	public GameObject origin;
	public int timer;
	public Vector3 dir;
	public int num;

	void Start(){
		timer = Random.Range (200, 400);
		Application.targetFrameRate = 30;
	}

	void Update(){
		timer -= 1;
		if (timer <= 0) {
			timer = Random.Range (200, 400);
			GameObject t = Instantiate (new_truck);
			TruckBehaviour ts = t.GetComponent<TruckBehaviour> ();
			t.transform.position = transform.position;
			t.transform.rotation = transform.rotation;
			ts.dir = dir;
			ts.dir = new Vector3 (1, 0, 0);
			if (num == 1) {
			} else if (num == 2) {
				ts.transform.Rotate (0, 0, 180);
			} else if (num == 4) {
			} else if (num == 3) {
				ts.transform.Rotate (0, 0, 180);
			} else {
				ts.transform.Rotate (0, 0, 270);
			}
			ts.origin = origin;
			ts.Find_Path();

		}
	}
}
