using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour {

	//The Player's deck of cards, stored as an array of integers, with each integer representing a specific card
	public List<int> Deck;

	//The Player's Hand, stored in the same manner
	public List<int> Hand;

	//The Discard Pile, where the used cards end up
	public List<int> Discard;


	//Add a card from the deck to the hand
	public void Draw_Card(){
		Hand.Add(Deck[0]);
		Deck.RemoveAt(0);
	}

	//Remove a card from the hand to the discard pile
	public void Discard_Card(int index){
		Discard.Add (Hand [index]);
		Hand.RemoveAt (index);
	}

	//Remove a card from the deck to the discard pile
	public void Mill_Card(int index){
		Discard.Add (Deck [index]);
		Deck.RemoveAt (index);
	}

	//Recover a card from the discard pile to the deck
	public void Recover_Deck(int index){
		Deck.Add (Discard [index]);
		Discard.RemoveAt (index);
		Shuffle_Deck ();
	}

	//Recover a card from the discard pile to the hand
	public void Recover_Hand(int index){
		Hand.Add (Discard [index]);
		Discard.RemoveAt (index);
		Shuffle_Deck ();
	}

	//Shuffle the deck
	public void Shuffle_Deck(){
		for (int i = 0; i < Deck.Count; i += 1) {
			int temp = Deck [i];
			int new_index = Random.Range (i, Deck.Count);
			Deck [i] = Deck [new_index];
			Deck [new_index] = temp;
		}
	}

	//Generate the deck based on the GameManager stats 
	public void Create_Deck(){
		GameManager gm = GameObject.Find ("Game_Manager").GetComponent<GameManager> ();
		//First, determine the deck size based on the total stats
		int total_stat = gm.CON + gm.STR + gm.INT + gm.DEX + gm.LCK;
		int c = 0;
		int rand_card = 0;
		while (c < total_stat) {
			if (c < gm.CON) {
				rand_card = Random.Range (0, 9);
			} else if (c < gm.CON + gm.STR) {
				rand_card = Random.Range (10, 19);
			} else if (c < gm.CON + gm.STR + gm.INT) {
				rand_card = Random.Range (20, 29);
			} else if (c < gm.CON + gm.STR + gm.INT + gm.DEX) {
				rand_card = Random.Range (30, 39);
			} else{
				rand_card = Random.Range (40, 49);
			}
			Deck.Add (rand_card);
			c += 1;
		}
		//Once we have the list of cards, shuffle the deck
		Shuffle_Deck();
	}

}
