using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed;
	public int timer;
	public GameObject target;
	public int dam;

	// Use this for initialization
	void Start () {
		speed = 0f;
		timer = 0;
		dam = 5;
	}

	//Constructor
	public void Set_Target(GameObject t, int d){
		target = t;
		dam = d;
	}

	//Destroyer Function
	public void Kill_Bullet(){
		Destroy (gameObject, 0f);
	}

	
	// Update is called once per frame
	void Update () {
		//Constantly move the projectile towards the target
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed);
	}

	//When the projectile hits the target
	void OnTriggerEnter(Collider other){
		//Make sure the target is the original target
		if (other.gameObject == target) {
			//If it is, damage the target and destroy this bullet
			target.GetComponent<Enemy>().TakeDamage(dam);
			Kill_Bullet ();
		}
	}
}
