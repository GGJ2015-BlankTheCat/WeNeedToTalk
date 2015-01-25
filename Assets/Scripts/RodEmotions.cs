using UnityEngine;
using System.Collections;

public class RodEmotions : MonoBehaviour {
	
	GameObject rodSpriteRenderer;
	SpriteRenderer rodSprite;
	
	public Sprite rodHappy;
	public Sprite rodSad;
	public Sprite rodAngry;
	public Sprite rodNeutral;
	
	// Use this for initialization
	void Awake () {
		GameObject.Find("RodSprite").GetComponent<SpriteRenderer>().sprite = rodNeutral;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetEmotion(Emotion emot) {
		switch (emot) {
		case Emotion.Angry:
			GameObject.Find ("RodSprite").GetComponent<SpriteRenderer> ().sprite = rodAngry;
			break;
		case Emotion.Happy:
			GameObject.Find ("RodSprite").GetComponent<SpriteRenderer> ().sprite = rodHappy;
			break;
		case Emotion.Neutral:
			GameObject.Find ("RodSprite").GetComponent<SpriteRenderer> ().sprite = rodNeutral;
			break;
		case Emotion.Sad:
			GameObject.Find ("RodSprite").GetComponent<SpriteRenderer> ().sprite = rodSad;
			break;
		}
	}
}