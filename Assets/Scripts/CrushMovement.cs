using UnityEngine;
using System.Collections;

public class CrushMovement : MonoBehaviour {

	bool isFacingRight = true;
	bool isFacingLeft = false;

	public float maxSpeed = 10f;
	public float jumpSpeed = 100f;
	private bool isActive = false;
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
	public Animator myAnimator;

	void Start(){
		//myCrusherState = crusher.idleRight;
	}
	void Jump()
	{
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
		//myCrushAnimator.
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
		if (isActive)
		{
			float move = Input.GetAxis("Horizontal");
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
			
			if (Input.GetButtonDown("Jump"))
				Jump();
			
			if (Input.GetKeyDown(KeyCode.F))
			{
				Debug.Log("Punch");
			}
			CheckDirection();

			//myAnimator.SetBool("IsGrounded", myCrusherState);
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
