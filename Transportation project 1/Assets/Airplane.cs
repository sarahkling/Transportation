using UnityEngine;
using System.Collections;

public class Airplane {
	
	public int x, y;
	public bool active;

	public int capacity = 90;
	public int cargo = 0;
	public int xMoveDirection;
	public int yMoveDirection;

	public void SetMoveDirection (int xMoveDir, int yMoveDir) {
		this.xMoveDirection = xMoveDir;
		this.yMoveDirection = yMoveDir;
	}
	public void Move ()	{
		x += xMoveDirection;
		y += yMoveDirection;
		xMoveDirection = 0;
		yMoveDirection = 0;
	}


	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
