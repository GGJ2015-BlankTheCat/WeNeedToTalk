using UnityEngine;
using System.Collections;

public class notePadController : MonoBehaviour {

	string prompt;
	string[] choices;

	int selected;


	// Use this for initialization
	void Awake () {
		return;
	}
	
	// Update is called once per frame
	void Update () {
		return;
	}

	public void SetPrompt(string line) {
		prompt = line;
	}

	public void SetOptions(string[] lines) {
		choices = lines;
	}

	public string GetSelected() {
		return choices [selected];
	}

	public void MoveUp() {
		if (selected == 0) {
			selected = choices.Length--;
		} else {
			selected--;
		}
	}

	public void MoveDown() {
		if (selected == choices.Length--) {
			selected = 0;
		} else {
			selected++;
		}
	}

}
