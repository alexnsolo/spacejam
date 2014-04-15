using UnityEngine;
using System.Collections;

public class ShieldGenerator : Subsystem {

	public Shield MyShield;
	public float RechargeAmount;

	void Update() {
		if (Operational) {
			MyShield.Recharge(Mathf.RoundToInt(RechargeAmount * Time.deltaTime));
		}
	}
}
