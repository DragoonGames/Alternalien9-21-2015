using UnityEngine;
using System.Collections;

public class LennyMovement : MonoBehaviour {

    bool isFacingRight = true;
    bool isFacingLeft = false;

    public float maxSpeed = 10f;
    public float jumpSpeed = 100f;
    private bool isActive = false;
    bool isGrounded = true;

    private float jumpRate = 0.25F;
    public float nextJump = 0.0F;
    public Animator anim;

    //Variables for powers
    public bool alwaysPickup = false;
    public GameObject Lenny;
    public Transform[] itemTransform;
    public GameObject objectPlacement;
    private GameObject replacedObject;
    private float inRange;
    private bool triggered;
    private bool released;

    void Start()
    {
        /*anim = GetComponent<Animator>();
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsFacingLeft", isFacingLeft);
        anim.SetBool("IsFacingRight", isFacingRight);
        */
        inRange = 5.0f;
        //inRange = replacedObject.collider2D.
        triggered = false;
    }
    IEnumerator Jump()
    {
        isGrounded = false;
        //anim.SetBool("IsGrounded", isGrounded);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);

        yield return new WaitForSeconds(nextJump);

        isGrounded = true;
        //anim.SetBool("IsGrounded", isGrounded);
    }
    void CheckDirection(float moveSpeed)
    {
        if (isFacingRight)
        {
            //anim.SetBool("IsFacingRight", isFacingRight);
            //anim.SetBool("IsFacingLeft", isFacingLeft);

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                isFacingLeft = true;
                isFacingRight = false;
                //Start of Changing Sprites
                /*anim.SetFloat("speed", moveSpeed);
                anim.SetBool("IsFacingRight", isFacingRight);
                anim.SetBool("IsFacingLeft", isFacingLeft);
                */
            }

        }
        if (isFacingLeft)
        {
            //anim.SetBool("IsFacingLeft", isFacingLeft);
            //anim.SetBool("IsFacingRight", isFacingRight);

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                isFacingLeft = false;
                isFacingRight = true;
                //Start of Changing Sprites
                /*anim.SetFloat("speed", moveSpeed);
                anim.SetBool("IsFacingRight", isFacingRight);
                anim.SetBool("IsFacingLeft", isFacingLeft);
                */
            }
        }
    }
    void Update()
    {
        if (isActive)
        {
            //CheckDirection(speed);
            float move = Input.GetAxis("Horizontal");
            float speed = (move * maxSpeed);
            //anim.SetFloat("speed", speed);
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            CheckDirection(speed);
            //Check for One Jump
            //Calls jump if button pressed, and is Grounded
            if (Input.GetButton("Jump") && isGrounded)
            {
                StartCoroutine(Jump());
            }
            CheckDirection(speed);
            /*for (int i = 0; i < jumpGateTriggers.Length; i++)
            {
                if (other.gameObject == jumpGateTriggers[i])
                {
                    //First section
                    print(other.gameObject);
                    maxSpeed = 0;
                    StartCoroutine(WaitToMove());
                }
            }
            */
            for (int i = 0; i < itemTransform.Length; i++)
            {
                if (Vector3.Distance(itemTransform[i].position, Lenny.transform.position) < inRange)
                {
                    print("In Range");
                    if (!triggered && Input.GetKeyDown(KeyCode.F))
                        Trigger(i);
                }
            }
            if (!released && Input.GetKeyDown(KeyCode.F))
            {
                Released();
            }
        }
    }
    void Trigger(int index)
    {
        triggered = true;
        released = false;

        if (alwaysPickup)
        {
            //Handle picking the item here (i.e. parent/child move to empty GO
        }
        else
        {
            //Put display Icon here
            //audioObject.transform.parent = ships[0].transform;
            itemTransform[index].transform.parent = Lenny.transform;

            Vector3 position1 = objectPlacement.transform.position;
            Quaternion rotation1 = objectPlacement.transform.rotation;
            Quaternion rotation2 = objectPlacement.transform.rotation;

            replacedObject.transform.rotation = rotation2;

            //Lenny.transform.position = replacedObject.transform.position;
            //Lenny.transform.rotation = replacedObject.transform.rotation;
        }
    }
    void Released()
    {
        triggered = false;
        released = true;

        if(!alwaysPickup)
        {
            //Remove display pickup icon here
        }
    }
    void OnCollisionEnter2D(Collision2D c)
    {

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
