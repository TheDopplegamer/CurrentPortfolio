using UnityEngine;
using System.Collections;

public class Sound_Controller : MonoBehaviour {

	public AudioClip spoopy_sound;
	public AudioClip menu_click;
	public AudioClip scream_sfx;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Start_Sound(){
		//Get a random number then play the sound
		int rand = Random.Range(1,100);

		if (rand <= 50) {
			gameObject.GetComponent<AudioSource> ().clip = menu_click;
		} else if (rand <= 90) {
			gameObject.GetComponent<AudioSource> ().clip = spoopy_sound;
		} else {
			gameObject.GetComponent<AudioSource> ().clip = scream_sfx;
		}
		gameObject.GetComponent<AudioSource> ().Play ();

	}

}
