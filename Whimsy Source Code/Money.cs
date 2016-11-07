using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Money : MonoBehaviour {

	public int money;
	public Text seedCount;



	public void SetSeedText(){

		seedCount.text = "Seeds: " + money.ToString ();

	}

}
