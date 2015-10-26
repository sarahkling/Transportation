using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	int xmax = 16;
	int ymax = 9;
	int[,] sky = new int[16, 9];
	
	public GameObject cubePrefab;

	// Use this for initialization
	void Start () {

	for(int xaxis = 0; xaxis < xmax; xaxis++) {
		for(int yaxis = 0; yaxis < ymax; yaxis++) {
			sky[xaxis,yaxis] = (GameObject) Instantiate(cubePrefab, new Vector3(xaxis*2-15, yaxis, 12), Quaternion.identity);
		}
	}




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
