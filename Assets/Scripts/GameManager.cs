using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject chatHandlerScript;
	ChatHandler chatHandler;

	GameObject notePad;


	public GameState currentState;


	// Use this for initialization
	void Awake () {
		currentState = GameState.Dialogue;
		chatHandlerScript = GameObject.Find ("TextInterface");
		chatHandler = chatHandlerScript.GetComponent<ChatHandler> ();
		notePad = GameObject.Find ("NotePad");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == GameState.Choice) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				notePad.GetComponent<notePadController> ().MoveUp();
				return;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				notePad.GetComponent<notePadController> ().MoveDown();
			} else if (Input.GetKeyDown (KeyCode.Space)) {
				string selected = notePad.GetComponent<notePadController> ().GetSelected();
				chatHandler.NextTwee(selected);
			}
		} else if (currentState == GameState.Dialogue) {

			if (Input.GetKeyDown(KeyCode.Space)) {
			
				if (chatHandler.IsLastLine()) {
					currentState = GameState.Choice;
				}else{
					chatHandler.NextLine();
				}

			} else {
				return;
			}
		}
	}

	public void SetState(GameState state) {
		currentState = state;
	}

	public void HandleTags(string[] tags) {
		foreach (string tag in tags) {
			handleTag (tag);
		}
	}

	private void handleTag(string tag) {
		//whatever;
		return;
	}
}

public enum GameState{Choice, Dialogue};
