using UnityEngine;
using System.Collections;

public class Subsystem : Damageable {

	public bool Operational = true;

	protected override void OnDestroy() {
		Operational = false;
	}
}