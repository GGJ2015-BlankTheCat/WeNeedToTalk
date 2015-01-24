using UnityEngine;
using System.Collections;

public class TextBoxController : MonoBehaviour {



	GameObject gameManagerObject;
	GameManager gameManagerScript;

	GameObject textInterfaceObject;
	ChatParser chatParserScript;

	GameState currentState;

	// Use this for initialization
	void Awake () {
		gameManagerObject = GameObject.Find ("gameManager");
		textInterfaceObject = GameObject.Find ("TextInterface");

		gameManagerScript = gameManagerObject.GetComponent<GameManager> ();
		chatParserScript = textInterfaceObject.GetComponent<ChatParser> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		currentState = gameManagerScript.currentState;


	}

	void OnGUI() {
		if (currentState == GameState.Dialogue) {

			GUI.Label(new Rect(300, 300, 300,300), chatParserScript.GetCurrentLine());


			}

	}
}
