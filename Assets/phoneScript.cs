using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class phoneScript : MonoBehaviour {

	// Use this for initialization
	public Text displayText;
	public Text nameText;
	public Text displayText2;
	public Image phoneImg;
	public Image roxyPortrait;
	public Sprite roxyBlink;
	public Sprite roxyStare;
	public string textString;
	int place = 0;
	public bool areWeTouchingPlayer;
	public Image dialogueBox;
	public AudioSource ringading;
	public bool isTalking;
	void Start () {

	}
	void Awake()
	{
		dialogueBox.transform.localScale = new Vector3 (0, 0, 0);
		roxyPortrait.transform.localScale = new Vector3 (0, 0, 0);
		phoneImg.transform.localScale = new Vector3 (0, 0, 0);
	}
	// Update is called once per frame
	void Update () {
		//Input.GetKeyDown (KeyCode.X)
		if (areWeTouchingPlayer == true) {
			if (isTalking == false) {
				if (Input.GetKeyDown (KeyCode.X)) {
					LoadNewLine ();
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			
			Debug.Log ("We are touching the player.");
			ringading.Play ();
			areWeTouchingPlayer = true;
			GameObject player = GameObject.Find ("player");
			player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
			phoneImg.transform.localScale = new Vector3 (.6f, .6f, .6f);
			//displayText.color = Color.red;
			//displayText.fontSize = 300;
			//displayText.transform.position = new Vector3 (11, 33, 0);
			//displayText.transform.localPosition = new Vector3 (11, 33, 0);
			//displayText.text = "   !";
		} 
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			if (coll.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static) {
				Debug.Log ("Static.");
			}
			if (coll.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic) {
				Debug.Log ("Dynamic.");
				areWeTouchingPlayer = false;

			}
		}
	}
	void LoadNewLine()
	{
		place++;
		if (place == 1) {
			ringading.Stop ();
			displayText.color = Color.black;
			displayText.fontSize = 48;
			phoneImg.transform.localScale = new Vector3 (2.5f, 2.5f, 2.5f);
			textString = "johnny";
			displayText.text = "";
			isTalking = true;

			StartCoroutine ("PlayText");
		}
		if (place == 2) {
			textString = "";
			displayText.text = "";
			displayText2.text = "";
			textString = "i still think ur making a big mistake";
			displayText.text = "";
			isTalking = true;

			StartCoroutine ("PlayText");

		}
		if (place == 3) {
			textString = "";
			displayText.text = "";
			textString = "ur not gonna be any happier outside the city";
			displayText.text = "";
			isTalking = true;

			StartCoroutine ("PlayText");

		}
		if (place == 4) {
			textString = "";
			displayText.text = "";
			textString = "but u made up ur mind";
			displayText.text = "";
			isTalking = true;

			StartCoroutine ("PlayText");

		}
		if (place == 5) {
			textString = "pls don't leave without saying goodbye";
			displayText.text = "";
			isTalking = true;

			StartCoroutine ("PlayText");

		}
		if (place == 6) {
			textString = "i love you";
			displayText.text = "";
			isTalking = true;

			StartCoroutine ("PlayText");

		}
		if (place == 7) {
			dialogueBox.transform.localScale = new Vector3 (1, 1, 1);
			roxyPortrait.transform.localScale = new Vector3 (5, 5, 1);
			nameText.text = "Roxy";
			phoneImg.transform.localScale = new Vector3 (0, 0, 0);
			//roxyPortrait.sprite;
			roxyPortrait.sprite = roxyBlink;
			textString = "...";
			displayText.text = "";
			displayText2.text = "";
			isTalking = true;

			StartCoroutine ("PlayText2");
		}
		if (place == 8) {
			roxyPortrait.sprite = roxyStare;
			Debug.Log ("got here");
			textString = "(Fat chance...)";
			displayText.text = "";
			displayText2.text = "";
			isTalking = true;

			StartCoroutine ("PlayText2");


		}
		if (place == 9) {
			dialogueBox.transform.localScale = new Vector3 (0, 0, 0);
			phoneImg.transform.localScale = new Vector3 (0, 0, 0);
			textString = "";
			displayText.text = "";
			displayText2.text = "";
			nameText.text = "";
			roxyPortrait.transform.localScale = new Vector3 (0, 0, 0);
			StartCoroutine ("PlayText2");
			place = 0;
			areWeTouchingPlayer = false;
			GameObject player = GameObject.Find ("player");
			player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
			this.gameObject.SetActive (false);
		}
	}
	IEnumerator PlayText()
	{
		foreach (char c in textString) {
			displayText.text += c;
			yield return new WaitForSeconds (0.025f);
		}
		Debug.Log ("Finished playtext?");
		isTalking = false;
	}
	IEnumerator PlayText2()
	{
		foreach (char c in textString) {
			displayText2.text += c;
			yield return new WaitForSeconds (0.025f);
		}
		isTalking = false;
	}
}

