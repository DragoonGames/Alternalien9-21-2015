using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {

	void Win() {
		Application.LoadLevel ("WinScene");
	}
	void JumperHit() {
		Win ();
	}
	void CrusherHit() {
		Win ();
	}
	void CloudHit() {
		Win ();
	}


}
