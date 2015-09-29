using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {
	public GameObject[] aliens;
	public int lockedAliens = 0;
	private int activeAlien = 0;
	private int alienCap;

	void SetActiveAlien() {
		foreach(GameObject alien in aliens)
			alien.transform.SendMessage ("SetInactive");

		aliens [activeAlien].SendMessage ("SetActive");
	}

	void Start () {
		alienCap = aliens.Length - lockedAliens;
		SetActiveAlien ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			activeAlien++;
			activeAlien %= alienCap;
			SetActiveAlien();
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			activeAlien += alienCap-1; // (modulo friendly equivalent to --)
			activeAlien %= alienCap;
			SetActiveAlien();
		}
	}

	void UnlockAliens() {
		alienCap = aliens.Length;
	}
}
