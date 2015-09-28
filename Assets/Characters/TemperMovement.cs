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

    public Sprite leftSprite, rightSprite;

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
    }

    void LaunchFireIceBall()
    {
        /*Debug.Log("Fire Right");

        Rigidbody2D fireClone;
        fireClone = Instantiate(fireballRigid, transform.position, transform.rotation) as Rigidbody2D;
        fireClone.velocity = transform.TransformDirection(Vector3.right * 35 + Vector3.up * 35);

        Destroy(fireClone.gameObject, 15.0f);
         */

        if (fireMode)
        {
            if (isFacingRight)
            {
                Debug.Log("Fire Right");

                Rigidbody2D fireClone;
                fireClone = Instantiate(fireballRigid, transform.position, transform.rotation) as Rigidbody2D;
                fireClone.velocity = transform.TransformDirection(Vector3.right * 35 + Vector3.up * 35);

                Destroy(fireClone.gameObject, 15.0f);
            }
            else if (isFacingLeft)
            {
                Debug.Log("Fire Left");

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
                Debug.Log("Ice Right");

                Rigidbody2D iceClone;
                iceClone = Instantiate(iceballRigid, transform.position, transform.rotation) as Rigidbody2D;
                iceClone.velocity = transform.TransformDirection(Vector3.right * 35 + Vector3.up * 35);

                Destroy(iceClone.gameObject, 15.0f);
            }
            else if (isFacingLeft)
            {
                Debug.Log("Ice Left");

                Rigidbody2D iceClone;
                iceClone = Instantiate(iceballRigid, transform.position, transform.rotation) as Rigidbody2D;
                iceClone.velocity = transform.TransformDirection(Vector3.left * 35 + Vector3.up * 35);

                Destroy(iceClone.gameObject, 15.0f);
            }

        }
    }
    void CheckDirection()
    {
        if (isFacingRight)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Facing Left");
                isFacingLeft = true;
                isFacingRight = false;
                //Start of Changing Sprites
                this.gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
            }
            
        }
        if (isFacingLeft)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Facing Right");
                isFacingLeft = false;
                isFacingRight = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
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
            }
            else if (iceMode)
            {
                iceMode = false;
                fireMode = true;
            }
        }
    }

    void Update()
    {
        if (isActive)
        {
            float move = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (Input.GetButtonDown("Jump"))
                Jump();

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Fire");
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
