using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Ship MyShip;

	private void Update() {
		if (Input.GetKey(KeyCode.Space)) {
			MyShip.FireAtTarget();
		}
		if (Input.GetKey(KeyCode.LeftShift)) {
			MyShip.FireEngines();
		}

	  	MyShip.FaceToward(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
}

