using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cubePrefab;
	int numCubes = 16;
	private GameObject[] allCubes;
	//name of method is ProcessClickedCube
	//the argument or information that is accepted is GameObject clickedCube. 
	public void ProcessClickedCube (GameObject clickedCube){
		foreach (GameObject oneCube in allCubes) {
			oneCube.GetComponent<Renderer>().material.color = Color.white;
		}
		
		clickedCube.GetComponent<Renderer>().material.color = Color.red;
	}
	

	// Use this for initialization
	void Start () {
		allCubes = new GameObject[numCubes];

		//allCubes[i] = tells the game to assign the result of the Instantiate method 
		//to the element of the allCubes array. The “GameObject” command tells the game that 
		//Instantiate is creating GameObjects.
		for (int i = 0; i < numCubes; i++) {
			allCubes[i] = (GameObject) Instantiate(cubePrefab, new Vector3(i*2-15, 0, 12), Quaternion.identity);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
