using UnityEngine;
using System.Collections;

public class ShieldGenerator : Damageable {

	public int Strength;
	public int Capacity;
	public float RechargeTime;
	public float OverloadRecoveryTime;
	public float OverloadRecoveryPercentage;
	public TextMesh SPText;
	public SpriteRenderer MyRenderer;

	private bool overloaded = false;

	public override void TakeDamage(int amount) {
		Strength -= amount;
		if (Strength <= 0) {
			Strength = 0;
			collider2D.enabled = false;
			overloaded = true;
			MyRenderer.enabled = false;
			Invoke("RecoverFromOverload", OverloadRecoveryTime); 
		}
	}

	void Update() {
		if (!overloaded && Strength < Capacity) {
			Strength += Mathf.RoundToInt(Time.deltaTime * Capacity / RechargeTime);
		}
		if (overloaded) {
			SPText.text = "SP: !!!!";
		}
		else {
			SPText.text = "SP: " + Strength.ToString();
		}
		Color rendererColor = MyRenderer.color;
		rendererColor.a = ((float)Strength / (float)Capacity);
		MyRenderer.color = rendererColor;
	}

	void RecoverFromOverload() {
		overloaded = false;
		collider2D.enabled = true;
		MyRenderer.enabled = true;
		Strength = Mathf.RoundToInt((float)Capacity * OverloadRecoveryPercentage);
	}
}
