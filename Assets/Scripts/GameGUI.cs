using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameGUI : MonoBehaviour {

	public Ship PlayerShip;
	public UISlider ShieldSlider;
	public UISlider HullSlider;
	public UISlider SubsystemSliderPrefab;
	public Transform SubsystemsParent;
	public Vector3 SubsystemsStartPoint;
	public float SubsystemsSpacing;

	private Dictionary<Subsystem, UISlider> subsystemSliders = new Dictionary<Subsystem, UISlider>();

	void Start() {
		Subsystem[] subsystems = PlayerShip.GetComponentsInChildren<Subsystem>();
		float spacing = 0;
		foreach (Subsystem subsystem in subsystems) {
			UISlider slider = GameObject.Instantiate(SubsystemSliderPrefab) as UISlider;
			slider.transform.parent = SubsystemsParent;
			slider.transform.localScale = Vector3.one;
			slider.transform.localPosition = new Vector3(SubsystemsStartPoint.x + spacing, SubsystemsStartPoint.y, SubsystemsStartPoint.z);
			slider.transform.FindChild("Label").GetComponent<UILabel>().text = subsystem.DisplayCode;

			subsystemSliders.Add(subsystem, slider);

			spacing += SubsystemsSpacing;
		}
	}

	void Update () {
		HullSlider.value = (float)PlayerShip.Hitpoints / (float)PlayerShip.MaxHitpoints;	
		ShieldSlider.value = (float)PlayerShip.Shield.Hitpoints / (float)PlayerShip.Shield.MaxHitpoints;

		foreach (Subsystem subsystem in subsystemSliders.Keys) {
			subsystemSliders[subsystem].value = (float)subsystem.Hitpoints / (float)subsystem.MaxHitpoints;			
		}
	}
}
