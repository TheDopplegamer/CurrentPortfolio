using UnityEngine;
using System.Collections;

public class TowerVenus : MonoBehaviour {

	public Collider enemyCol;
	public Enemy enemy;

	// Use this for initialization
	void Start () {
	
		enemy = GetComponent<Enemy> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == ("Enemy")){
			enemyCol = other;
			enemy.TakeDamage (15);

		}
	}
}
