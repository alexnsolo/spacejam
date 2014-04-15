using UnityEngine;
using System.Collections;

public class Subsystem : Damageable {

	public bool Operational = true;

	protected override void OnDestroyed() {
		Operational = false;
	}
}