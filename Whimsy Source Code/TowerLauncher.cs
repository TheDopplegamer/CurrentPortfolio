using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerLauncher : MonoBehaviour {

	//This turret type will spawn heat seeking projectiles when off cooldown
	public GameObject projectile;
	public int timer;
	public int cd; 
	public int bull_dam;

	// Use this for initialization
	void Start () {
		timer = 0;
		cd = 60;
		bull_dam = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other){
		timer -= 1;
		if (timer <= 0) {
			//Once the timer hits 0, launch a bullet
			timer = cd;
			GameObject new_bullet = Instantiate (projectile);
			//Set the bullets target and damage
			new_bullet.GetComponent<BulletScript> ().Set_Target (other.gameObject, bull_dam);
		}
	}
}
