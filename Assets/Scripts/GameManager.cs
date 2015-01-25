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

	public int rodWins;
	public int rayWins;
	public int compromises;


	// Use this for initialization
	void Awake () {
		currentState = GameState.Intro;
		chatHandlerScript = GameObject.Find ("TextInterface");
		chatHandler = chatHandlerScript.GetComponent<ChatHandler> ();
		notePad = GameObject.Find ("NotePad");
		titleScreen = GameObject.Find ("TitleScreen");



		rodWins = 0;
		rayWins = 0;
		compromises = 0;
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
		case "A_WIN":
			compromises++;
			break;
		case "E_WIN":
			compromises++;
			break;
		case "M_WIN":
			compromises++;
			break;
		case "A_ROD":
			rodWins++;
			break;
		case "E_ROD":
			rodWins++;
			break;
		case "M_ROD":
			rodWins++;
			break;
		case "A_RAY":
			rayWins++;
			break;
		case "E_RAY":
			rayWins++;
			break;
		case "M_RAY":
			rayWins++;
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

public enum GameState{Choice, Dialogue, Intro};

public enum Emotion{Angry, Happy, Neutral, Sad}
