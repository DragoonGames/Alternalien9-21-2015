using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {
	public GameObject[] aliens;
	public GameObject[] accessCards;
	public int accessCardsToGet;
	public int lockedAliens = 0;
	private int activeAlien = 0;
	private int alienCap;
	public GameObject[] exitGateway;

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
		if (accessCardsToGet == 0) {
			foreach (GameObject val in exitGateway)
			         Destroy (val);
		}
	}

	void UnlockExit()
	{
		if (GameObject.FindWithTag("Card") == null) {
			accessCardsToGet--;
		}
		/*foreach (GameObject val in accessCards) {
			if (Destroy(val))
				accessCardsToGet--;
		}
		*/
	}
	void UnlockAliens() {
		alienCap = aliens.Length;
	}
}
