using UnityEngine;
using System.Collections;

public class PlayerPrefsUnlock : MonoBehaviour {

	void PlayerPrefKey(){
		PlayerPrefs.SetString("unlockLevel2", "unlock");
	}
}
