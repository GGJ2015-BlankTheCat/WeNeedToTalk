using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class TweeParser : MonoBehaviour {



	public TextAsset tweeSourceAsset;
	public string tweeSource;

	public Dictionary<string, tweeEntry> entries; 


	// Use this for initialization
	void Awake () {

		entries = new Dictionary<string, tweeEntry>();
		tweeSource = tweeSourceAsset.text;

		Parse ();

	}


	void Parse(){



		string[] rawEntries = tweeSource.Split (new string[]{"::"}, System.StringSplitOptions.RemoveEmptyEntries); 

		foreach (string currentRawEntry in rawEntries) {
				

			tweeEntry currentEntry = new tweeEntry();

			int firstLineIndex = currentRawEntry.IndexOf("\n");

			string firstLine = currentRawEntry.Substring(0, firstLineIndex);

			if(firstLine.Contains("[")){
				int tagPosition = firstLine.IndexOf("[");
				string rawTags = firstLine.Substring(tagPosition).Trim(new char[]{'[',']'});
				currentEntry.tags = rawTags.Split(new string[]{" "}, System.StringSplitOptions.RemoveEmptyEntries);
				currentEntry.title = firstLine.Substring(0, tagPosition-1).Trim ();
			}else{
				currentEntry.tags = null;
				currentEntry.title = firstLine.Trim ();
			}
				

			string body = currentRawEntry.Substring(firstLineIndex);
			Debug.Log (body);
			Debug.Log ("BREAK------------");
			string[] bodyArray = body.Split(new string[]{"\n"}, System.StringSplitOptions.RemoveEmptyEntries);

			currentEntry.body = new string[bodyArray.Length];

			bodyArray.CopyTo(currentEntry.body, 0);
			for(int i = 0; i < bodyArray.Length; i++) {
				Debug.Log (bodyArray[i]);
			}

			entries.Add(currentEntry.title, currentEntry);

		}


	}

}

[System.Serializable]
public class tweeEntry{
	public string title;
	public string[] tags;
	public string[] body;
	
}
