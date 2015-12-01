using UnityEngine;
using System.Collections;

public class Angry_Sun : MonoBehaviour {

    bool isActive = false;  //Start the Burning
    Animator anim;
    public float sunTimer;
    string safe;
    string notSafe;
    public TextMesh myTextMesh;
    public string currentLevel;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        if (sunTimer == 0)
        {
            sunTimer = 5;
        }
        safe = "SAFE!";
        notSafe = "NOT SAFE!";
        StartCoroutine(BurnTheDesert());
        //StartCoroutine(SaveTheDesert());
    }
	
	// Update is called once per frame
	void Update () {
        //Other movement scripts go in here.
        //otherwise we do an IEnumerator for timer
        /*if (isActive)
        {
            StartCoroutine(BurnTheDesert());
        }
        else
        {
            StartCoroutine(SaveTheDesert());
        }
        */
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (isActive)
        {
            if (other.gameObject.tag == "Player")
            {
                //Player Dies

                //Show Pause screen that displays death.
                //Maybe include a timer for any animations for death

                Application.LoadLevel(currentLevel);
                }
            }
        }
    IEnumerator BurnTheDesert()
    {
        isActive = true;
        myTextMesh.text = notSafe + " " + isActive;
        print(isActive);
        yield return new WaitForSeconds(sunTimer);
        isActive = false;
        myTextMesh.text = safe + " " + isActive;
        print(isActive);
        yield return new WaitForSeconds(sunTimer);
        StartCoroutine(BurnTheDesert());
    }
    /*IEnumerator SaveTheDesert()
    {
        isActive = true;
        myTextMesh.text = safe;
        yield return new WaitForSeconds(sunTimer);
        StartCoroutine(BurnTheDese)
    }*/
}
