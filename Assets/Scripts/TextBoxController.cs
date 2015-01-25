using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class TextBoxController : MonoBehaviour {



	GameObject gameManagerObject;
	GameManager gameManagerScript;

	GameObject textInterfaceObject;
	ChatHandler chatHandlerScript;

	GameObject chatTextObject;


	GameState currentState;

	// Use this for initialization
	void Awake () {
		gameManagerObject = GameObject.Find ("GameManager");
		textInterfaceObject = GameObject.Find ("TextInterface");

		gameManagerScript = gameManagerObject.GetComponent<GameManager> ();
		chatHandlerScript = textInterfaceObject.GetComponent<ChatHandler> ();

		chatTextObject = GameObject.Find ("ChatText");


	}
	
	// Update is called once per frame
	void Update () {
	
		currentState = gameManagerScript.currentState;


	}

	void OnGUI() {
		if (currentState == GameState.Dialogue) {

			chatTextObject.GetComponent<Text>().text = chatHandlerScript.GetCurrentLine();
				

			}

	}
}
