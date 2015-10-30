using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RevisedSlimeMovement : MonoBehaviour {

    public float maxSpeed = 150f;
    public float jumpSpeed = 1000f;
    private bool isActive = false;
    private float storeMaxSpeed;
    private float waitForXSeconds = 0.5f;
    public GameObject[] jumpGateTriggers;
    public GameObject[] jumpGates;
    public enum SlimeDirection
    {
        isLeft,
        isRight,
        isUpsideDown,
        isNormal
    };
    float move = 0;
    public SlimeDirection slimeDir = SlimeDirection.isNormal;
    public GameObject sludge;

    // Use this for initialization
    void Start () {
        storeMaxSpeed = maxSpeed;
	}
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
    }
    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(waitForXSeconds);
        maxSpeed = storeMaxSpeed;
    }
    void Update()
    {
        if (isActive)
        {
            switch(slimeDir)
            {
                case SlimeDirection.isNormal:
                    move = Input.GetAxis("Horizontal");
                    GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
                    Physics2D.gravity = new Vector3(0, -30, 0);
                    if (Input.GetButtonDown("Jump"))
                        Jump();
                    break;
                case SlimeDirection.isLeft:
                    //float moveUp = Input.GetAxis("Vertical");
                    move = Input.GetAxis("Vertical");
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, move * maxSpeed);
                    Physics2D.gravity = Vector3.zero;
                    if (Input.GetButtonDown("Jump"))
                        Jump();
                    break;
                case SlimeDirection.isRight:
                    //moveUp = Input.GetAxis("Vertical");
                    move = Input.GetAxis("Vertical");
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, move * maxSpeed);
                    Physics2D.gravity = Vector3.zero;
                    if (Input.GetButtonDown("Jump"))
                        Jump();
                    break;
                case SlimeDirection.isUpsideDown:
                    move = Input.GetAxis("Horizontal");
                    GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
                    Physics2D.gravity = Vector3.zero;
                    if (Input.GetButtonDown("Jump"))
                        Jump();
                    break;
            }
        }
        CheckRotation();
    }
    void SetActive()
    {
        isActive = true;
    }
    void SetInactive()
    {
        isActive = false;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //Climb wall to the left
                if (slimeDir == SlimeDirection.isNormal)
                {
                    transform.Rotate(0, 0, 270);
                    print("Left Side");
                    slimeDir = SlimeDirection.isLeft;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //Change from Left wall to Ceiling
                if (slimeDir == SlimeDirection.isLeft)
                {
                    transform.Rotate(0, 0, 270);
                    print("Upside Down");
                    slimeDir = SlimeDirection.isUpsideDown;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //Change from Right wall to Ceiling
                if (slimeDir == SlimeDirection.isRight)
                {
                    transform.Rotate(0, 0, 270);
                    print("Upside Down");
                    slimeDir = SlimeDirection.isUpsideDown;
                }
            }
			else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
				//Detach from Ceiling
				if (slimeDir == SlimeDirection.isUpsideDown)
				{
					if (Input.GetKeyDown(KeyCode.DownArrow))
					{
						transform.Rotate(0, 0, 180);
						print("Normal Side Up");
						slimeDir = SlimeDirection.isNormal;
					}
				}
			}
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i=0; i< jumpGateTriggers.Length;i++)
        {
            if (other.gameObject == jumpGateTriggers[i])
            {
                //First section
                print(other.gameObject);
                maxSpeed = 0;
                StartCoroutine(WaitToMove());
            }
        }
        
    }
    public void CheckRotation()
    {
        if (sludge.transform.rotation.eulerAngles.z == 270)
        {
            slimeDir = SlimeDirection.isLeft;
            Physics2D.gravity = Vector3.zero;
            //print("move to Is Left");
        }
        else if (sludge.transform.rotation.eulerAngles.z == 180)
        {
            slimeDir = SlimeDirection.isUpsideDown;
            Physics2D.gravity = Vector3.zero;
            //print("move to Is Upsdie Down");
        }
        else if (sludge.transform.rotation.eulerAngles.z == 90)
        {
            slimeDir = SlimeDirection.isRight;
            Physics2D.gravity = Vector3.zero;
            //print("move to Is Right");
        }
        else if (sludge.transform.rotation.eulerAngles.z == 0)
        {
            slimeDir = SlimeDirection.isNormal;
            Physics2D.gravity = Vector3.zero;
            //print("move to Is Normal");
        }
    }
}
