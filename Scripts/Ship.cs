using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Ship : Damageable {

	public int Hitpoints;
	public Ship Target;
	public TextMesh HPText;
	public Weapon[] Weapons;
	public GameObject ExplosionPrefab;
	public int DamageableLayer;

	void Start() {
		Weapons = GetComponentsInChildren<Weapon>();
		foreach (Weapon w in Weapons) {
			w.Owner = this;
		}
		Physics2D.IgnoreLayerCollision(DamageableLayer, DamageableLayer);
	}

	void Update () {
		HPText.text = "HP: " + Hitpoints.ToString();
	}

	public override void TakeDamage(int amount) {
		Hitpoints -= amount;
		if (Hitpoints <= 0) {
			Hitpoints = 0;
			StartDestroy();
		}
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

	public void StartDestroy() {
		GameObject.Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
		GameObject.Destroy(this.gameObject);
	}
}
