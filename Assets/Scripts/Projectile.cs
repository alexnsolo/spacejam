using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {

	private Ship owner;
	public Ship Owner {
		set {
			owner = value;
			gameObject.layer = owner.DamageableLayer;
		}
	}

	public int Damage;
	public GameObject ExplosionPrefab;


	private void OnCollisionEnter2D(Collision2D col) {
		Damageable other = col.gameObject.GetComponent<Damageable>();
		if (other != null) {
			other.TakeDamage(Damage);
			StartDestroy();
		}
	}

	private void StartDestroy() {
		GameObject.Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
		GameObject.Destroy(this.gameObject);
	}
}
