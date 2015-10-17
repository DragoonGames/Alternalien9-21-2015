using UnityEngine;
using System.Collections;

public class DropStalagmites : MonoBehaviour {

    public GameObject objectToDrop;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D objectRigidbody = objectToDrop.AddComponent<Rigidbody2D>();
        objectRigidbody.mass = 5;
        objectRigidbody.gravityScale = 5;
    }
}
