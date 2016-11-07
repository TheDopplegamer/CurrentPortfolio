using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	public GameObject destination;
	NavMeshAgent agent;
	int currentHealth;
	public int initialHealth = 20;

	// Use this for initialization
	void Start () {
		
		agent = GetComponent<NavMeshAgent> ();
		currentHealth = initialHealth;

	}

	void Update () 
	{

		agent.SetDestination (destination.transform.position);

	}

	public void TakeDamage(int damage)
	{
		
			currentHealth -= damage;

		Debug.Log ("Current Health = " + currentHealth);

		if (currentHealth < 0) {

			Destroy (gameObject);
		}
	}
}