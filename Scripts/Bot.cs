using UnityEngine;
using System.Collections;

public class Bot : MonoBehaviour {
	
	public Ship MyShip;
	public float FireWeaponsInterval;

	private void Start() {
		InvokeRepeating("FireAtTarget", 0.5f, FireWeaponsInterval);
	}

	private void FireAtTarget() {
		MyShip.FireAtTarget();
	}
}
