using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlScript : MonoBehaviour {
	public GameObject[] aliens;
    public GameObject[] accessCards;
    //public List<GameObject> accessCardsList;
	public int accessCardsToGet;
	public int lockedAliens = 0;
	private int activeAlien = 0;
	private int alienCap;
	public GameObject exitGateway;

	void SetActiveAlien() {
		foreach(GameObject alien in aliens)
			alien.transform.SendMessage ("SetInactive");

		aliens [activeAlien].SendMessage ("SetActive");
	}

	void Start () {
		alienCap = aliens.Length - lockedAliens;
		SetActiveAlien ();
        //accessCardsList.AddRange(accessCards);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Q))
        {
			activeAlien++;
			activeAlien %= alienCap;
			SetActiveAlien();
		}
		if (Input.GetKeyDown (KeyCode.E))
        {
			activeAlien += alienCap-1; // (modulo friendly equivalent to --)
			activeAlien %= alienCap;
			SetActiveAlien();
		}
        UnlockExit();
	}

	void UnlockExit()
	{
        if (accessCardsToGet == 0)
        {
            if (exitGateway.gameObject != null)
                Destroy(exitGateway);
        }
        accessCardsToGet = accessCards.Length;
        for (int i=0; i < accessCards.Length; i++)
        {
            if (accessCards[i].gameObject == null)
            {
                accessCardsToGet--;
            }
        }
		
    }
	void UnlockAliens() {
		alienCap = aliens.Length;
	}
    
}
