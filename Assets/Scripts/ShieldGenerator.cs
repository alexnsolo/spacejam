using UnityEngine;
using System.Collections;

public class ShieldGenerator : MonoBehaviour {

	public Shield MyShield;
	public float RechargeAmount;


	void Update() {
		MyShield.Recharge(Mathf.RoundToInt(RechargeAmount * Time.deltaTime));
	}
}
