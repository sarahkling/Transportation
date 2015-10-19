﻿using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour {

	//this references the gamecontroller script on the gamecontroller object
	GameController aGameController;

	//"this" means this script 
	//"gameobject" means the object the script is attatched to 
	void OnMouseDown () {
		aGameController.ProcessClickedCube(this.gameObject);
	}






	// Use this for initialization
	void Start () {

		//the first part finds the object in the scene called “GameControllerObject.” 
		//The second part gets the specific script that’s on it, "GameController" script. 
		aGameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}