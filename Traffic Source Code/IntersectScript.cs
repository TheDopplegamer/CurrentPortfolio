using UnityEngine;
using System.Collections;

public class IntersectScript : MonoBehaviour {

	public int passed;
	public bool open;

	public float illegal_rotation;
	
	// Use this for initialization
	void Start () {
		passed = 0;
		gameObject.tag = "intersection";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
