using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject chatHandlerScript;
	ChatHandler chatHandler;

	GameObject notePad;
	GameObject titleScreen;

	public AudioSource baseLayer;
	public AudioSource layer2;
	public AudioSource layer3;
	public AudioSource layer4;
	public AudioSource darkLayer;

	public GameState currentState;


	// Use this for initialization
	void Awake () {
		currentState = GameState.Intro;
		chatHandlerScript = GameObject.Find ("TextInterface");
		chatHandler = chatHandlerScript.GetComponent<ChatHandler> ();
		notePad = GameObject.Find ("NotePad");
		titleScreen = GameObject.Find ("TitleScreen");

	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == GameState.Intro) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				titleScreen.GetComponent<Faded> ().Fade ();
				string selected = notePad.GetComponent<notePadController> ().GetSelected ();
				chatHandler.NextTwee (selected);
				currentState = GameState.Dialogue;
			}
		}
		else if (currentState == GameState.Choice) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				notePad.GetComponent<notePadController> ().MoveUp();
				return;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				notePad.GetComponent<notePadController> ().MoveDown();
			} else if (Input.GetKeyDown (KeyCode.Space)) {
				string selected = notePad.GetComponent<notePadController> ().GetSelected();
				chatHandler.NextTwee(selected);
				currentState = GameState.Dialogue;
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
		switch (tag) 
		{
		case "NAJ":
			break;
		}
		return;
	}

	public void StartDarkAudio() {
		darkLayer.mute = false;
	}

	public void StopDarkAudio() {
		darkLayer.mute = true;
	}

	public void StartLayer2Audio() {
		layer2.mute = false;
	}

	public void StopLayer2Audio() {
		layer2.mute = true;
	}

	public void StartLayer3Audio() {
		layer3.mute = false;
	}
	
	public void StopLayer3Audio() {
		layer3.mute = true;
	}

	public void StartLayer4Audio() {
		layer4.mute = false;
	}
	
	public void StopLayer4Audio() {
		layer4.mute = true;
	}
}

public enum GameState{Choice, Dialogue, Intro, Ending};

public enum Emotion{Angry, Happy, Neutral, Sad}
