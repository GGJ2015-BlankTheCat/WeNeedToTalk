using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class notePadController : MonoBehaviour {

	string prompt;

	public int selected;

	GameObject gameManagerObject;
	GameManager gameManagerScript;
	
	GameObject textInterfaceObject;
//	ChatHandler chatHandlerScript;

	public GameObject notePadObject;

	GameObject pointerObject;
	RectTransform pointerTransform;


	Image notePadImage;

	GameState currentState;

	public Dictionary<string, string> Options;


	// Use this for initialization
	void Awake () {

		notePadImage = GetComponent<Image>();

		gameManagerObject = GameObject.Find ("GameManager");
		textInterfaceObject = GameObject.Find ("TextInterface");

		notePadObject = GameObject.Find ("NotePad");
		pointerObject = GameObject.Find ("pointer");

		pointerTransform = pointerObject.GetComponent<RectTransform>();

		gameManagerScript = gameManagerObject.GetComponent<GameManager> ();
		//chatHandlerScript = textInterfaceObject.GetComponent<ChatHandler> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		currentState = gameManagerScript.currentState;	
	}


	void OnGUI(){
		if (currentState == GameState.Choice || currentState == GameState.Intro) {
			string[] keys = new string[Options.Keys.Count];
			Options.Keys.CopyTo(keys, 0);

			/*foreach(Transform child in transform){
				
				child.gameObject.SetActive(true);
				
			}*/
			//notePadImage.enabled = true;
			notePadObject.transform.localScale= new Vector3(1,1,1);
			pointerTransform.localScale = new Vector3(1,1,1);


			if(keys.Length != 0){
				createOptions(keys);				
				renderPointer();

			}

			
		}

		if (currentState == GameState.Dialogue) {
			notePadObject.transform.localScale = new Vector3(0,0,0);
			pointerTransform.localScale = new Vector3(0,0,0);
		}

	}


	public void SetPrompt(string line) {
		prompt = line;
	}

	public void SetOptions(Dictionary<string,string> input) {
		Options = new Dictionary<string, string>(input);
		selected = 0;
	}

	public string GetSelected() {
		string[] keys = new string[Options.Keys.Count];
		Options.Keys.CopyTo(keys, 0);

		return  Options[keys[selected]];
	}

	public void MoveUp() {
		if (selected == 0) {
			selected = Options.Keys.Count - 1;
		} else {
			selected--;
		}
	}

	public void MoveDown() {
		if (selected == Options.Keys.Count - 1) {
			selected = 0;
		} else {
			selected++;
		}
	}

	public void createOptions(string[] options){

		int optionIndex = 1;

		foreach (string option in options) {

			GameObject.Find("TextOption" + optionIndex).GetComponent<Text>().text = option;

			optionIndex++;


		}


	}

	public void renderPointer(){



		float x = pointerTransform.anchoredPosition.x;
		float y = GameObject.Find ("TextOption" + (selected + 1)).GetComponent<RectTransform> ().anchoredPosition.y + pointerTransform.sizeDelta.y / 2;

		pointerTransform.anchoredPosition = new Vector2 (x, y);

	}




}
