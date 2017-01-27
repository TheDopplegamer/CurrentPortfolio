using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poofscript : MonoBehaviour {

	public Sprite[] poofs = new Sprite[22];
	int timer;
	int ind;
	SpriteRenderer render;
	
	// Use this for initialization
	void Start () {
		render = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += 1;
		if(timer >= 1){
			timer = 0;
			ind += 1;
			if(ind == 22){
				Destroy(gameObject);
			}
			else{
				render.sprite = poofs[ind];
			}
		}
	}
}
