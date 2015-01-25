using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class notePadController : MonoBehaviour {

	string prompt;

	int selected;

	GameObject gameManagerObject;
	GameManager gameManagerScript;
	
	GameObject textInterfaceObject;
	ChatHandler chatHandlerScript;
	
	GameState currentState;

	public Dictionary<string, string> Options;


	// Use this for initialization
	void Awake () {
		gameManagerObject = GameObject.Find ("GameManager");
		textInterfaceObject = GameObject.Find ("TextInterface");
		
		gameManagerScript = gameManagerObject.GetComponent<GameManager> ();
		chatHandlerScript = textInterfaceObject.GetComponent<ChatHandler> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		currentState = gameManagerScript.currentState;	
	}


	void OnGUI(){
		if (currentState == GameState.Choice) {
			string[] keys = new string[Options.Keys.Count];
			Options.Keys.CopyTo(keys, 0);

			GUI.SelectionGrid(new Rect(100, 100, 1000, 100), selected, keys, 2);

			
		}

	}


	public void SetPrompt(string line) {
		prompt = line;
	}

	public void SetOptions(Dictionary<string,string> input) {
		Options = new Dictionary<string, string>(input);
	}

	public string GetSelected() {
		string[] keys = new string[Options.Keys.Count];
		Options.Keys.CopyTo(keys, 0);

		return  keys[selected];
	}

	public void MoveUp() {
		if (selected == 0) {
			selected = Options.Keys.Count - 1;
		} else {
			selected--;
		}
	}

	public void MoveDown() {
		if (selected == Options.Keys.Count - 1) {
			selected = 0;
		} else {
			selected++;
		}
	}

}
