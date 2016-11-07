using UnityEngine;
using System.Collections;

public class Turret_Animator : MonoBehaviour {

	public Sprite ghost_1_wait;
	public Sprite ghost_1_attack;
	public Sprite ghost_1_cooldown;
	public Sprite ghost_2_wait;
	public Sprite ghost_2_attack;
	public Sprite ghost_2_cooldown;

	public Sprite zombie_1_wait;
	public Sprite zombie_1_attack;
	public Sprite zombie_1_cooldown;
	public Sprite zombie_2_wait;
	public Sprite zombie_2_attack;
	public Sprite zombie_2_cooldown;

	public Sprite skeleton_1_wait;
	public Sprite skeleton_1_attack;
	public Sprite skeleton_1_cooldown;
	public Sprite skeleton_2_wait;
	public Sprite skeleton_2_attack;
	public Sprite skeleton_2_cooldown;

	public Sprite chand_1_wait;
	public Sprite chand_1_attack;
	public Sprite chand_1_cooldown;
	public Sprite chand_2_wait;
	public Sprite chand_2_attack;
	public Sprite chand_2_cooldown;

	public AudioClip ghost_sound;
	public AudioClip skeleton_sound;
	public AudioClip zombie_sound;

	public AudioClip chand_sound;
	public AudioClip knife_sound;
	public AudioClip book_sound;
	
	public Sprite k_sprite;
	public Sprite b_sprite; 
	public Sprite k_2_sprite;
	public Sprite b_2_sprite;


	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;

	}
	
	// Update is called once per frame
	void Update () {

	}
}
