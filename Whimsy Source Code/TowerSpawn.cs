using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerSpawn : MonoBehaviour {

	public int Index;//indicates which index number the tower has been assigned Element 0,1, or 2
	public MouseController mouseController;


	public void OnClick(){
		Debug.Log ("hit");

//		if (icon.tag == "MushroomUI") {
//
//			money.money -= 10;
//		}
		mouseController.Selected = Index;

	}
}
