using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {
	public float maxSpeed;
	public float attackPower;

	bool isTriggered = false;
	private bool isActive = false;

    AudioSource myAudioSource;
    public AudioClip wattsonPower;
    public AudioClip keycardPickup;
    Rigidbody2D myRigid;

	bool isFacingRight = true;
	bool isUsingPower = false;
	float speed;
	Animator anim;

    void Start()
    {
		if (maxSpeed < 10)
			maxSpeed = 50;
		if (attackPower < 0)
			attackPower = 2;
        anim = GetComponent<Animator>();
        anim.SetBool("IsFacingR", isFacingRight);
        anim.SetBool("IsUsingPower", isUsingPower);
		//anim.SetFloat ("Speed", maxSpeed);
        myAudioSource = GetComponent<AudioSource>();
        myRigid = GetComponent<Rigidbody2D>();
    }
    void Update () {
		if (isActive) {
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");
			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
			{
				speed = (horizontal * maxSpeed);
			}
			else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
			{
				speed = (vertical * maxSpeed);
			}
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (horizontal * maxSpeed, vertical * maxSpeed);
			if (isTriggered && Input.GetKeyDown(KeyCode.C))
			{
				StartCoroutine(Power());
			}
			if (!isTriggered && Input.GetKeyDown(KeyCode.F))
			{
				StartCoroutine(Power());
			}
			CheckDirection(maxSpeed);
			print(maxSpeed);
		}
	}

	void CheckDirection(float moveSpeed)
	{
		if (isFacingRight)
		{
			anim.SetBool("IsFacingR", isFacingRight);
			anim.SetFloat("Speed", maxSpeed);
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
			{
				isFacingRight = false;
				//Start of Changing Sprites
				anim.SetFloat("Speed", maxSpeed);
				anim.SetBool("IsFacingR", isFacingRight);
			}
		}
		if (!isFacingRight)
		{
			anim.SetBool("IsFacingR", isFacingRight);
			anim.SetFloat("Speed", maxSpeed);
			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				isFacingRight = true;
				//Start of Changing Sprites
				anim.SetFloat("Speed", maxSpeed);
				anim.SetBool("IsFacingR", isFacingRight);
			}
		}
	}

    IEnumerator Power()
    {
		isUsingPower = true;
		anim.SetBool("IsUsingPower", isUsingPower);
        yield return new WaitForSeconds(1);

		isUsingPower = false;
		anim.SetBool("IsUsingPower", isUsingPower);
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
