using UnityEngine;

public class ParallaxPositionAdjuster : MonoBehaviour
{
	[SerializeField, Min(0f)] private float movementSpeed = 1f;

	private void Update()
	{
		var speed = movementSpeed*Time.deltaTime;
		
		transform.Translate(speed*Vector2.right);
	}
}