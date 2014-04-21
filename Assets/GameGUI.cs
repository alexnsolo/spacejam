using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public Ship PlayerShip;
	public UISlider ShieldSlider;
	public UISlider HullSlider;

	void Update () {
		HullSlider.value = (float)PlayerShip.Hitpoints / (float)PlayerShip.MaxHitpoints;	
		ShieldSlider.value = (float)PlayerShip.Shield.Hitpoints / (float)PlayerShip.Shield.MaxHitpoints;
	}
}
