using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;



public class ChatHandler : MonoBehaviour {

	GameObject gameManager;
	GameObject textBox;
	GameObject notePad;
	public Dictionary<string, tweeEntry> tweeEntries; 
	

	public tweeEntry currentEntry;
	public int CurrentLine;
	public int lastBodyLine;
	
	void Awake(){
		gameManager = GameObject.Find ("GameManager");
		tweeEntries = gameManager.GetComponent<TweeParser> ().entries;
		textBox = GameObject.Find ("TextBox");
		notePad = GameObject.Find ("NotePad");

		CurrentLine = 0;

		//TODO: REAL INITIALIZE
		NextTwee("StoryTitle");
		

	}

	public void NextTwee(string title){
		gameManager.GetComponent<GameManager> ().SetState (GameState.Dialogue);
	
		currentEntry = tweeEntries [title];
		CurrentLine = 0;

		int lineCtr = 0;
		foreach (string line in currentEntry.body) {
			if(isOption (line)) {
				break;
			}
			lineCtr++;
		}
		//This should return the last line which isn't an option
		lastBodyLine = lineCtr - 1;

		notePad.GetComponent<notePadController> ().SetPrompt (GetCurrentLine());
		notePad.GetComponent<notePadController> ().SetOptions (getOptions (currentEntry.body));
		
		gameManager.GetComponent<GameManager> ().HandleTags (currentEntry.tags);
	}
	
	public void NextLine() {
		CurrentLine++;
	}

	public bool IsLastLine() {
		return CurrentLine == lastBodyLine;
	}

	public string GetCurrentLine(){
		return currentEntry.body[CurrentLine];	
	}


	public Dictionary<string,string> getOptions(string[] body){

		Dictionary<string, string> options = new Dictionary<string, string>();

		foreach(string line in body){
			if(isOption(line)){
				string trimmedLine = line.Trim(new char[] {' ', '[', ']'}).Replace("]]", string.Empty);
				string[] splitLine = trimmedLine.Split(new char[]{'|'}); 
				if(splitLine.Length == 1) {
					options.Add(splitLine[0].Trim(),splitLine[0].Trim ());
				} else {
					options.Add(splitLine[0].Trim(),splitLine[1].Trim ());
				}
			}
		}

		return options;
	}

	public bool isOption(string line){
		return line.Trim ().IndexOf ("[[") != -1;

	}



}
