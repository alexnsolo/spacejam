using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform Target;
	public float CameraFollowSpeed;

	void LateUpdate () {
		if (Target != null) {
		  	Vector3 cameraPos = Target.position;
		  	cameraPos.z = -10;
		  	transform.position = Vector3.Lerp(transform.position, cameraPos, CameraFollowSpeed * Time.deltaTime);
		}
	}
}
