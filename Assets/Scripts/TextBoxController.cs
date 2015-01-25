using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class TextBoxController : MonoBehaviour {

	public Sprite blankSprite;
	public Sprite raySprite;
	public Sprite rodSprite;


	GameObject gameManagerObject;
	GameManager gameManagerScript;

	GameObject textInterfaceObject;
	ChatHandler chatHandlerScript;

	GameObject textboxObject;
	GameObject chatTextObject;


	GameState currentState;

	// Use this for initialization
	void Awake () {
		gameManagerObject = GameObject.Find ("GameManager");
		textInterfaceObject = GameObject.Find ("TextInterface");

		gameManagerScript = gameManagerObject.GetComponent<GameManager> ();
		chatHandlerScript = textInterfaceObject.GetComponent<ChatHandler> ();

		chatTextObject = GameObject.Find ("ChatText");
		textboxObject = GameObject.Find ("TextBox");

		
	}
	
	// Update is called once per frame
	void Update () {
	
		currentState = gameManagerScript.currentState;


	}

	void OnGUI() {
		if (currentState == GameState.Dialogue) {

			textboxObject.transform.localScale = new Vector3(1,1,1);


			if (chatHandlerScript.GetCurrentLine ().Contains ("Ray:")) {
				textboxObject.GetComponent<Image> ().sprite = raySprite;
			} else if (chatHandlerScript.GetCurrentLine ().Contains ("Rod:")) {
				textboxObject.GetComponent<Image> ().sprite = rodSprite;
			} else {
			 	textboxObject.GetComponent<Image> ().sprite = blankSprite;
			}


			chatTextObject.GetComponent<Text> ().text = chatHandlerScript.GetCurrentLine ();
				

		
		} else if (currentState == GameState.Intro) {

			textboxObject.transform.localScale = new Vector3(0,0,0);
		}

	}
}
