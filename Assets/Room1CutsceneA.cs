using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Room1CutsceneA : MonoBehaviour {
	// Use this for initialization
	public Text displayText;
	public Text nameText;
	public string textString;
	int place = 0;
	public bool areWeTouchingPlayerr;
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		//Input.GetKeyDown (KeyCode.X)
		if (areWeTouchingPlayerr == true) {
			if (Input.GetKeyDown(KeyCode.X))
			{
				LoadNewLine ();
			}
		}

	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("We are touching the player.");
			areWeTouchingPlayerr = true;
			if (Input.GetKeyDown(KeyCode.X))
			{
				LoadNewLine ();
			}
		} 
		else {
			//areWeTouchingPlayerr = false;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			areWeTouchingPlayerr = false;
		}
	}
	void LoadNewLine()
	{
		place++;
		if (place == 1) {
			textString = "I111111.";
			displayText.text = "";
			StartCoroutine ("PlayText");
		}
		if (place == 2) {
			textString = "T22222u.";
			displayText.text = "";
			StartCoroutine ("PlayText");
		}
		if (place == 3) {
			textString = "B3333.";
			displayText.text = "";
			StartCoroutine ("PlayText");
		}
		if (place == 4) {
			textString = "";
			displayText.text = "";
			StartCoroutine ("PlayText");
			place = 0;
			areWeTouchingPlayerr = false;
		}
	}
	IEnumerator PlayText()
	{
		foreach (char c in textString) {
			displayText.text += c;
			yield return new WaitForSeconds (0.055f);
		}
	}
}
