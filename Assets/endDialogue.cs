using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class endDialogue : MonoBehaviour {

	// Use this for initialization
	public Text displayText;
	public string textString;
	public float delayTime;
	void Awake()
	{
		StartCoroutine ("delay");
	}
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator PlayText()
	{
		foreach (char c in textString) {
			displayText.text += c;
			yield return new WaitForSeconds (0.055f);
		}
	}
	IEnumerator delay()
	{
		yield return new WaitForSeconds (delayTime);
		textString = textString;
		displayText.text = "";
		StartCoroutine ("PlayText");
	}
}
