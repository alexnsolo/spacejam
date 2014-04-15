using UnityEngine;
using System.Collections;

public class Rocket : Projectile {

	public float Speed;
	private Vector3 direction;

	public override void FireAt(Transform target) {
		base.FireAt(target);
		direction = target.transform.position - transform.position;
		Update();
		gameObject.SetActive(true);
	}

	private void Update() {
		transform.position = transform.position + (direction.normalized * Time.deltaTime * Speed);
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
