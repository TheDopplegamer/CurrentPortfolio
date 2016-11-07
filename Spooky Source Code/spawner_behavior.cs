using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawner_behavior : MonoBehaviour {

	//The spawner also acts as the game controller, holding all "global" variables
	public GameObject spawned_teen;
	int timer;
	int spawn_time;
	public int spawn_limit;
	public int total_spawn;
	public int score;
	public int level;
	public List<int> spawn_list;
	public GameObject current_button;
	public int turret_type;
	public int gold;

	public bool pause;

	//Set the framerate to 60 FPS
	void Awake(){
		Application.targetFrameRate = 60;
	}

	// Use this for initialization
	void Start () {
		pause = false;
		gold = 100;
		timer = 0;
		spawn_time = 120;
		spawn_limit = 8;
		total_spawn = 0;
		score = 0;
		level = 1;
		Create_Spawn_List ();
	}
	
	// Update is called once per frame
	void Update () {
		//Check to see if it is time to spawn another creep
		if (pause == false) {

			if (total_spawn < spawn_limit) {
				timer += 1;
				if (timer >= spawn_time) {
					timer = 0;
					Spawn_Creep ();
				}
			}
			//When the total number of creeps becomes 1, after all creeps have spawned, assign the is_last flag to the remaining creep
			if (total_spawn == spawn_limit) {
				GameObject[] l = GameObject.FindGameObjectsWithTag ("Enemy");
				int len = l.Length;
				if (len == 1) {
					l [0].GetComponent<creep_behaviour> ().is_last = true;
				}
				else{
					int k = 0;
					bool non_found = false;
					bool NO = false;
					GameObject founder;
					founder = l[0];
					while(k < len){
						GameObject checker = l[k];
						bool c = checker.GetComponent<creep_behaviour>().done;
						if(c == false){
							if(non_found == true){
								k = len;
								NO = true;
							}
							else{
								non_found = true;
								founder = checker;
							}
						}
						k += 1;
					}
					if(!NO){
						founder.GetComponent<creep_behaviour> ().is_last = true;
					}
				}
			}
		}
	}

	//Creates a random list of values that determines which types of creeps spawn
	void Create_Spawn_List(){
		spawn_list = new List<int>();
		int n = 0;
		while (n < spawn_limit) {
			int v = Random.Range(1,4);
			spawn_list.Add(v);
			n += 1;
		}
	}

	//Spawn a new creep
	public void Spawn_Creep (){
		total_spawn += 1;
		Instantiate (spawned_teen);
	}
}
