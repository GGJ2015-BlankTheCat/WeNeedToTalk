using UnityEngine;
using System.Collections;

public class Faded : MonoBehaviour {

	public bool fade;
	public SpriteRenderer whatever;
	public float fadeVal;
	public float target;

	// Use this for initialization
	void Awake () {
		fade = false;
		whatever = GameObject.Find ("TitleScreen").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (fade) {
			fadeVal = Mathf.Lerp (fadeVal, target, Time.deltaTime);
			whatever.color = new Color (whatever.color.r, whatever.color.g, whatever.color.b, fadeVal);
		} else {
			//Debug.Log ("Oh No.....");
		}
		if (fadeVal == target) 
		{
			fade = false;
		}
	}

	public void Fade() {
		fade = true;
	}
}
