using UnityEngine;
using System.Collections;

public class Airplane {
	public int x, y;
	public int cargo;
	public int capacity = 90;
	public bool active;
	public int targetX;
	public int targetY;


	// Use this for initialization
	void Start () {

		cargo = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
