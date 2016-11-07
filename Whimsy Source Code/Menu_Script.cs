using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour {

	public Button s_button;  //Story Button
	public Button c_button;  //Credits Button
	public Button g_button;  //Game Start Button
	public Button m_button;  //Menu Button

	public GameObject t_screen;
	public GameObject c_screen;
	public GameObject s_screen;

	public Vector3 gone_pos;
	public Vector3 story_pos;
	public Vector3 credits_pos;
	public Vector3 game_pos;
	public Vector3 menu_pos;

	Vector3 out_pos;
	Vector3 in_pos;

	// Use this for initialization
	void Start () {
		out_pos = new Vector3 (0f,1f,20f);
		in_pos = new Vector3 (0f,1f,14.8f);
		m_button.GetComponent<CanvasRenderer> ().SetAlpha (0);
		m_button.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Display the story
	public void Show_Story(){
		//Reset positions
		s_button.interactable = false;
		c_button.interactable = false;
		g_button.interactable = false;
		m_button.interactable = true;

		s_button.GetComponent<RectTransform> ().anchoredPosition3D = gone_pos;
		c_button.GetComponent<RectTransform> ().anchoredPosition3D = gone_pos;
		g_button.GetComponent<RectTransform> ().anchoredPosition3D = gone_pos;
		m_button.GetComponent<RectTransform> ().anchoredPosition3D = menu_pos;

		t_screen.transform.position = out_pos;
		c_screen.transform.position = out_pos;
		s_screen.transform.position = in_pos;
	}

	//Display the credits
	public void Show_Credits(){
		//Reset positions
		s_button.interactable = false;
		c_button.interactable = false;
		g_button.interactable = false;
		m_button.interactable = true;

		s_button.GetComponent<RectTransform> ().anchoredPosition3D = gone_pos;
		c_button.GetComponent<RectTransform> ().anchoredPosition3D = gone_pos;
		g_button.GetComponent<RectTransform> ().anchoredPosition3D = gone_pos;
		m_button.GetComponent<RectTransform> ().anchoredPosition3D = menu_pos;

		t_screen.transform.position = out_pos;
		c_screen.transform.position = in_pos;
		s_screen.transform.position = out_pos;
	}

	//Return to menu
	public void Show_Menu(){
		//Reset positions
		s_button.interactable = true;
		c_button.interactable = true;
		g_button.interactable = true;
		m_button.interactable = false;

		s_button.GetComponent<RectTransform> ().anchoredPosition3D = story_pos;
		c_button.GetComponent<RectTransform> ().anchoredPosition3D = credits_pos;
		g_button.GetComponent<RectTransform> ().anchoredPosition3D = game_pos;
		m_button.GetComponent<RectTransform> ().anchoredPosition3D = gone_pos;


		t_screen.transform.position = in_pos;
		c_screen.transform.position = out_pos;
		s_screen.transform.position = out_pos;
	}


	//Start the game
	public void Start_Game(){
		//LIV CHANGE THIS VALUE TO FIT THE INDEX OF THE GAME SCENE
		int game_index = 1;  


		SceneManager.LoadScene (game_index);
	}


}
