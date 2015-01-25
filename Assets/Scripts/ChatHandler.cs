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
		Debug.Log ("title: " + title);
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

		notePad.GetComponent<notePadController> ().SetOptions (getOptions (currentEntry.body));
		gameManager.GetComponent<GameManager> ().SetState (GameState.Dialogue);
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
				Debug.Log ("line: " + line);
				Debug.Log ("trimmedLine: " + trimmedLine);
				string[] splitLine = trimmedLine.Split(new char[]{'|'}); 
				if(splitLine.Length == 1) {
					Debug.Log ("1 Element is : " + splitLine[0]);
					options.Add(splitLine[0],splitLine[0]);
				} else {
					Debug.Log ("2 elements is: " + splitLine[0] + "/" + splitLine[1]);
					options.Add(splitLine[0],splitLine[1]);
				}
			}
		}

		return options;
	}

	public bool isOption(string line){
		return line.Trim ().IndexOf ("[[") != -1;

	}

}
