using UnityEngine;
using System.Collections;

public class Weapon : Subsystem {

	public override string DisplayCode { get { return "WPN"; } }
	public Ship Owner;
	public float CooldownTime;

	private bool readyToFire = true;

	public void FireAt(Transform target) {
		if (Operational && readyToFire) {
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
