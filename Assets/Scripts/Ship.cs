using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Ship : Damageable {
	
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

	protected override void OnDestroyed() {
		GameObject.Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
		base.OnDestroyed();
	}
}
