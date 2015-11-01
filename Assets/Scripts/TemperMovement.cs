using UnityEngine;
using System.Collections;

public class TemperMovement : MonoBehaviour 
{

    public float maxSpeed = 10f;
    public float jumpSpeed = 100f;
    private bool isActive = false;

    //public Transform fireballPrefab;
    public Rigidbody2D fireballRigid;
    public Rigidbody2D iceballRigid;
    public float shotPower = 80;

    bool isFacingRight = true;
    bool isFacingLeft = false;
    bool fireMode = true;
    bool iceMode = false;

    public Sprite leftFireSprite, rightFireSprite;
    public Sprite leftIceSprite, rightIceSprite;
    void Jump()
    {
		//GetComponent<Rigidbody2D>().AddForce(Vector3.right * 35 + Vector3.up * 35);
		print ("Jump");
		GetComponent<Rigidbody2D>().transform.TransformDirection(Vector3.right * 150 + Vector3.up * 150);
		//fireClone.velocity = transform.TransformDirection(Vector3.right * 35 + Vector3.up * 35);
    }

    void LaunchFireIceBall()
    {
        if (fireMode)
        {
            if (isFacingRight)
            {
                Rigidbody2D fireClone;
                fireClone = Instantiate(fireballRigid, transform.position, transform.rotation) as Rigidbody2D;
                fireClone.velocity = transform.TransformDirection(Vector3.right * 35 + Vector3.up * 35);

                Destroy(fireClone.gameObject, 15.0f);
            }
            else if (isFacingLeft)
            {
                Rigidbody2D fireClone;
                fireClone = Instantiate(fireballRigid, transform.position, transform.rotation) as Rigidbody2D;
                fireClone.velocity = transform.TransformDirection(Vector3.left * 35 + Vector3.up * 35);

                Destroy(fireClone.gameObject, 15.0f);
            }
        }
        else if (iceMode)
        {
            if (isFacingRight)
            {
                Rigidbody2D iceClone;
                iceClone = Instantiate(iceballRigid, transform.position, transform.rotation) as Rigidbody2D;
                iceClone.velocity = transform.TransformDirection(Vector3.right * 35 + Vector3.up * 35);

                Destroy(iceClone.gameObject, 15.0f);
            }
            else if (isFacingLeft)
            {
                Rigidbody2D iceClone;
                iceClone = Instantiate(iceballRigid, transform.position, transform.rotation) as Rigidbody2D;
                iceClone.velocity = transform.TransformDirection(Vector3.left * 35 + Vector3.up * 35);

                Destroy(iceClone.gameObject, 15.0f);
            }

        }
    }
    void CheckDirection()
    {
        if (fireMode)
        {
            if (isFacingRight)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    isFacingLeft = true;
                    isFacingRight = false;
                    //Start of Changing Sprites
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = leftFireSprite;
                }

            }
            if (isFacingLeft)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    isFacingLeft = false;
                    isFacingRight = true;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = rightFireSprite;
                }
            }
        }
        else if (iceMode)
        {
            if (isFacingLeft)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    isFacingLeft = false;
                    isFacingRight = true;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = rightIceSprite;
                }
            }
            else if (isFacingRight)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    isFacingLeft = true;
                    isFacingRight = false;
                    //Start of Changing Sprites
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = leftIceSprite;
                }

            }
        }
    }
    void CheckTemperature()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (fireMode)
            {
                fireMode = false;
                iceMode = true;
                if (isFacingLeft)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = leftIceSprite;
                }
                else if (isFacingRight)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = rightIceSprite;
                }
            }
            else if (iceMode)
            {
                iceMode = false;
                fireMode = true;
                if (isFacingLeft)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = leftFireSprite;
                }
                else if (isFacingRight)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = rightFireSprite;
                }

            }
        }
    }

    void Update()
    {
        if (isActive)
        {
            /*float move = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
			*/

			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");
			
			GetComponent<Rigidbody2D>().velocity = new Vector2 (horizontal * maxSpeed, vertical * maxSpeed);

            if (Input.GetButtonDown("Jump"))
                Jump();

            if (Input.GetKeyDown(KeyCode.F))
            {
                LaunchFireIceBall();
            }
            CheckDirection();
            CheckTemperature();
        }
    }
    void SetActive()
    {
        isActive = true;
    }
    void SetInactive()
    {
        isActive = false;
    }
}
