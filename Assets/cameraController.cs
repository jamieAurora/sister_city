using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cameraController : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public string roomCode2;
	public Camera thisCam;
	void Start () {
		
	}
	void Awake()
	{
		
	}
	// Update is called once per frame
	void Update () {
		roomCode2 = player.GetComponent<playerDeath> ().roomCode;
		//Debug.Log ("Room Code");
		if (roomCode2 == "r1-2") {
			transform.parent = null;
			this.transform.position = player.GetComponent<playerDeath> ().camPos;
		}
		if (roomCode2 == "r2-1") {
			//transform.parent = player.transform;
			//this.transform.localScale = new Vector3 (4,3,1);
			//this.transform.position = player.transform.position;
			//Debug.Log ("transform: " + player.transform.position);
		}
		if (roomCode2 == "r2-3")
		{
			this.transform.position = player.GetComponent<playerDeath>().camPos;
		}
		if (roomCode2 == "r3-2")
		{
			this.transform.position = player.GetComponent<playerDeath>().camPos;
		}
		if (roomCode2 == "r3-4") {
			//this.transform.position = player.GetComponent<playerDeath> ().camPos;
		}
		if (roomCode2 == "r4-5") {
			this.transform.position = player.GetComponent<playerDeath>().camPos;
			thisCam.orthographicSize = 4;
		}
	}

}
