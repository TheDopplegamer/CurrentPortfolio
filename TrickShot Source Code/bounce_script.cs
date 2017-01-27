using UnityEngine;
using System.Collections;

public class bounce_script : MonoBehaviour {

	int timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1;
		if(timer >= 15){
			Destroy(gameObject);
		}
	}
}
