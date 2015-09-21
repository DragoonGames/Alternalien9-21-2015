using UnityEngine;
using System.Collections;

public class CrushHit : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D c) {
		c.gameObject.SendMessage ("CrusherHit");
	}
}
