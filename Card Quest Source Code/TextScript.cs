using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	//Reference to text children
	public GameObject t0;
	public GameObject t1;
	public GameObject t2;
	public GameObject t3;
	public GameObject t4;


	//Take input text and update children
	public void Update_Text(string new_text){
		t4.GetComponent<Text> ().text = t3.GetComponent<Text> ().text;
		t3.GetComponent<Text> ().text = t2.GetComponent<Text> ().text;
		t2.GetComponent<Text> ().text = t1.GetComponent<Text> ().text;
		t1.GetComponent<Text> ().text = t0.GetComponent<Text> ().text;
		t0.GetComponent<Text> ().text = new_text;
	}
}
