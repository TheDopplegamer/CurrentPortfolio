using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Doorway_Behaviour : MonoBehaviour {


	public GameObject entrance;
	public List<GameObject> room_list;
	public int mode;
	public int times_removed;

	// Use this for initialization
	void Start () {
		//The modes
		//------------
		// 1 - the entrance, has no entrance for reference
		// 2 - middle room, has entrance and exit
		// 3 - final room, has no exit

		times_removed = 0;
		room_list = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//When a creep collides with the doorway, decide what to do first
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			if (mode != 3) {
				Add_To_List (other.gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			if (mode != 1) {
				entrance.GetComponent<Doorway_Behaviour> ().Remove_From_List (other.gameObject);
			}
		}
	}


	//Adds the new creep to the list
	public void Add_To_List(GameObject human){
		room_list.Add (human);
		human.GetComponent<creep_behaviour> ().cur_door = this.gameObject;
	}

	//Remove a creep from the list
	public void Remove_From_List(GameObject human){
		times_removed += 1;
		if (room_list.Contains (human)) {
			room_list.Remove (human);
		}
		//Lower resistances
		creep_behaviour hs = human.GetComponent<creep_behaviour>();
		hs.def_increased = false;
		hs.book_def -= 1;
		if (hs.book_def < 0) {hs.book_def = 0;}
		hs.knife_def -= 1;
		if (hs.knife_def < 0) {hs.knife_def = 0;}
		hs.chand_def -= 1;
		if (hs.chand_def < 0) {hs.chand_def = 0;}
		hs.ghost_def -= 1;
		if (hs.ghost_def < 0) {hs.ghost_def = 0;}
		hs.zombie_def -= 1;
		if (hs.zombie_def < 0) {hs.zombie_def = 0;}
		hs.skeleton_def -= 1;
		if (hs.skeleton_def < 0) {hs.skeleton_def = 0;}
	}
}
