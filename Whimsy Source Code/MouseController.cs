
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour {
	

	public int Selected;//holds int that will determine what the variable will be determined by other scripts
	public GameObject[] towers; // array that holds the types of towers that can be put down
	public int[] prices;//the price that you must pay in money to place the tower
	public GameObject tile;//the placeholder where the tower can be placed
	private Money money;//reference to money script
	private TileTaken tileTaken;
	public Image icon;
	public int currentSeedCount;




	void Start(){

		tileTaken = GetComponent<TileTaken> ();
		money = GetComponent<Money> ();
		money.SetSeedText ();


	}

	void Update(){

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			
			tile = hit.collider.gameObject;

		} 
		else {

			tile = null;

		}
		if (Input.GetMouseButtonDown (0) && tile != null) {

			Debug.Log ("hit tile");


			if ((!tile.GetComponent<TileTaken>().isTaken) && money.money > prices[Selected])
			{
				
					currentSeedCount = money.money -= prices [Selected];
				money.SetSeedText ();
					Debug.Log (money.money);
					Vector3 pos = new Vector3 (tile.transform.position.x, .5f, tile.transform.position.z);
					tileTaken.Tower = (GameObject)Instantiate (towers [Selected], pos, Quaternion.Euler(90,0,0));
					tile.GetComponent<TileTaken>().isTaken = true;
			}
		}
	}
}