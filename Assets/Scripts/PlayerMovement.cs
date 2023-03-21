using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;
	SpriteRenderer sp;
	BoxCollider2D collider;
	public LayerMask ground;
	float xVal = 0f;

	public float moveSpeed = 7f;
	public float jumpForce = 10f;

	private enum MovementState { idle, running, jumping, falling }

	private MovementState state = MovementState.idle;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sp = GetComponent<SpriteRenderer>();
		collider = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		xVal = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(xVal * moveSpeed, rb.velocity.y);

		if (Input.GetButtonDown("Jump") && isGround())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}

		animationUpdate();
	}

	public void animationUpdate()
	{
		if (xVal > 0f)
		{
			state = MovementState.running;
			sp.flipX = false;
		}
		else if (xVal < 0f)
		{
			state = MovementState.running;
			sp.flipX = true;
		}
		else
		{
			state = MovementState.idle;
		}

		if (rb.velocity.y > .1f)
		{
			state = MovementState.jumping;
		}
		if (rb.velocity.y < -.1f)
		{
			state = MovementState.falling;
		}

		anim.SetInteger("state", (int)state);

	}

	public bool isGround()
	{
		return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, ground);
	}
}
