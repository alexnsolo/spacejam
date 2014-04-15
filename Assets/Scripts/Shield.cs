using UnityEngine;
using System.Collections;

public class Shield : Damageable {

	public int Strength;
	public int Capacity;
	public TextMesh SPText;
	public float OverloadRecoveryTime;
	public float OverloadRecoveryPercentage;

	private bool overloaded = false;
	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = ((SpriteRenderer)renderer);
	}

	public override void TakeDamage(int amount) {
		Strength -= amount;
		if (Strength <= 0) {
			Strength = 0;
			overloaded = true;
			SwitchShield(false);
			Invoke("RecoverFromOverload", OverloadRecoveryTime); 
		}
	}

	public void Recharge(int amount) {
		Strength += amount;
		if (Strength > Capacity) Strength = Capacity;
	}

	void Update() {
		if (overloaded) {
			SPText.text = "SP: !!!!";
		}
		else {
			SPText.text = "SP: " + Strength.ToString();
		}
		Color rendererColor = spriteRenderer.color;
		rendererColor.a = ((float)Strength / (float)Capacity);
        spriteRenderer.color = rendererColor;
	}

	void RecoverFromOverload() {
		overloaded = false;
		SwitchShield(true);
		Strength = Mathf.RoundToInt((float)Capacity * OverloadRecoveryPercentage);
	}

	void SwitchShield(bool on) {
		collider2D.enabled = on;
		renderer.enabled = on;
	}
}
