using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
	public int x, y;

	GameController aGameController;

	void OnMouseDown () {
		aGameController.ProcessClickedCube(this.gameObject, x, y);
	}


	// Use this for initialization
	void Start () {

		aGameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}