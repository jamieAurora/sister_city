using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {

	public Text displayText;
	public Text nameText;
	public string textString;
	public int place = 0;
	public int instanceID;
	public bool areWeTouchingPlayer;
	public AudioSource interactSound;
	public Image dialogueBox;
	public GameObject collider;
	public GameObject collider2;
	public Image blackOutImg;
	public Image textBackground;
	public AudioSource unlockSound;

	// Use this for initialization
	void Start () {
		//collider2 = collider.GetComponent<BoxCollider2D> ();
		collider.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (areWeTouchingPlayer == true) {
			if (Input.GetKeyDown(KeyCode.X))
			{
				LoadNewLine ();
			}
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		blackOutImg.gameObject.SetActive (true);
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
			unlockSound.Play ();
			textString = "You unlocked the door.";
			displayText.text = "";
			StartCoroutine ("PlayText");
		}
		if (place == 2) {
			Debug.Log ("got here");
			StartCoroutine ("blackOut");

			textString = "";
			displayText.text = "";
			StartCoroutine ("PlayText");
			place = 0;
			areWeTouchingPlayer = false;

			//Room 4-5


		}
	}
	IEnumerator PlayText()
	{
		//interactSound.Play ();
		foreach (char c in textString) {
			displayText.text += c;
			yield return new WaitForSeconds (0.025f);
		}
		blackOutImg.gameObject.SetActive (false);

	}
	IEnumerator blackOut()
	{
		interactSound.Play ();
		blackOutImg.CrossFadeAlpha (1, 0.5f, true);
		yield return new WaitForSeconds (2f);
		collider.gameObject.SetActive(true);
		StartCoroutine ("fadeIn");
		//blackOutImg.CrossFadeAlpha (0, 0.5f, true);
	}
	IEnumerator fadeIn()
	{
		blackOutImg.CrossFadeAlpha (0, 0.5f, true);
		yield return new WaitForSeconds (1f);

	}
}
