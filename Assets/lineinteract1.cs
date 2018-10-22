using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lineinteract1 : MonoBehaviour {

	// Use this for initialization
	public Text displayText;
	public Text nameText;
	public string textString;
	int place = 0;
	public int instanceID;
	public bool areWeTouchingPlayer;
	public AudioSource interactSound;
	public Image dialogueBox;
	public bool isTalking;
	void Start () {
		dialogueBox.transform.localScale = new Vector3 (0, 0, 0);

	}

	// Update is called once per frame
	void Update () {
		//Input.GetKeyDown (KeyCode.X)
		if (areWeTouchingPlayer == true) {
			if (isTalking == false){
			if (Input.GetKeyDown(KeyCode.X))
			{
				LoadNewLine ();
			}
			}
		}

	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("We are touching the player.");
			areWeTouchingPlayer = true;
		} 
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			areWeTouchingPlayer = false;
		}
	}
	void LoadNewLine()
	{
		place++;
		if (place == 1) {
			dialogueBox.transform.localScale = new Vector3 (1, 1, 1);

			interactSound.Play ();
			if (place == 1) {
				textString = "The back entrance has been left open, as per usual.";
			}
			if (place == 2) {
				textString = "A door to some sort of supply closet. It's locked.";
			} 
			else {
				textString = "This door is locked.";
			}
			isTalking = true;
			displayText.text = "";
			StartCoroutine ("PlayText");
		}
		if (place == 2) {
			dialogueBox.transform.localScale = new Vector3 (0, 0, 0);

			textString = "";
			displayText.text = "";
			StartCoroutine ("PlayText");
			place = 0;
			areWeTouchingPlayer = false;
		}
	}
	IEnumerator PlayText()
	{
		//interactSound.Play ();
		foreach (char c in textString) {
			displayText.text += c;
			yield return new WaitForSeconds (0.025f);
		}
		isTalking = false;
	}
}
