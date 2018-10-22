using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skullMovement : MonoBehaviour {

	// Use this for initialization
	public Animator skullAnim;
	public Image blackOut;
	public AudioSource aa;
	public AudioSource ring;
	public AudioSource ambience;
	public Image phone;
	public bool ringPhone;
	public Text displayText;
	public string textString;
	void Start () {
	}
	void Awake()
	{
		blackOut.gameObject.SetActive (false);
		phone.gameObject.SetActive (false);
		StartCoroutine ("animateSkull");

	}
	// Update is called once per frame
	void Update () {
		StartCoroutine ("jostleSkull");
		//string userName = System.Security.Principal.WindowsIdentity.GetCurrent ().Name;
		if (ringPhone = true) {
			if (Input.GetKeyDown (KeyCode.X)) {
				playPhone ();
				ringPhone = false;
			}

		}
	}
	void playPhone()
	{
		string textString;
		Debug.Log ("got Here");
		phone.gameObject.transform.localScale = new Vector3 (2,2,0);
		string userName = System.Environment.UserName;
		Debug.Log (userName);
		textString = "Don't think you can walk away now, " + userName;
		displayText.text = "";
		Debug.Log ("??");
		StartCoroutine ("PlayText");


	}
	IEnumerator jostleSkull()
	{
		this.gameObject.transform.position = new Vector3 (0, -2, 0);
		yield return new WaitForSeconds (.05f);
		this.gameObject.transform.position = new Vector3 (.1f, -1.9f, 0);
		yield return new WaitForSeconds (.05f);
		this.gameObject.transform.position = new Vector3 (0, -2, 0);
		yield return new WaitForSeconds (.05f);
		this.gameObject.transform.position = new Vector3 (-.1f, -2.1f, 0);
	}
	IEnumerator animateSkull()
	{
		yield return new WaitForSeconds (5f);
		skullAnim.SetInteger ("skullLevel", 1);
		yield return new WaitForSeconds (10f);
		skullAnim.SetInteger ("skullLevel", 2);
		yield return new WaitForSeconds (12f);
		//aa.Stop;
		blackOut.gameObject.SetActive (true);
		ringPhone = true;
		ring.Play ();
		phone.gameObject.SetActive (true);
		phone.gameObject.transform.localScale = new Vector3 (1,1,0);
	}
	IEnumerator PlayText()
	{
		ring.Stop ();
		string userName = System.Environment.UserName;
		Debug.Log (userName);
		textString = "Don't think you can walk away now, " + userName;
		//interactSound.Play ();
		foreach (char c in textString) {
			displayText.text += c;
			yield return new WaitForSeconds (0.055f);
		}
		yield return new WaitForSeconds (2f);
		Debug.Log ("Done.");
		Application.Quit();
	}
}
