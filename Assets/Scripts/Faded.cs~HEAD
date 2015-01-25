using UnityEngine;
using System.Collections;

public class Faded : MonoBehaviour {

	public bool fade;
	public SpriteRenderer whatever;
	float fadeVal;

	// Use this for initialization
	void Awake () {
		fade = false;
		fadeVal = 1.0f;
		whatever = GameObject.Find ("TitleScreen").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (fade) {
			fadeVal = Mathf.Lerp(1f, 0f, Time.time/5);
			whatever.color = new Color(whatever.color.r, whatever.color.g, whatever.color.b, fadeVal);
			Debug.Log ("Color: " + whatever.color.r + " " +  whatever.color.g + " " + whatever.color.b + " " + whatever.color.a); 
		}
		if (fadeVal == 0) 
		{
			fade = false;
		}
	}

	public void Fade() {
		fade = true;
	}
}
