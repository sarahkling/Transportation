using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Airplane airplane;
	public GameObject cubePrefab;
	int gridWidth = 16;
	int gridHeight = 9;
	private GameObject[,] allCubes;
	//name of method is ProcessClickedCube
	//the argument or information that is accepted is GameObject clickedCube. 
	public void ProcessClickedCube (GameObject clickedCube, int x, int y){
		// If the player clicks an inactive airplane, it should highlight
		if (x == airplane.x && y == airplane.y && airplane.active == false) {
			airplane.active = true;
			clickedCube.GetComponent<Renderer> ().material.color = Color.green;
		} 
		// If the player clicks an active airplane, it should unhighlight
		else if (x == airplane.x && y == airplane.y && airplane.active == true) {
			airplane.active = false;
			clickedCube.GetComponent<Renderer> ().material.color = Color.red;
		}
		// If the player clicks the sky and there isn’t an active airplane, nothing happens
		// If the player clicks the sky and there is an active airplane, the airplane teleports there
		else if (airplane.active && (x != airplane.x || y != airplane.y)) {
			allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
			allCubes[x, y].GetComponent<Renderer>().material.color = Color.green;
			airplane.x = x;
			airplane.y = y;
		}

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



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
