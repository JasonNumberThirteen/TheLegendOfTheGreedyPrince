using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
	[SerializeField, Min(0f)] private float movementSpeed = 1f;
	[SerializeField] private bool moveBackward;

	private void Update()
	{
		var direction = MovementDirection();
		var speed = movementSpeed*Time.deltaTime;
		
		transform.Translate(direction*speed*Vector2.right);
	}

	private int MovementDirection() => moveBackward ? -1 : 1;
}