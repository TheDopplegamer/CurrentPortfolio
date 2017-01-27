using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetscript : MonoBehaviour {

	public GameObject ball;
	public Sprite[] targsprites = new Sprite[3];
	public int mode;
	
	public bool fire_shot;
	public bool force_shot;
	public bool ball_shot;
	
	public AudioClip force_sound;
	public AudioClip burn_sound;
	public AudioClip ball_sound;
	public AudioClip horse_death;
	
	public bool losing;
	public bool winning;
	
	public void Play_Sound(int s){
		if(s == 1){
			gameObject.GetComponent<AudioSource> ().clip = force_sound;
		}
		else if(s == 2){
			gameObject.GetComponent<AudioSource> ().clip = ball_sound;
		}
		else if(s == 3){
			gameObject.GetComponent<AudioSource> ().clip = burn_sound;
		}
		else if(s == 4){
			gameObject.GetComponent<AudioSource> ().clip = horse_death;
		}
		gameObject.GetComponent<AudioSource> ().Play ();
	}
	
	// Use this for initialization
	void Start () {
		mode = 1;
		fire_shot = true;
		force_shot = true;
		ball_shot = true;
	}
	
	
	void swap(){
		if(mode == 3){
			mode = 1;
		}
		else{
			mode += 1;
		}
		if(mode == 1){
			if(!force_shot){
				if(!ball_shot){
					if(!fire_shot){
						Loss();
					}
					else{
						mode = 3;
					}
				}
				else{
					mode = 2;
				}
			}
		}
		else if(mode == 2){
			if(!ball_shot){
				if(!fire_shot){
					if(!force_shot){
						Loss();
					}
					else{
						mode = 1;
					}
				}
				else{
					mode = 3;
				}
			}
		}
		else if(mode == 3){
			if(!fire_shot){
				if(!force_shot){
					if(!ball_shot){
						Loss();
					}
					else{
						mode = 2;
					}
				}
				else{
					mode = 1;
				}
			}
		}
		
		gameObject.GetComponent<SpriteRenderer>().sprite = targsprites[mode-1];
	}
	
	
	void Loss(){
		GameObject.Find("Results").GetComponent<Text>().text = "YOU LOSE....Click to Reset!";
		losing = true;
	}
	
	public void Win(){
		GameObject.Find("Results").GetComponent<Text>().text = "PEGASUS HUNTED!!!!!   Click to advance!";
		losing = false;
		winning = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			swap();
		}
		
		Vector3 temp = Input.mousePosition;
		temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
		this.transform.position = Camera.main.ScreenToWorldPoint(temp);
		
		if(Input.GetMouseButtonDown(0)){
			
			if(losing){
				GameObject.Find("Man").GetComponent<mans>().Reset();
			}
			else if(winning){
				GameObject.Find("Man").GetComponent<mans>().Next_Level();
			}
			else{
			//Make sure it's legal
			bool leg = true;
			Collider[] fin  =Physics.OverlapSphere(transform.position,0.75f);
			for(int l = 0;l < fin.Length;l+=1){
				if(fin[l].gameObject.tag == "safe"){
					leg = false;
				}
			}
			
			if(leg){
			//Force Mode
			if(mode == 1){
				Collider[] balls = Physics.OverlapSphere(transform.position,0.75f);
				
				if(balls.Length > 0){
				for(int i = 0;i < balls.Length;i+=1){
					if(balls[i].gameObject.tag == "toy"){
						Rigidbody body = balls[i].gameObject.GetComponent<Rigidbody>();
						Vector3 dir = (balls[i].gameObject.transform.position-transform.position).normalized;
						body.AddForce(5000*dir);
					}
					else if(balls[i].gameObject.tag == "ice"){
						Rigidbody body = balls[i].gameObject.GetComponent<Rigidbody>();
						body.useGravity = true;
						 balls[i].gameObject.GetComponent<AudioSource>().Play();
						
					}
					
				}
				Play_Sound(1);
				force_shot = false;
				swap();
				}
			}
			//Drop Iron Ball Mode
			else if(mode == 2){
				GameObject b = Instantiate(ball);
				b.transform.position = transform.position;
				Play_Sound(2);
				ball_shot = false;
				swap();
			}
			//Burn Mode
			else if(mode == 3){
				Collider[] balls = Physics.OverlapSphere(transform.position,0.1f);
				if(balls.Length > 0){
				for(int i = 0;i < balls.Length;i+=1){
					if(balls[i].gameObject.GetComponent<Flammable>() != null){
						balls[i].gameObject.GetComponent<Flammable>().Birth_Mighty_Flame();
					}
				}
				Play_Sound(3);
				fire_shot = false;
				swap();
				}
			}
			}
			}
		}
		
		
	}
}
