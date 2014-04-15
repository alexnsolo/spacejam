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
	public float DamageRadius;
	public GameObject ExplosionPrefab;

	private void OnCollisionEnter2D(Collision2D col) {
		Damageable other = col.gameObject.GetComponent<Damageable>();
		if (other != null) {
			Explode();
		}
	}

	private void Explode() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), DamageRadius);
		foreach (Collider2D col in colliders) {
			if (col.gameObject.layer != gameObject.layer) { // not in the projectile owner's layer, to prevent friendly fire
				Damageable other = col.gameObject.GetComponent<Damageable>();
				if (other != null) {
					Debug.Log(gameObject.name + " exploding against " + col.gameObject.name);
					other.TakeDamage(Damage);
				}
			}
		}

		GameObject.Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
		GameObject.Destroy(this.gameObject);
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, DamageRadius);
	}
}
