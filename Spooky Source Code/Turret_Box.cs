using UnityEngine;
using System.Collections;

public class Turret_Box : MonoBehaviour {

	public GameObject turr;

	Turret_Behavior st;

	// Use this for initialization
	void Start () {
		st = turr.GetComponent<Turret_Behavior> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		st.Triggered ();
	}

	void OnTriggerEnter2D(Collider2D other){
		st.Triggered ();
	}

}
