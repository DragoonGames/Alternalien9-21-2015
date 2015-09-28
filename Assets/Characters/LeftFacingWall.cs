using UnityEngine;
using System.Collections;

public class LeftFacingWall : MonoBehaviour {

	public GameObject slimeTexture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D c) {
		Quaternion theRotation = transform.localRotation;
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			theRotation.z *= 90;
			transform.localRotation = theRotation;
		}
	}
}
