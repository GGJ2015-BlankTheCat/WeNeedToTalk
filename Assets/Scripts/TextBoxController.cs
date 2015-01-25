using UnityEngine;
using System.Collections;

public class TextBoxController : MonoBehaviour {



	GameObject gameManagerObject;
	GameManager gameManagerScript;

	GameObject textInterfaceObject;
	ChatHandler chatHandlerScript;

	GameState currentState;

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

	void OnGUI() {
		if (currentState == GameState.Dialogue) {

			GUI.Label(new Rect(300, 600, 600,600), chatHandlerScript.GetCurrentLine());


			}

	}
}
