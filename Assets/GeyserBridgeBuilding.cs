using UnityEngine;
using System.Collections;

public class GeyserBridgeBuilding : MonoBehaviour {

    public GameObject Geyser;
    public GameObject Bridge;

    public Rigidbody2D FireballRigidbody;
    public Rigidbody2D IceBallRigidbody;

    public bool isGeyser = true;
    public bool isBridge = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isGeyser) //Turn to Bridge
        {
            if (other.gameObject.name == IceBallRigidbody.gameObject.name) //Ice Hits Geyser
            {
                print("Turn to Bridge");
                isGeyser = false;
                isBridge = true;
                Bridge.gameObject.SetActive(true);
                Geyser.gameObject.SetActive(false);
            }
        }
        else if (isBridge) //Melt to Geyser
        {
            if (other.gameObject.name == FireballRigidbody.gameObject.name) //Fire hits bridge
            {
                print("Turn to Geyser");
                isBridge = true;
                isGeyser = false;
                Geyser.gameObject.SetActive(true);
                Bridge.gameObject.SetActive(false);
            }
        }
    }
}
