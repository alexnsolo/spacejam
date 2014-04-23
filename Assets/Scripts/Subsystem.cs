using UnityEngine;
using System.Collections;

public class Subsystem : Damageable {

	public bool Operational = true;
	public virtual string DisplayCode { get { return "SUB"; } }

	protected override void OnDestroyed() {
		Operational = false;
	}
}