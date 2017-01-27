using UnityEngine;
using System.Collections;

public class arrow_effect_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime >= 1.0f) {
			gameObject.GetComponent<Animator> ().Play ("arrow_effect", 0, 0f);
			gameObject.GetComponent<Animator> ().enabled = false;
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}

		transform.rotation = Quaternion.Euler(new Vector3 (transform.rotation.x, 0f, transform.rotation.z));
	}


	public void Set_Z(float z){
		Vector3 new_rot = new Vector3 (0f, 0f, z);
		transform.rotation = Quaternion.Euler (new_rot);
	}


}
