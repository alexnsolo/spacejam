using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Ship MyShip;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			MyShip.FireAtTarget();
		}
		if (Input.GetKey(KeyCode.LeftShift)) {
			MyShip.FireEngines();
		}

	  	MyShip.FaceToward(Camera.main.ScreenToWorldPoint(Input.mousePosition));

	  	Vector3 cameraPos = MyShip.transform.position;
	  	cameraPos.z = -10;
	  	Camera.main.transform.position = cameraPos;
	}
}

