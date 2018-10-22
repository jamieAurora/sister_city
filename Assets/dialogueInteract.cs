using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dialogueInteract : MonoBehaviour {

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
			if (isTalking == false) {
				if (Input.GetKeyDown (KeyCode.X)) {
				
					//player.GetComponent<Rigidbody2D> ().freezeRotation;
					LoadNewLine ();
				}
			}
		} 
		else {
			//GameObject player = GameObject.Find ("player");
			//player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
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
		dialogueBox.transform.localScale = new Vector3 (1, 1, 1);

		place++;
		if (place == 1) {
			GameObject player = GameObject.Find ("player");
			player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
			if (instanceID == 1) {
				textString = "It's a corpse.";

			}
			if (instanceID == 2) {
				textString = "It's free real estate.";
			}
			if (instanceID == 3) {
				textString = "It's a cardboard box.";
			}
			if (instanceID == 4) {
				textString = "It's a cardboard box.";
			}
			if (instanceID == 5) {
				textString = "It's a cardboard box.";
			}
			if (instanceID == 6) {
				textString = "There's no reason to leave my room right now.";
			}
			if (instanceID == 7) {
				textString = "It's a glass of water.";
			}
			if (instanceID == 8) {
				textString = "This bed is surprisingly comfortable.";
			}
			if (instanceID == 9) {
				textString = "Old pizza.";
			}
			if (instanceID == 10) {
				textString = "I can see the city from my window.";
			}
			displayText.text = "";
			isTalking = true;
			StartCoroutine ("PlayText");
		}
		if (place == 2) {
			if (instanceID == 1) {
				textString = "It's a corpse.";

			}
			if (instanceID == 2) {
				textString = "It's free real estate.";
			}
			if (instanceID == 3) {
				textString = "It's heavy, so there's still something inside.";
			}
			if (instanceID == 4) {
				textString = "My belongings are packed tightly inside.";
			}
			if (instanceID == 5) {
				textString = "I don't know what else I was expecting.";
			}
			if (instanceID == 6) {
				textString = "I don't want to run into my mom right now.";
			}
			if (instanceID == 7) {
				textString = "I should drink it, but there's a thin layer of dust on the top.";
			}
			if (instanceID == 8) {
				textString = "I kind of want to go to sleep now.";
			}
			if (instanceID == 9) {
				textString = "Pepperoni.";
			}
			if (instanceID == 10) {
				textString = "It's always night here.";
			}
			displayText.text = "";
			isTalking = true;
			StartCoroutine ("PlayText");
		}
		if (place == 3) {
			if (instanceID == 1) {
				textString = "It's a corpse.";

			}
			if (instanceID == 2) {
				textString = "It's free real estate.";
			}
			if (instanceID == 3) {
				textString = "It should be able to support my weight...";
			}
			if (instanceID == 4) {
				textString = "The sooner I leave, the better.";
			}
			if (instanceID == 5) {
				textString = "I hate this place.";
			}
			if (instanceID == 6) {
				textString = "That's the entire reason I took the back entrance.";
			}if (instanceID == 7) {
				textString = "I'll get a new glass later.";
			}
			if (instanceID == 8) {
				textString = "It'd be nice to just sleep forever.";
			}
			if (instanceID == 9) {
				textString = "I'm hungry, but I don't feel like eating.";
			}
			if (instanceID == 10) {
				textString = "Always.";
			}

			displayText.text = "";
			isTalking = true;
			StartCoroutine ("PlayText");

		}
		if (place == 4) {
			GameObject player = GameObject.Find ("player");
			player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
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
		interactSound.Play ();
		foreach (char c in textString) {
			displayText.text += c;
			yield return new WaitForSeconds (0.025f);
		}
		isTalking = false;
	}
}
