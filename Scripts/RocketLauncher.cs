using UnityEngine;
using System.Collections;

public class RocketLauncher : Weapon {

	public Rocket RocketPrefab;

	protected override void FiredAt(Transform target) {
		Rocket rocket = GameObject.Instantiate(RocketPrefab, transform.position, Quaternion.identity) as Rocket;
		rocket.Owner = Owner;
		rocket.FireAt(target);
	}
}
