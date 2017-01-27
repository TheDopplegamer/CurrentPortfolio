using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	public Sprite grass_spr;
	public Sprite road_spr;
	public GameObject cur_truck;
	public int x;
	public int y;

	//The type determines the type of tile
	//-----------------------------------
	// 0 - Grass
	// 1 - Road blank 
	public int type;


	// Use this for initialization
	void Start () {
		
	}

	public void Set_Sprite(){
		if (type == 0) {
			GetComponent<SpriteRenderer> ().sprite = grass_spr;
		} else if (type == 1) {
			GetComponent<SpriteRenderer> ().sprite = road_spr;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}


}
