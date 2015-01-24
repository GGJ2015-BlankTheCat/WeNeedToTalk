using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;



public class ChatParser : MonoBehaviour {

	GameObject gameManager;
	GameObject textBox;
	GameObject notePad;
	public Dictionary<string, tweeEntry> tweeEntries; 
	

	public tweeEntry currentEntry;
	public int CurrentLine;
	public int lastBodyLine;
	
	void Awake(){
		gameManager = GameObject.Find ("gameManager");
		tweeEntries = gameManager.GetComponent<TweeParser> ().entries;
		textBox = GameObject.Find ("TextBox");
		notePad = GameObject.Find ("Note Pad");

		CurrentLine = 0;

	}

	void NextTwee(string title){
		currentEntry = tweeEntries [title];
		CurrentLine = 0;

		int lineCtr = 0;
		foreach (string line in currentEntry.body) {
			if(line.Trim ().IndexOf ('[') == 0) {
				break;
			}
			lineCtr++;
		}
		//This should return the last line which isn't an option
		lastBodyLine = lineCtr--;
	}
	
	public void NextLine() {
		CurrentLine++;
	}

	public bool IsLastLine() {
		return CurrentLine == lastBodyLine;
	}

	void OnGui(){
		textBox.GetComponent<Text> ().text = currentEntry.body [CurrentLine];
	}

	void RenderNotePad() {

	}
}
