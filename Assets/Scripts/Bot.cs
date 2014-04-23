using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bot : MonoBehaviour {
	
	public Ship MyShip;
	public float FireWeaponsInterval;

	private void Start() {
		InvokeRepeating("FireAtTarget", 0.5f, FireWeaponsInterval);
	}

	private void Update() {
		if (MyShip.Target != null) {
			MyShip.FaceToward(MyShip.Target.transform.position);
		}
	}

	private void FireAtTarget() {
		foreach (Weapon w in MyShip.Weapons) {
			if (w is RocketLauncher) {
				RaycastHit2D[] hits = Physics2D.RaycastAll(w.transform.position, w.transform.right);
				foreach (RaycastHit2D hit in hits) {
					if (hit != null && hit.collider.gameObject.layer == MyShip.Target.DamageableLayer) {
						w.FireAt(MyShip.Target.transform);
						break;
					}
				}
			}
		}
	}
}
