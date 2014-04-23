using UnityEngine;
using System.Collections;

public class Engine : Subsystem {

	public override string DisplayCode { get { return "ENG"; } }
	public float Thrust;
	public ParticleSystem[] BlastEffects;

	private float checkFiringInterval = 0.25f;
	private int lastFireTime = 0;

	void Start() {
		InvokeRepeating("CheckStillFiring", 0f, checkFiringInterval);
	}

	public void Fire() {
		if (Operational) {
			lastFireTime = Time.frameCount;
			SwitchBlastEffect(true);
		}
	}

	private void CheckStillFiring() {
		if (Operational && lastFireTime < Time.frameCount-1) {
			SwitchBlastEffect(false);
		}
	}

	protected override void OnDestroyed() {
		base.OnDestroyed();
		SwitchBlastEffect(false);
	}

	private void SwitchBlastEffect(bool active) {
		foreach (ParticleSystem ps in BlastEffects) {
			if (active && !ps.isPlaying) {
				ps.Play();
			}
			if (!active && ps.isPlaying) {
				ps.Stop();
			}
		}	
	}
}
