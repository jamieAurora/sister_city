using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterController : MonoBehaviour {

	// Use this for initialization
	public float maxSpeed;
	public float jumpForce;
	public bool facingRight = true;
	public bool grounded;
	public bool running;
	public Animator anim;
	float groundRadius = .8f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public LayerMask whatIsStickyWall;
	//public static bool Exists("D:\Steam_Games\steamapps\common\swkotor");
	void Start () {
		maxSpeed = 7.5f;
		jumpForce = 750f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (grounded && Input.GetKeyDown (KeyCode.Z)) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
			//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, (2500 * Time.deltaTime)));
		}
		if (grounded == false) {
			anim.SetBool ("jumping", true);
		}
		if (grounded == true) {
			anim.SetBool ("jumping", false);
		}
		float move = Input.GetAxis ("Horizontal");
		//anim.SetFloat ("speed", GetComponent<Rigidbody2D>().velocity.	);
	}
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		float move = Input.GetAxis ("Horizontal");
		string roomCode;
		roomCode = this.GetComponent<playerDeath> ().roomCode;
		if (roomCode == "r4-5")
		{
			maxSpeed = 3f;
			jumpForce = 0;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
		else
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);

		}
		//Debug.Log ("Move:" + move);

		if (move > 0 && facingRight) {
			Flip ();
			//anim.SetFloat ("speed", Mathf.Abs (move));
		} 
		if (move > 0 && !facingRight) {
			Flip ();
			//anim.SetFloat ("speed", Mathf.Abs (move));

		}
		else if (move < 0 && facingRight) {
			Flip ();
			anim.SetFloat ("speed", 0);
		}
		if (move == 0) {
			if (roomCode == "r4-5") {
				anim.SetBool ("walking", false);
			} 
			else {
			}
			anim.SetBool ("running", false);
		} 
		else {
			if (roomCode == "r4-5") {
				anim.SetBool ("walking", true);
			} 
			else {
				anim.SetBool ("running", true);

			}
		}
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void psychoMantis()
	{
		if (System.IO.Directory.Exists ("D:\\Steam Games\\steamapps\\common\\swkotor")) {
			//Debug.Log ("Kotor found.");
			//Change this to C:\\ or wherever the default steam directory is
			//The default is C:\\Program Files\\Steam\\steamapps\\common\\gamefoldername
		} 
		else {
			//Debug.Log ("Kotor not found");
		}
	}
}
