using UnityEngine;
using System.Collections;

public class RayEmotions : MonoBehaviour {

	GameObject raySpriteRenderer;
	SpriteRenderer raySprite;

	public Sprite rayHappy;
	public Sprite raySad;
	public Sprite rayAngry;
	public Sprite rayNeutral;

	// Use this for initialization
	void Awake () {
		GameObject.Find("RaySprite").GetComponent<SpriteRenderer>().sprite = rayNeutral;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetEmotion(Emotion emot) {
		switch (emot) {
			case Emotion.Angry:
				GameObject.Find ("RaySprite").GetComponent<SpriteRenderer> ().sprite = rayAngry;
				break;
			case Emotion.Happy:
				GameObject.Find ("RaySprite").GetComponent<SpriteRenderer> ().sprite = rayHappy;
				break;
			case Emotion.Neutral:
				GameObject.Find ("RaySprite").GetComponent<SpriteRenderer> ().sprite = rayNeutral;
				break;
			case Emotion.Sad:
				GameObject.Find ("RaySprite").GetComponent<SpriteRenderer> ().sprite = raySad;
				break;
			}
		}
}