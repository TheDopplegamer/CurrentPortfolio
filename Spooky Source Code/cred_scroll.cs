using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cred_scroll : MonoBehaviour {

	public float speed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * speed * Time.deltaTime);
		if (transform.position.y >= 35f) {
			SceneManager.LoadScene (0);
		}
	}
}
