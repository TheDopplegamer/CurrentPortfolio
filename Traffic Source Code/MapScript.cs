using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour {

	public GameObject tiles;
	public bool called;
	public int[] map_array;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 30;
		Create_Map ();
	}


	void Create_Map(){
		called = true;
		int x_pos = 0;
		int y_pos = 0;
		int n = 0;
		while (y_pos < 10) {
			while (x_pos < 10) {
				Vector3 new_pos = new Vector3 (x_pos, y_pos, 0);
				GameObject new_tile = Instantiate (tiles);
				new_tile.transform.position = new_pos;
				new_tile.GetComponent<TileScript> ().type = map_array [n];
				new_tile.GetComponent<TileScript> ().Set_Sprite ();
				new_tile.GetComponent<TileScript> ().x = x_pos;
				new_tile.GetComponent<TileScript> ().y = y_pos;
				new_tile.name = "tile" + n.ToString ();
				n += 1;
				x_pos += 1;
			}
			x_pos = 0;
			y_pos += 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
