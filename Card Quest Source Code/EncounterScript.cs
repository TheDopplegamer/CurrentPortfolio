using UnityEngine;
using System.Collections;

public class EncounterScript : MonoBehaviour {

	//Name and Identifying index of encounter
	public string nme;
	public int index;

	//Type of encounter
	//-----------------
	// 1 - Hostile Enemy
	// 2 - Non-Hostile NPC
	// 3 - Event
	public int type;

	//Element of encounter
	//--------------------
	// 0 - Null
	// 1 - Fire
	// 2 - Water
	// 3 - Earth
	// 4 - Wind
	public int element;

	//Combat stats of encounter
	public int HP;
	public int damage;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
