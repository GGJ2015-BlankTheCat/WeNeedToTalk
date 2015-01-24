using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;



public class ChatParser : MonoBehaviour {

	GameObject gameManager;
	public Dictionary<string, tweeEntry> tweeEntries; 
	

	public tweeEntry currentEntry;
	public int CurrentLine;

	void Awake(){
		gameManager = GameObject.Find ("gameManager");
		tweeEntries = gameManager.GetComponent<TweeParser> ().entries;

		CurrentLine = 0;

	}

	void NextTwee(string title){
		currentEntry = tweeEntries [title];
	}




	void OnGui(){

	}

	void Update(){
	}

}
