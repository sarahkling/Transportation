using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	

	float timeToAct;
	float turnLength = 1.5f;
	public int score = 0;
	public Airplane airplane;
	public GameObject cubePrefab;
	int gridWidth = 16;
	int gridHeight = 9;
	int depotX = 15;
	int depotY = 0;
	int airplaneStartX = 0;
	int airplaneStartY = 8;
	private GameObject[,] allCubes;


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
	}


	// Use this for initialization
	void Start () {
	
	timeToAct = turnLength;

	airplane = new Airplane();
	airplane.targetX = airplaneStartX;
	airplane.targetY = airplaneStartY;
	allCubes = new GameObject[gridWidth, gridHeight];
			
	for (int x = 0; x < gridWidth; x++) {
		for (int y = 0; y < gridHeight; y++) {
			allCubes[x,y] = (GameObject) Instantiate(cubePrefab, new Vector3(x*2 - 14, y*2 - 8, 10), Quaternion.identity);
			allCubes[x,y].GetComponent<CubeBehavior>().x = x;
			allCubes[x,y].GetComponent<CubeBehavior>().y = y;
		}
	}

	airplane.x = airplaneStartX;
	airplane.y = airplaneStartY;
	allCubes[airplaneStartX,airplaneStartY].GetComponent<Renderer>().material.color = Color.red;
	allCubes[depotX,depotY].GetComponent<Renderer>().material.color = Color.black;

		

	}

	void MoveAirplane() {
		int nextX = airplane.x;
		int nextY = airplane.y;
		if (airplane.targetX > airplane.x) {
			nextX++;
		}
		else if (airplane.targetX < airplane.x) {
				nextX--;
		}
		if (airplane.targetY > airplane.y) {
			nextY++;
		}
		else if (airplane.targetY < airplane.y) {
			nextY--;
		}
		// Set the old cube to black if it's the depot
		if (airplane.x == depotX && airplane.y == depotY) {
			allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.black;
		}
		// otherwise, set the old cube to white
		else {
			allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
		}
		// Set the new cube to yellow if the airplane is still active
		if (airplane.active) {
			allCubes[nextX, nextY].GetComponent<Renderer>().material.color = Color.yellow;
		}
		// otherwise the airplane is deactive and red
		else {
			allCubes[nextX, nextY].GetComponent<Renderer>().material.color = Color.red;
		}
		// Update the airplane to be in the new location
		airplane.x = nextX;
		airplane.y = nextY;

	}


	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeToAct) {
			MoveAirplane();
			timeToAct += turnLength;
			if (airplane.x == airplaneStartX && airplane.y == airplaneStartY) {
				airplane.cargo = Mathf.Min(airplane.cargo + 10, airplane.capacity);
			}
			if (airplane.x == depotX && airplane.y == depotY) {
				score += airplane.cargo;
				airplane.cargo = 0;
				airplane.cargo = 0;
			}
		}
	}
}
