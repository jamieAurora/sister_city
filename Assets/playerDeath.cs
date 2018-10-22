using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerDeath : MonoBehaviour {

	// Use this for initialization
	public bool areWeHit;
	public bool didWeMove;
	public string roomCode;
	public Vector3 camPos;
	public Vector3 roomPos;
	public AudioSource deathSound;
	public AudioSource doorSound;
	public Image blackOutImg;
	public bool dying;
	public Animator anim;
	void Start () {
		areWeHit = false;
		didWeMove = false;
		blackOutImg.CrossFadeAlpha (0, .000001f, true);

	}

	IEnumerator RespawnAnim()
	{	this.gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		dying = true;
		deathSound.Play ();
		anim.SetBool ("death", true);
		yield return new WaitForSeconds (1f);
		anim.SetBool ("death", false);
		dying = false;
		this.transform.position = roomPos;
		this.gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

	}
	// Update is called once per frame
	void Update () {
		//Debug.Log ("runnin");
		//Check for collision with object.
		//if (areWeHit == true) {
	///		Debug.Log ("hit");
		//}
		if (dying == true) {
			//this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		} 
		else {
		}
		if (areWeHit == true) {
			//this.gameObject.GetComponent<Rigidbody2D>()
			areWeHit = false;
			Respawn ();
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		//Debug.Log ("a");
		//Debug.Log (coll);
		if (coll.gameObject.tag == "Enemy") {
			//"Kill" Player
			Debug.Log("hit enemy");
			areWeHit = true;
		}
		if (coll.gameObject.tag == "NewRoom") {
			Debug.Log ("a");
			if (didWeMove == false) {
				didWeMove = false;
				GameObject audioHandler2 = GameObject.Find ("audioHandler");
				audiohandler aaaHandler = audioHandler2.GetComponent<audiohandler> ();
				Debug.Log ("New room!");
				roomCode = coll.gameObject.GetComponent<roomScript> ().roomCode;
				roomPos = coll.gameObject.GetComponent<roomScript> ().location;
				//This should TP us into the room.
				//Let's also change the camera.
				GameObject mainCamera = GameObject.Find("MainCamera");

				if (roomCode == "r1-2") {

					aaaHandler.generalAmbience.Stop ();
					Debug.Log ("Stopping audio");
				}
				if (roomCode == "r2-1") {
					
					aaaHandler.generalAmbience.Play ();
					Debug.Log ("back to first room");
					mainCamera.transform.parent = this.transform;
					mainCamera.transform.position = new Vector3 (7, 6f, -10f);
				}
				if (roomCode == "r3-4") {
					aaaHandler.generalAmbience.Play ();
					mainCamera.transform.parent = this.transform;
					mainCamera.transform.position = new Vector3 (27.162132f, 60.00894928f, -10f);
					//mainCamera.transform.position = new Vector3 (56, 21f, -10f);
				}
				if (roomCode == "r4-5") {

					aaaHandler.generalAmbience.Stop ();
				}
				else {
				}
				camPos = coll.gameObject.GetComponent<roomScript>().cameraPos;
				this.gameObject.transform.position = coll.gameObject.GetComponent<roomScript> ().location;

				//mainCamera.transform.position = coll.gameObject.GetComponent<roomScript>().cameraPos;
				//mainCamera.transform.parent = this.transform;
			}


			//this.gameObject.transform.position = coll.gameObject.transform.position;
		}
	}
	public void Respawn()
	{
		StartCoroutine (RespawnAnim ());
		//Check for Room ID.

	}

}
