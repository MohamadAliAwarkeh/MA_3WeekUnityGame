using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwoController : MonoBehaviour {

	//Public Variables
	public float moveSpeed;
	public float jumpForce;
	public int numOfJumps;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask groundLayer;

	//Private Variables
	private float moveInput;
	private Rigidbody2D myRB;
	private bool facingRight = true;
	private bool isGround;
	private int jumps;

	void Start()
	{
		//Setting the RB
		myRB = GetComponent<Rigidbody2D>();

		//Setting the jump value
		jumps = numOfJumps;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Joystick1Button2) && jumps > 0)
		{
			myRB.velocity = Vector2.up * jumpForce;
			jumps--;
		}

		if (isGround == true)
		{
			jumps = numOfJumps;
		}
	}

	void FixedUpdate()
	{

		//Here we are checking if the player is on the ground or not
		isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

		//Adding player movement
		moveInput = Input.GetAxisRaw("JoyconRHorizontal");
		myRB.velocity = new Vector2(moveInput * moveSpeed, myRB.velocity.y);

		//Checking if the character is NOT facing the right direction
		if (facingRight == false && moveInput > 0)
		{
			Flip();
		}
		//Checking if the character is moving left, and flipping
		//him to the correct direction
		else if (facingRight == true && moveInput < 0)
		{
			Flip();
		}
	}

	void Flip()
	{
		//Here we simply flip the sprite asset, from left to right
		//by changing the transform.localScale
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
}
