using UnityEngine;
using System.Collections;

public class TowerMoss : MonoBehaviour {

	public Collider col;
	public Enemy enemy;
	float attackTimer = 0f;



	// Use this for initialization
	void Start () {
		
		enemy = GetComponent<Enemy> ();


	}
	
	// Update is called once per frame
	void Update () {

		if(attackTimer <= 0f){

			attackTimer = 1f;
		}

		if (attackTimer > 0f) {

			attackTimer -= Time.deltaTime;
		}

	
	}

	public void SlowEnemy(float slow, bool isSlowed){
		
		print (col.gameObject.GetComponent<NavMeshAgent> ().speed);

		col.gameObject.GetComponent<NavMeshAgent>().speed = slow;
		isSlowed = true;


	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == ("Enemy") && attackTimer <= 0f){
			
			col = other;
			SlowEnemy (1.0f, true); 
			attackTimer = 0f;


		}

	}

	void OnTriggerStay(Collider other){

		if (other.gameObject.tag == ("Enemy")) {

			col = other;
			SlowEnemy (+ 0.5f, true);
			attackTimer = 0f;


		}

	}

	void OnTriggerExit(Collider other){

		SlowEnemy(+3.5f, false);


	}
}