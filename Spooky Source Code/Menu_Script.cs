using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour {

	public Button s_button;  //Start Button
	public Button c_button;  //Credits Button
	public Button q_button;  //Game Start Button

	public GameObject lawn_1;
	public GameObject lawn_2;

	public bool moving;

	public GameObject main;
	public int timer;
	public float speed;


	// Use this for initialization
	void Start () {
		moving = false;
		timer = -1;
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			lawn_1.transform.Translate (Vector3.right * speed * Time.deltaTime);
			lawn_2.transform.Translate (Vector3.right * speed * Time.deltaTime);
			main.transform.Translate (Vector3.right * speed * Time.deltaTime);
			if (lawn_2.transform.position.x >= -10.65f) {
				lawn_2.transform.position = new Vector3 (-10.65f, 9.19f, 0f);
				moving = false;
				timer = 0;
			}
		}
		if (timer > -1) {
			timer += 1;
			if (timer >= 40) {
				Start_Game ();
			}
		}
	}

	//Display the credits
	public void Show_Credits(){
		SceneManager.LoadScene (2);
	}

	public void Quit_Game(){
		Application.Quit ();
	}

	public void Start_Move(){
		moving = true;
		main.GetComponent<Sound_Controller> ().Start_Sound ();
		gameObject.GetComponent<AudioSource> ().Stop ();
		Vector3 out_pos = new Vector3 (9000f, -9000f, 100f);
		s_button.GetComponent<RectTransform> ().anchoredPosition3D = out_pos;
		q_button.GetComponent<RectTransform> ().anchoredPosition3D = out_pos;
		c_button.GetComponent<RectTransform> ().anchoredPosition3D = out_pos;
	}

	//Start the game
	public void Start_Game(){ 
		SceneManager.LoadScene (1);
	}


}
