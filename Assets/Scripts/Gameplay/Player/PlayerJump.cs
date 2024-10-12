using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
	public UnityEvent playerJumpedEvent;
	[SerializeField] private string groundDetectionGOTag = "Ground";
	[SerializeField, Min(0f)] private float jumpForce = 300f;
	
	private Rigidbody2D rb2D;
	private bool isGrounded;

	private Animator animator;
	

	private void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void OnMove(InputValue inputValue)
	{
		var movementVector = inputValue.Get<Vector2>();

		if(movementVector.y > 0 && isGrounded)
		{
			rb2D.AddForce(Vector2.up*jumpForce);

			isGrounded = false;

			playerJumpedEvent?.Invoke();
			animator.SetBool("jump", true);
        }
	}

	private void OnCollisionEnter2D(Collision2D collision2D)
	{
		if(collision2D.gameObject.CompareTag(groundDetectionGOTag))
		{
			isGrounded = true;
            animator.SetBool("jump", false);
        }
	}
}