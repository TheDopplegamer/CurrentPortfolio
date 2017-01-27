using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mans : MonoBehaviour {

	public int level;
	

	void Awake(){
		level = 1;
		Application.targetFrameRate = 60;
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		if(GameObject.Find("Man") != gameObject){
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("r")){
			Reset();
		}
		if(Input.GetMouseButtonDown(0)){
			if(SceneManager.GetActiveScene().buildIndex == 0){
				SceneManager.LoadScene (1);
			}
		}
		if(Input.GetKeyDown("c")){
			if(SceneManager.GetActiveScene().buildIndex == 0){
				SceneManager.LoadScene (8);
			}
		}
		if(Input.GetKeyDown("s")){
			if(SceneManager.GetActiveScene().buildIndex == 0){
				SceneManager.LoadScene (9);
			}
		}
		if(Input.GetKeyDown("a")){
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}
	
	public void Reset(){
		level = 1;
		SceneManager.LoadScene(0);
	}
	
	public void Next_Level(){
		if(level == 7){
			SceneManager.LoadScene (0);
		}
		else{
			SceneManager.LoadScene (level+1);
			level += 1;
		}
	}
}
