using UnityEngine;
using System.Collections;

public class Shield : Damageable {

	public int Capacity;
	public TextMesh SPText;
	public float OverloadRecoveryTime;
	public float OverloadRecoveryPercentage;

	private bool overloaded = false;
	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = ((SpriteRenderer)renderer);
	}
	
	void Update() {
		if (overloaded) {
			SPText.text = "SP: !!!!";
		}
		else {
			SPText.text = "SP: " + Hitpoints.ToString();
		}
		Color rendererColor = spriteRenderer.color;
		rendererColor.a = ((float)Hitpoints / (float)Capacity);
        spriteRenderer.color = rendererColor;
	}

	public void Recharge(int amount) {
		Hitpoints += amount;
		if (Hitpoints > Capacity) Hitpoints = Capacity;
	}

	protected override void OnDestroyed() {
		overloaded = true;
		SwitchShield(false);
		Invoke("RecoverFromOverload", OverloadRecoveryTime); 
	}

	void RecoverFromOverload() {
		overloaded = false;
		SwitchShield(true);
		Hitpoints = Mathf.RoundToInt((float)Capacity * OverloadRecoveryPercentage);
	}

	void SwitchShield(bool on) {
		collider2D.enabled = on;
		renderer.enabled = on;
	}
}
