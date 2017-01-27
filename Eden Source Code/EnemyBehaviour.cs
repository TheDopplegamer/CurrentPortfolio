using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	Animator animate;



	// Use this for initialization
	void Start () {
		animate = gameObject.GetComponent<Animator> ();
		animate.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (animate.enabled) {
			Animate_Pain ();
		} 
	}


	public void Start_Hit(){
		animate.enabled = true;
	}

	void Animate_Pain(){
		if (animate.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1.0f) {
			string hurt_animation = "scarecrow_hurt";
			animate.Play (hurt_animation, 0, 0);
			animate.enabled = false;
		}
	}
		

}
