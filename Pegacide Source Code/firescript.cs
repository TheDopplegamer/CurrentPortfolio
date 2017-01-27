using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firescript : MonoBehaviour {

	public Sprite[] sprites = new Sprite[5];
	int timer;
	int ft;
	public bool spreading;
	int tt;
	SpriteRenderer render;
	
	
	
	// Use this for initialization
	void Start () {
		render = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer+=1;
		if(ft < 61){
			ft += 1;
		}
		if(timer >= 3){
			render.sprite = sprites[Random.Range(0,5)];
			timer = 0;
		}
		if(transform.localScale.x < transform.parent.localScale.x*4){
			transform.localScale += new Vector3(0.04f,0.04f,0f);
		}
		if(ft >= 60){
			spreading = true;
		}
		
		if(spreading == true){
			tt += 1;
			if(tt >= 10){
				tt = 0;
			Collider[] balls = Physics.OverlapSphere(transform.position,1f);
			for(int i = 0;i < balls.Length;i+=1){
				GameObject ball = balls[i].gameObject;
				if(ball.GetComponent<Flammable>() != null && ball.GetComponent<Flammable>().burn_baby_burn == false){
					ball.GetComponent<Flammable>().Birth_Mighty_Flame();
					spreading = false;
					ft = 0;
				}
			}
			}
		}
		
	}
}
