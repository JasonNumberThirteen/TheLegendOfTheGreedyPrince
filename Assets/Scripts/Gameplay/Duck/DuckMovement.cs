using UnityEngine;
using UnityEngine.Events;

public class DuckMovement : MonoBehaviour
{
	[SerializeField, Min(0f)] private float amplitude = 5f;
	[SerializeField, Min(0f)] private float oscillation = 1f;

	public UnityEvent duckQuackedEvent;
	
	private void Update()
	{
		transform.position = DuckPosition();
	}

	void Start()
    {
        InvokeRepeating("Quack", 3.0f, 12.0f);
    }

    void Quack()
    {
        duckQuackedEvent?.Invoke();
    }

	private Vector3 DuckPosition()
	{
		var x = oscillation > 0f ? Mathf.Sin(Time.time / oscillation)*amplitude : transform.position.x;

		return new Vector3(x, transform.position.y, transform.position.z);
	}
}