using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void ChangeScene(string name){
		SceneManager.LoadScene (name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
