using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Ship Owner;
	public float CooldownTime;


	private bool readyToFire = true;

	public void FireAt(Transform target) {
		if (readyToFire) {
			FiredAt(target);
			readyToFire = false;
			Invoke("Cooldown", CooldownTime);
		}
	}

	protected virtual void FiredAt(Transform target) {}

	private void Cooldown() {
		readyToFire = true;
	}
}
