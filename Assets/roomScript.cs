using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roomScript : MonoBehaviour {

	public string roomCode;
	public Vector3 location;
	public Vector3 cameraPos;
	// Use this for initialization
	void Start () {
		if (roomCode == "r1-2") {
			location = new Vector3 (11, 36, 0);
			cameraPos = new Vector3 (16.7f, 40.55f, -10f);
		}
		if (roomCode == "r2-1") {
			location = new Vector3 (7,3,0);
			cameraPos = new Vector3 (0,0,-10f);
		}
		if (roomCode == "r2-3") {
			location = new Vector3 (7.5f, 57, 0);
			cameraPos = new Vector3 (17.4f, 58f, -10f);
		}
		if (roomCode == "r3-2") {
			location = new Vector3 (25f, 39f, 0);
			cameraPos = new Vector3 (16.5f, 41f, -10f);
		}
		if (roomCode == "r3-4") {
			location = new Vector3 (56, 21f, 0);
			//cameraPos = new Vector3 (0, 0, -10f);
		}
		if (roomCode == "r4-5") {
			location = new Vector3 (67f,  -5.68f, 0);
			cameraPos = new Vector3 (71f, -4, -10f);

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
