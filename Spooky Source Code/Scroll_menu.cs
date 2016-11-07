using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scroll_menu : MonoBehaviour {

	public bool moving;
	public bool watcher;
	public float speed;
	public bool done;
	public int wait_timer;

	// Use this for initialization
	void Start () {
		wait_timer = 0;
		moving = false;
		speed = 10f;
		done = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			if (watcher) {
				if (transform.position.x >= -10.65f) {
					moving = false;
					done = true;
					Vector3 new_pos = new Vector3 (-10.65f, transform.position.y, transform.position.z);
					transform.position = new_pos;
				}
			}
		}
		if (done) {
			wait_timer += 1;
			if (wait_timer >= 60) {
				int game_index = 1;  
				SceneManager.LoadScene (game_index);
			}
		}
	}
}
