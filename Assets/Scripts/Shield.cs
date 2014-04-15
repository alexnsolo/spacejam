using UnityEngine;
using System;
using System.Collections;

public class Shield : Damageable {

	public event EventHandler Overloaded;

	public int Capacity;
	public TextMesh SPText;

	private SpriteRenderer spriteRenderer;
	private bool shieldActive = true;

	void Start() {
		spriteRenderer = ((SpriteRenderer)renderer);
	}
	
	void Update() {
		if (SPText != null) {
			if (!shieldActive) {
				SPText.text = "SP: !!!!";
			}
			else {
				SPText.text = "SP: " + Hitpoints.ToString();
			}	
		}
		Color rendererColor = spriteRenderer.color;
		rendererColor.a = ((float)Hitpoints / (float)Capacity);
        spriteRenderer.color = rendererColor;
	}

	public void Recharge(int amount) {
		Hitpoints = Mathf.Min(Capacity, Hitpoints + amount);
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
