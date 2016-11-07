using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayButton_Script : MonoBehaviour {

	public Sprite play_sprite;
	public Sprite pause_sprite;

	public int state;


	// Use this for initialization
	void Start () {
		state = 1;
	}


	public void Pressed(){
		if (state == 1) {
			Pause_Game ();
			state = 2;
		} else {
			Resume_Game ();
			state = 1;
		}
	}

	void Pause_Game(){
		GameObject[] enemy_list = GameObject.FindGameObjectsWithTag ("Enemy");
		int n = 0;
		int len = enemy_list.Length;
		while (n < len) {
			GameObject enemy = enemy_list [n];
			enemy.GetComponent<creep_behaviour> ().pause = true; 
			n += 1;
		}
		GameObject.Find ("spawner").GetComponent<spawner_behavior> ().pause = true;

		GetComponent<Button> ().image.sprite = play_sprite;
		
		
	
		
	}

	void Resume_Game(){
		GameObject[] enemy_list = GameObject.FindGameObjectsWithTag ("Enemy");
		int n = 0;
		int len = enemy_list.Length;
		while (n < len) {
			GameObject enemy = enemy_list [n];
			enemy.GetComponent<creep_behaviour> ().pause = false; 
			n += 1;
		}
		GameObject.Find ("spawner").GetComponent<spawner_behavior> ().pause = false;

		GetComponent<Button> ().image.sprite = pause_sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
