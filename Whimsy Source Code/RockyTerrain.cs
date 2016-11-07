using UnityEngine;
using System.Collections;

public class RockyTerrain : MonoBehaviour {

	Enemy enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision other) {

		other.gameObject.GetComponent<NavMeshAgent> ().speed = 2.5f;
	
	}
}
