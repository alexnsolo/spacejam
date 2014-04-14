using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Ship MyShip;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			MyShip.FireAtTarget();
		}
	}
}

