using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class openerChangeText : MonoBehaviour {

	// Use this for initialization
	public Text thisText;
	public Text text2;
	void Start () {
		
	}
	void Awake () {
		thisText.text = "";
		text2.text = "";
		thisText.fontSize = 48;
		StartCoroutine ("waitTime");
		StartCoroutine ("waitTime2");
	}
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator waitTime2()
	{
		text2.text = "a game by Jamie Geist (@variasuit)";
		yield return new WaitForSeconds (3f);
		text2.text = "roxy sprite animations by Morgan Rose (@morkitten)";
		yield return new WaitForSeconds (3f);
		text2.text = "death sound by 2 Mello (@mellomakes)";
		yield return new WaitForSeconds (3f);
		text2.text = "WASD to move.";
		yield return new WaitForSeconds (3f);
		text2.text = "Z to jump";
		yield return new WaitForSeconds (3f);
		text2.text = "X to inspect";
		yield return new WaitForSeconds (3f);
		text2.text = "";
	}
	IEnumerator waitTime()
	{
		yield return new WaitForSeconds (18f);
		thisText.text = "This game deals heavily with topics of trauma and abuse.";
		yield return new WaitForSeconds (4f);
		thisText.text = "Disturbing depictions of graphic content can be expected in the full game. This demo also features some flashing objects.";
		yield return new WaitForSeconds (4f);
		thisText.text = "Please keep this in mind while playing.";
		yield return new WaitForSeconds (6f);
		thisText.text = "";
		yield return new WaitForSeconds (4f);
		SceneManager.LoadScene ("level1");
	}
}
