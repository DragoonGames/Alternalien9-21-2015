using UnityEngine;
using System.Collections;

public class CeilingWalls : MonoBehaviour {

	public GameObject slimeTexture;

	void OnCollisionEnter2D(Collision2D c) {
		Quaternion theRotation = transform.localRotation;
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			theRotation.z *= 180;
			transform.localRotation = theRotation;
		}
	}
}
