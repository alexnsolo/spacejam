using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Ship : Damageable {
	
	public Ship Target;
	public Shield Shield;
	public Weapon[] Weapons;
	public Engine[] Engines;
	public GameObject ExplosionPrefab;
	public int DamageableLayer;

	void Start() {
		Weapons = GetComponentsInChildren<Weapon>();
		Engines = GetComponentsInChildren<Engine>();
		foreach (Weapon w in Weapons) {
			w.Owner = this;
		}
		Physics2D.IgnoreLayerCollision(DamageableLayer, DamageableLayer);
	}

	public void FireAtTarget() {
		if (Target != null) {
			foreach (Weapon weapon in Weapons) {
				weapon.FireAt(Target.transform);
			}
		} 
		else {
			CancelInvoke();
		}
	}

	public void FireEngines() {
		float totalThrust = 0f;
		foreach (Engine e in Engines) {
			if (e.Operational) {
				totalThrust += e.Thrust;
				e.Fire();
			}
		}
		if (totalThrust > 0) {
			rigidbody2D.AddForce(transform.right * totalThrust);
		}
	}

	public void FaceToward(Vector3 target) {
		Vector3 dir = target - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	protected override void OnDestroyed() {
		GameObject.Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
		base.OnDestroyed();
	}
}
