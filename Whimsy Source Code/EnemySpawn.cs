using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject temp;
	public Transform enemySpawn;
	public GameObject enemyPrefab;
	float spawnTime = 3f;
	public GameObject destination;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", spawnTime, spawnTime);

	
	}
	
	// Update is called once per frame
	void Update () {



	
	}

	void Spawn(){
		
		temp = Instantiate (enemyPrefab, enemySpawn.position, Quaternion.Euler(90, 0, 0)) as GameObject;//we are using this code to assign the variable of the nav mesh agent destination once the Gameobject actually spawns 
		//because you can't assign it to the prefab because once you place the object in the prefabs folder it loses all the variables you attached it to since those don't exist to that object yet...fuck
		temp.GetComponent<Enemy> ().destination = destination;//fuck this script... disgusting

	}

	void Waves(){

		//how many enemies will come out in a wave and how much time will pass in between waves

	}
}
		
