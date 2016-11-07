using UnityEngine;
using System.Collections;

public class Destroy_Behaviour : MonoBehaviour {

	public int entered;

	// Use this for initialization
	void Start () {
		entered = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		entered += 1;
		Destroy (other.gameObject);
	}
}
