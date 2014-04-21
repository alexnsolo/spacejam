using UnityEngine;
using System;
using System.Collections;

public class Shield : Damageable {

	public event EventHandler Overloaded;

	private SpriteRenderer spriteRenderer;
	private bool shieldActive = true;

	void Start() {
		spriteRenderer = ((SpriteRenderer)renderer);
	}
	
	void Update() {
		Color rendererColor = spriteRenderer.color;
		rendererColor.a = ((float)Hitpoints / (float)MaxHitpoints);
        spriteRenderer.color = rendererColor;
	}

	public void Recharge(int amount) {
		Hitpoints = Mathf.Min(MaxHitpoints, Hitpoints + amount);
		if (!shieldActive) {
			SwitchShieldOn();
		}
	}

	protected override void OnDestroyed() {
		SwitchShieldOff();
		if (Overloaded != null) {
			Overloaded(this, new EventArgs());
		}
	}

	void SwitchShieldOn() {
		shieldActive = true;
		collider2D.enabled = true;
		renderer.enabled = true;
	}

	void SwitchShieldOff() {
		shieldActive = false;
		collider2D.enabled = false;
		renderer.enabled = false;
	}
}
