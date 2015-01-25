using UnityEngine;
using System.Collections;

public class notePadController : MonoBehaviour {

	string prompt;
	string[] choices;

	int selected;

	GameObject gameManagerObject;
	GameManager gameManagerScript;
	
	GameObject textInterfaceObject;
	ChatHandler chatHandlerScript;
	
	GameState currentState;


	public int selGridInt = 0;
	public string[] selStrings = new string[] {"Grid 1", "Grid 2", "Grid 3", "Grid 4"};


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
	

		if (currentState == GameState.Choice) {
			Debug.Log("HEY ITS IN CHOICE MODE OK");
		}
	}


	void OnGUI(){
		if (currentState == GameState.Choice) {
			Debug.Log("HEELO WE ARE IN OPTIONS PLACE OOOKK");
			//GUI.Label(new Rect(300, 600, 300,300), "OPTIONS");
			selGridInt = GUI.SelectionGrid(new Rect(25, 25, 100, 30), selGridInt, selStrings, 2);

			
		}

	}


	public void SetPrompt(string line) {
		prompt = line;
	}

	public void SetOptions(string[] lines) {
		choices = lines;
	}

	public string GetSelected() {
		return choices [selected];
	}

	public void MoveUp() {
		if (selected == 0) {
			selected = choices.Length - 1;
		} else {
			selected--;
		}
	}

	public void MoveDown() {
		if (selected == choices.Length - 1) {
			selected = 0;
		} else {
			selected++;
		}
	}

}
