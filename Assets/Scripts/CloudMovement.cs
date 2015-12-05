using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {
	public float maxSpeed = 10f;
	private bool isActive = false;
    private float jumpRate = 0.25F;

    AudioSource myAudioSource;
    public AudioClip wattsonPower;
    public AudioClip keycardPickup;
    Rigidbody2D myRigid;

    void Start()
    {
        /*anim = GetComponent<Animator>();
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFacingRight", isFacingRight);
        anim.SetBool("isUsingPower", isUsingPower);
        */
        myAudioSource = GetComponent<AudioSource>();
        myRigid = GetComponent<Rigidbody2D>();
    }
    void Update () {
		if (isActive) {
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");

			GetComponent<Rigidbody2D>().velocity = new Vector2 (horizontal * maxSpeed, vertical * maxSpeed);
		}
	}
    IEnumerator Power()
    {
        yield return new WaitForSeconds(0);
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "isCardKey")
        {
            myAudioSource.Stop();
            myAudioSource.clip = keycardPickup;
            myAudioSource.Play();
            Destroy(c.gameObject);
        }
    }
    void SetActive()
    {
		isActive = true;
        myRigid.constraints = RigidbodyConstraints2D.None;
        myRigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
	void SetInactive()
    {
		isActive = false;
        myRigid.constraints = RigidbodyConstraints2D.FreezePositionX;
        myRigid.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
}
