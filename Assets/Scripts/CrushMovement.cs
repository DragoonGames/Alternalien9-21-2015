using UnityEngine;
using System.Collections;

public class CrushMovement : MonoBehaviour {

	bool isFacingRight = true;
	bool isFacingLeft = false;

	public float maxSpeed = 10f;
	public float jumpSpeed = 100f;
	private bool isActive = false;
    bool isGrounded = true;

    public float jumpRate = 0.25F;
    private float nextJump = 0.0F;

    public enum crusher
	{
		idleLeft,
		idleRight,
		walkLeft,
		walkRight,
		jumpLeft,
		jumpRight,
		punchLeft,
		punchRight
	}
	string myCrusherState;
	//public Animation idleLeftAnim, idleRightAnim, walkLeftAnim, walkRightAnim, jumpLeftAnim, jumpRightAnim, punchLeftAnim, punchRightAnim;
	public Sprite leftSprite, rightSprite;

    public Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("Run");
    int punchHash = Animator.StringToHash("Punch");

	void Start(){
        anim = GetComponent<Animator>();
        anim.enabled = true;
	}
	void Jump()
	{
        print("Jump");
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
        isGrounded = false;
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
    void Update()
	{
        float moveAnim = Input.GetAxis("Vertical");
        anim.SetFloat("speed", moveAnim);
		if (isActive)
		{
			float move = Input.GetAxis("Horizontal");
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            //Check for One Jump
            //Calls jump if button pressed, and is Grounded
            if (Input.GetButton("Jump") && isGrounded)
            {
                nextJump = (Time.time + jumpRate) *1.25f;
                anim.SetTrigger(jumpHash);
                Jump();
            }
            //When timer runs out, jump can be called again
            if (Time.time > nextJump && !isGrounded)
            {
                nextJump = (Time.time + jumpRate) * 1.25f;
                isGrounded = true;
            }
            if(Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger(punchHash);
            }
			CheckDirection();
		}
	}
    void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.tag == "isBreakable")
        {
            print("isBreakable Stay");
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Punch mode
                print("Punch Stay");
                anim.SetTrigger(punchHash);
                Destroy(c.gameObject);
            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "isCardKey")
        {
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "isBreakable")
        {
            print("isBreakable Enter");
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Punch mode
                print("Punch Enter");
                anim.SetTrigger(punchHash);
                Destroy(c.gameObject);
            }
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
