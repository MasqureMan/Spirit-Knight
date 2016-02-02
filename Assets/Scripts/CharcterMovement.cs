using UnityEngine;
using System.Collections;

public class CharcterMovement : MonoBehaviour 
{
	public float speed = 4.0F;

	public float jumpSpeed = 8.0F;

	public float gravity = 20.0F;

	public bool facingRight = false;

	private Vector3 moveDirection = Vector3.zero;

	CharacterController controller;

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void FixedUpdate() 
	{
		if (controller.isGrounded) 
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			moveDirection = transform.TransformDirection(moveDirection);
		
			//Vector3 theScale = new Vector3(0, 0, 0);

			moveDirection *= speed;

			if  (Input.GetAxis("Horizontal") > 0 && !facingRight)
				Flip ();
			else if( Input.GetAxis("Horizontal") < 0 && facingRight)
				Flip ();

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}

		}

		moveDirection.y -= gravity * Time.deltaTime;

		controller.Move(moveDirection * Time.deltaTime);
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
