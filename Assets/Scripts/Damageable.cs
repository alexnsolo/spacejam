using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

	public int Hitpoints;

	public void TakeDamage(int amount) {
		if (Hitpoints > 0) {
			Hitpoints -= amount;
			if (Hitpoints <= 0) {
				Hitpoints = 0;
				OnDestroy();
			}	
		}
	}

	protected virtual void OnDestroy() {
		GameObject.Destroy(this.gameObject);
	}
}
