using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class game_over_scroll : MonoBehaviour {

	public float speed;
	public bool active;
	public int timer;
	public bool starter;

	public GameObject layer_1;
	public GameObject layer_2;
	public GameObject layer_3;
	public GameObject layer_4;

	public GameObject re_but;
	public GameObject qu_but;

	public bool active_2;

	// Use this for initialization
	void Start () {
		speed = 8f;
		timer = 0;
		active = false;
		active_2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			transform.Translate (Vector3.down * speed * Time.deltaTime);
			if (transform.position.y <= 9.15898f) {
				Set_Coordinates ();
				timer = 0;
				active_2 = true;
				GetComponent<AudioSource> ().Play ();
				active = false;
			}
		}
		if (active_2) {
				timer += 1;
				if (timer == 15) {
					layer_1.GetComponent<game_over_scroll> ().Set_Coordinates ();
				} else if (timer == 30) {
					layer_2.GetComponent<game_over_scroll> ().Set_Coordinates ();
				} else if (timer == 45) {
					layer_3.GetComponent<game_over_scroll> ().Set_Coordinates ();
				} else if (timer == 60) {
					layer_4.GetComponent<game_over_scroll> ().Set_Coordinates ();
					re_but.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (-253f, 82f, 0f);
					qu_but.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (308f, -78f, 0f);
				}
		}
	}

	public void Begin_Scroll(){
		active = true;
		GameObject[] ui_list = GameObject.FindGameObjectsWithTag ("ui");
		int sz = ui_list.Length;
		int n = 0;
		while (n < sz) {
			ui_list [n].GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (2000f, 2000f, 2000f);
			n += 1;
		}
	}

	public void Set_Coordinates(){
		transform.position = new Vector3 (-10.66665f, 9.15898f, -9f);
	}

	public void Replay(){
		SceneManager.LoadScene (1);
	}

	public void Quit_game(){
		SceneManager.LoadScene (0);
	}
}
