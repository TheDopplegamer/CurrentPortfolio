using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class explosionscript : MonoBehaviour {

	int timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1;
		if(timer >= 60){
			SceneManager.LoadScene (0);
		}
	}
	

}
