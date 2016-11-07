using UnityEngine;
using System.Collections;

public class TowerPoison : MonoBehaviour {

	public Enemy enemy;
	float attackTimer = 0.0f;
	public GameObject[] towerTypes;
	public int mushIndex = 2;
	public ParticleSystem particle;
	public GameObject temp;


	// Use this for initialization
	void Start () {
	
		//enemy = GetComponent<Enemy> ();
		particle = gameObject.GetComponent<ParticleSystem> ();
		particle.Stop ();
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

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == ("Enemy") && attackTimer <= 0f){

			enemy = other.GetComponent<Enemy> ();
			Debug.Log ("hit collider");

			enemy.TakeDamage (20);
			attackTimer = 0f;
			particle.Play ();



		}
	}
}
