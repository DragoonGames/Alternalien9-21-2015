using UnityEngine;
using System.Collections;

public class RevisedSlimeMovement : MonoBehaviour {

    public float maxSpeed = 10f;
    public float jumpSpeed = 1000f;
    private bool isActive = false;
    public GameObject[] leftWalls;
    public GameObject[] rightWalls;
    enum SlimeDirection
    {
        isLeft,
        isRight,
        isUpsideDown,
        isNormal
    };
    //bool isLeft = false;
    //bool isUpsideDown = false;
    float move = 0;
    SlimeDirection slimeDir = SlimeDirection.isNormal;

    // Use this for initialization
    void Start () {
	
	}

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
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
                    Physics2D.gravity = new Vector3(0, -3, 0);
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
                    //float moveUp = Input.GetAxis("Vertical");
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
				/*if (slimeDir == SlimeDirection.isUpsideDown)
				{
					print ("test1");
					if (other.gameObject.tag == "LeftWallCurve"){
						print ("test2");
						transform.Rotate(0, 0, 180);
						print("Normal Side Up");
						slimeDir = SlimeDirection.isLeft;
					}
				}
				*/
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
		/*if (other.gameObject.tag == "LeftWallCurve") {
			if (slimeDir == SlimeDirection.isUpsideDown) {
				print ("test1");
				transform.Rotate (0, 0, 180);
				transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
				print ("Left Side Up");
				slimeDir = SlimeDirection.isLeft;
			}
		}
		*/
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (slimeDir == SlimeDirection.isUpsideDown)
        {
			if(other == null)
			{
				print("null");
				if ((other.gameObject.tag != "Wall") && (other.gameObject.tag != "WallCurve") && (other.gameObject.tag != "LeftWallCurve") && (other.gameObject.tag != "RightWallCurve"))
				{
					print ("Trigger Exit");
		            transform.Rotate(0, 0, 180);
					slimeDir = SlimeDirection.isNormal;
					Physics2D.gravity = new Vector3(0, -3, 0);
				}
			}
        }
    }
}
