﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	float timeToAct = 0f;
	float turnLength = 1.5f;
	public int score = 0;
	public int targetX, targetY;
	public Airplane airplane;
	public GameObject cubePrefab;
	private GameObject[,] allCubes;
	int gridWidth = 16;
	int gridHeight = 9;
	int depotX = 15;
	int depotY = 0;

	 
	public void ProcessClickedCube (GameObject clickedCube, int x, int y){
		// If the player clicks an inactive airplane, it should highlight
		if (x == airplane.x && y == airplane.y && airplane.active == false) {
			airplane.active = true;
			clickedCube.GetComponent<Renderer> ().material.color = Color.yellow;
		} 
		// If the player clicks an active airplane, it should unhighlight
		else if (x == airplane.x && y == airplane.y && airplane.active == true) {
			airplane.active = false;
			clickedCube.GetComponent<Renderer> ().material.color = Color.red;
		}
		else if (airplane.active && (x != airplane.x || y != airplane.y)) {
			airplane.targetX = x;
			airplane.targetY = y;
		}
			allCubes[x, y].GetComponent<Renderer>().material.color = Color.yellow;
			airplane.x = x;
			airplane.y = y;
	}
}
	public void ProcessArrow () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//move up in y direction
			airplane.SetMoveDirection(0,1);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			//move down in y direction
			airplane.SetMoveDirection(0,-1);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			//move right in x direction
			airplane.SetMoveDirection(1,0);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			//move left in x direction
			airplane.SetMoveDirection(-1,0);
		}
	}


	public void MoveAirplane () {
		airplane.active = true; 
		allCubes [airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
		airplane.Move ();
		allCubes [airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.yellow;
	}


	// Use this for initialization
	void Start () {


		airplane = new Airplane ();
		allCubes = new GameObject[gridWidth, gridHeight];

		//allCubes[x or y] = tells the game to assign the result of the Instantiate method 
		//to the element of the allCubes array. The “GameObject” command tells the game that 
		//Instantiate is creating GameObjects.
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {
				allCubes [x, y] = (GameObject)Instantiate (cubePrefab, new Vector3 (x * 2 - 15, y*2, 10), Quaternion.identity);
				allCubes[x,y].GetComponent<CubeBehaviour>().x = x;
				allCubes[x,y].GetComponent<CubeBehaviour>().y = y;
			}
		}
	
		airplane.x = 0;
		airplane.y = 8;
		allCubes[0,8].GetComponent<Renderer>().material.color = Color.red;
		allCubes[depotX, depotY].GetComponent<Renderer>().material.color = Color.black;
		timeToAct += turnLength;

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeToAct) {
			//Move airplane
			MoveAirplane();
			//check if the airplane is in it's start location
			if (airplane.x == 0 && airplane.y == 8) {
				//if it is, add 10 carge if it isn't full
				airplane.cargo += 10;
				//airplane.cargo = Mathf.Min(airplane.cargo, airplane.capacity);
				if (airplane.cargo > airplane.capacity) {
					airplane.cargo = airplane.capacity;
				}
			}
			if (airplane.x == 15 && airplane.y == 0) {
				//deliver the cargo and score points
				score += airplane.cargo;
				airplane.cargo = 0;
			}
			timeToAct += turnLength;
			print ("Airplane Cargo: " +airplane.cargo +" Score: " +score);
		}
		ProcessArrow();
	
	}
}
