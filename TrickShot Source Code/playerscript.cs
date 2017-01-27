using UnityEngine;
using System.Collections;

public class playerscript : MonoBehaviour {

	float rot_amount = 1f;
	public int HP = 3;
	
	public Sprite red;
	public Sprite green;
	public Sprite blue;
	public Sprite purple;
	public GameObject explosion;

	void FixedUpdate(){
		if(Input.GetKey("w")){
			transform.Rotate(0,0,rot_amount);
		}
		if(Input.GetKey("s")){
			transform.Rotate(0,0,-rot_amount);
		}
	}
}
