using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject chatHandler;
	ChatParser chatParser;

	public enum GameState{Choice, Dialogue};

	public GameState currentState;


	// Use this for initialization
	void Awake () {
		currentState = GameState.Dialogue;
		chatHandler = GameObject.Find ("ChatHandler");
		chatParser = chatHandler.GetComponent<ChatParser> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == GameState.Choice) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				return;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				return;
			} else if (Input.GetKeyDown (KeyCode.Space)) {
				return;
			}
		} else if (currentState == GameState.Dialogue) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				chatParser.NextLine();
				if (chatParser.IsLastLine()) {
					currentState = GameState.Choice;
				}
			} else {
				return;
			}
		}
	}
}
