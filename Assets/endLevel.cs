using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour {

	// Use this for initialization
	public Text displayText;
	public Text nameText;
	public Image roxyPortrait;
	public GameObject bloodImg;
	public Sprite roxyBlink;
	public Sprite roxyStare;
	public string textString;
	int place = 0;
	public bool areWeTouchingPlayer;
	public Material dark;
	public Animator anim;
	public bool isBleed;
	public Image dialogueBox;
	public AudioSource ambience2;
	public AudioSource drown;
	public bool isTalking;

	void Start () {
		dialogueBox.transform.localScale = new Vector3 (0, 0, 0);

	}
	void Awake()
	{
		dark.SetColor ("_Color", Color.grey);

		roxyPortrait.transform.localScale = new Vector3 (0, 0, 0);
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
		if (isBleed == true) {
			bloodImg.transform.position = new Vector3 (bloodImg.transform.position.x, bloodImg.transform.position.y + Time.deltaTime, bloodImg.transform.position.z);
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
		dialogueBox.transform.localScale = new Vector3 (1, 1, 1);
		place++;
		if (place == 1) {
			ambience2.Play ();
			isBleed = false;
			textString = "You're not ready.";
			displayText.text = "";
			isTalking = true;
			StartCoroutine ("PlayText");

		}
		if (place == 2) {
			roxyPortrait.transform.localScale = new Vector3 (5, 5, 1);
			nameText.text = "Roxy";
			//roxyPortrait.sprite = roxyBlink;
			textString = "...";
			displayText.text = "";
			//dark.SetColor ("_Color", Color.black);
			isTalking = true;
			StartCoroutine ("PlayText");
		}
		if (place == 3) {
			roxyPortrait.transform.localScale = new Vector3 (0, 0, 0);
			nameText.text = "";
			textString = "Throwing everything away and starting fresh? You're not ready for it.";
			displayText.text = "";
			isTalking = true;
			StartCoroutine ("PlayText");

		}
		if (place == 4) {
			textString = "You've ran away before. This is just on a bigger scale.";
			displayText.text = "";
			isTalking = true;
			StartCoroutine ("PlayText");

		}
		//			anim.SetBool("isBleeding", true);

		if (place == 5) {
			roxyPortrait.transform.localScale = new Vector3 (5, 5, 1);
			nameText.text = "Roxy";
			//roxyPortrait.sprite = roxyBlink;
			textString = "...";
			displayText.text = "";
			isTalking = true;
			StartCoroutine ("PlayText");
		}
		if (place == 6) {
			roxyPortrait.transform.localScale = new Vector3 (0, 0, 0);
			nameText.text = "";
			textString = "There's no choice but to confront it all at once. The road ahead will destroy you if you don't do it yourself.";
			displayText.text = "";
			isTalking = true;
			StartCoroutine ("PlayText");

		}
		if (place == 7) {
			roxyPortrait.transform.localScale = new Vector3 (5, 5, 1);
			nameText.text = "Roxy";
			//roxyPortrait.sprite = roxyBlink;
			textString = "It's not like I have a choice.";
			displayText.text = "";
			//dark.SetColor ("_Color", Color.black);
			isTalking = true;
			StartCoroutine ("PlayText");
		}
		if (place == 8) {
			roxyPortrait.transform.localScale = new Vector3 (0, 0, 0);
			nameText.text = "";
			textString = "That's the spirit.";
			displayText.text = "";
			isTalking = true;
			StartCoroutine ("PlayText");
		}
		if (place == 9) {
			dialogueBox.transform.localScale = new Vector3 (0, 0, 0);

			displayText.text = "";
			textString = "";
			StartCoroutine ("Freaky");
			StartCoroutine ("BloodFill");

		}
	}

	IEnumerator PlayText()
	{
		foreach (char c in textString) {
			displayText.text += c;
			yield return new WaitForSeconds (0.025f);
		}
		isTalking = false;
	}
	IEnumerator BloodFill()
	{
		//Debug.Log ("bloodfill called");
		//bloodImg.transform.localScale = new Vector3 (bloodImg.transform.localScale.x * (1.1f) * Time.deltaTime, bloodImg.transform.localScale.y * (1.1f) * Time.deltaTime, 1);

		yield return new WaitForSeconds (3f);
		isBleed = true;

		//0.0001
	}
	IEnumerator Freaky()
	{
		//drown.Play ();
		//StartCoroutine ("BloodFill");
		anim.SetBool ("isBleeding", true);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.black);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.red);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.black);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.red);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.black);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.red);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.black);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.red);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.black);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.red);
		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.black);


		yield return new WaitForSeconds (.5f);
		dark.SetColor ("_Color", Color.red);

		yield return new WaitForSeconds (2f);
		//This should be how long before we cut to the end scene. Blood should fully cover room.

		yield return new WaitForSeconds (8f);
		SceneManager.LoadScene ("end");
	}
}
