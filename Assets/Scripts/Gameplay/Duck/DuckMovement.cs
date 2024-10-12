using UnityEngine;

public class DuckMovement : MonoBehaviour
{
	[SerializeField, Min(0f)] private float amplitude = 5f;
	[SerializeField, Min(0f)] private float oscillation = 1f;
	
	private void Update()
	{
		transform.position = DuckPosition();
	}

	private Vector3 DuckPosition()
	{
		var x = oscillation > 0f ? Mathf.Sin(Time.time / oscillation)*amplitude : transform.position.x;

		return new Vector3(x, transform.position.y, transform.position.z);
	}
}