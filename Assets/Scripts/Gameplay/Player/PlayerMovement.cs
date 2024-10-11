using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField, Min(0f)] private float movementSpeed = 150f;
	
	private Rigidbody2D rb2D;

	private void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		var speed = movementSpeed*Time.fixedDeltaTime;

		rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
	}
}