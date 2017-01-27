using UnityEngine;
using System.Collections;

public class bullet_script : MonoBehaviour {

	public float spd;
	public bool shooting;
	public GameObject bullet;
	public GameObject bounce;
	public GameObject gun;
	int timer;
	int breaker = -1;
	
	void Awake(){
		Application.targetFrameRate = 60;
	}
	void FixedUpdate () {
		if(shooting){
			Move();
			timer += 1;
			if(timer >= 180){
				Destroy(gameObject);
			}
			if(breaker >= 0){
				breaker -= 1;
			}
		}
		else{
			Draw_Laser();
		}
		if(Input.GetKeyDown("x")){
			Shoot();
		}
	}
	void rot(float angle){
		transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,-(transform.rotation.eulerAngles.z));
		transform.Rotate(0,0,2*angle);
		Correct_Angles();
	}
	void Move(){
		transform.Translate(Vector3.right * spd * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other){
		if(shooting){
			GameObject surface = other.gameObject;
			if(surface.tag == "wall"){
				if(breaker == -1){
					rot(surface.transform.rotation.eulerAngles.z);
					GameObject effect = Instantiate(bounce);
					effect.transform.position = transform.position;
					breaker = 0;
				}
				else{
					
				}
			}
			else if(surface.tag == "Player" && surface != gun){
				surface.GetComponent<playerscript>().explosion.active = true;
				Destroy(gameObject);
			}
		}
	}	
	void Correct_Angles(){
		float z = transform.rotation.eulerAngles.z;
		if(z >= 360){
			z = (z - 360);
			transform.rotation = Quaternion.Euler(0,0,z);
			Correct_Angles();
		}
		else if(z < 0){
			z = (360 - z);
			transform.rotation = Quaternion.Euler(0,0,z);
			Correct_Angles();
		}
	}
	void Shoot(){
		GameObject new_bullet = Instantiate(bullet);
		new_bullet.transform.position = transform.position;
		new_bullet.transform.rotation = transform.rotation;
		new_bullet.GetComponent<bullet_script>().shooting = true;
		new_bullet.GetComponent<bullet_script>().spd = spd;
		new_bullet.GetComponent<bullet_script>().bullet = bullet;
		new_bullet.GetComponent<bullet_script>().gun = gun;
	}	
	void Draw_Laser(){
		Vector3 coll_vect = new Vector3 (transform.position.x,transform.position.y,transform.position.z);
		Debug.DrawRay (coll_vect, Vector3.right * 2f);
	}
}
