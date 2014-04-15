using UnityEngine;
using System;
using System.Collections;

public class ShieldGenerator : Subsystem {

	public Shield MyShield;
	public int RechargeAmount;
	public float OverloadRecoveryTime;
	public int OverloadRecoveryAmount;

	private bool overloaded = false;

	void Start() {
		MyShield.Overloaded += HandleMyShieldOverloaded;
	}

	void OnDestroy() {
		MyShield.Overloaded -= HandleMyShieldOverloaded;
	}

	void Update() {
		if (Operational && !overloaded) {
			MyShield.Recharge(Mathf.RoundToInt(RechargeAmount * Time.deltaTime));
		}
	}

	void HandleMyShieldOverloaded(object sender, EventArgs args) {
		overloaded = true;
		Invoke("RecoverFromOverload", OverloadRecoveryTime);
	}

	void RecoverFromOverload() {
		overloaded = false;
		MyShield.Recharge(OverloadRecoveryAmount);
	}
}
