using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject chatHandlerScript;
	ChatHandler chatHandler;

	GameObject notePad;
	GameObject titleScreen;
	GameObject endscreen;

	public AudioSource baseLayer;
	public AudioSource layer2;
	public AudioSource layer3;
	public AudioSource layer4;
	public AudioSource darkLayer;
	public AudioSource lineStrike;
	public AudioSource explosion;
	public AudioSource FWB;

	RayEmotions rayEmote;
	RodEmotions rodEmote;

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
		endscreen = GameObject.Find("BlackFade");

		rodWins = 0;
		rayWins = 0;
		compromises = 0;

		rayEmote = GameObject.Find ("RaySprite").GetComponent<RayEmotions>();
		rodEmote = GameObject.Find ("RodSprite").GetComponent<RodEmotions>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Debug.Log("escape pressed");
			Application.Quit();
		}


		if (currentState == GameState.Intro) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				titleScreen.GetComponent<Faded> ().Fade ();
				string selected = notePad.GetComponent<notePadController> ().GetSelected ();
				chatHandler.NextTwee (selected);
				if(currentState != GameState.Ending)
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
				lineStrike.Play();
				string selected = notePad.GetComponent<notePadController> ().GetSelected();
				chatHandler.NextTwee(selected);
				if(currentState != GameState.Ending)
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
		if (rayWins > rodWins || rodWins > rayWins) {
			StopLayer2Audio ();
		} else {
			StartLayer2Audio ();
		}
		if (compromises >= 1) {
			StartLayer3Audio ();
		}
		if (compromises >= 2 || (rodWins == 1 && rayWins == 1)) {
			StartLayer4Audio();
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
		Debug.Log (tag);
		switch (tag.Trim()) 
		{
		case "A_Win":
			compromises++;
			break;
		case "E_Win":
			compromises++;
			break;
		case "M_Win":
			compromises++;
			break;
		case "A_Rod":
			rodWins++;
			break;
		case "E_Rod":
			rodWins++;
			break;
		case "M_Rod":
			rodWins++;
			break;
		case "A_Ray":
			rayWins++;
			break;
		case "E_Ray":
			rayWins++;
			break;
		case "M_Ray":
			rayWins++;
			break;
		case "Naj":
			rayEmote.SetEmotion(Emotion.Neutral);
			break;
		case "Nach":
			rodEmote.SetEmotion (Emotion.Neutral);
			break;
		case "Aaj":
			rayEmote.SetEmotion(Emotion.Angry);
			break;
		case "Aach":
			rodEmote.SetEmotion (Emotion.Angry);
			break;
		case "Haj":
			rayEmote.SetEmotion(Emotion.Happy);
			break;
		case "Hach":
			rodEmote.SetEmotion (Emotion.Happy);
			break;
		case "Saj":
			rayEmote.SetEmotion(Emotion.Sad);
			break;
		case "Sach":
			rodEmote.SetEmotion (Emotion.Sad);
			break;
		case "End":
			if(rodWins + rayWins + compromises < 3){
				explosion.Play();

			}

			if(compromises == 3 || (rodWins == 1 && rayWins == 1 && compromises == 1)){
				StopDarkAudio();
				StopBaseLayerAudio();
				StopLayer2Audio();
				StopLayer3Audio();
				StopLayer4Audio();

				FWB.Play();

			}

			currentState = GameState.Ending;
			StartDarkAudio();
			endscreen.GetComponent<Faded>().Fade();
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

	public void StopBaseLayerAudio(){
		baseLayer.mute = true;
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
