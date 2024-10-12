using UnityEngine;

public class ObjectPositionClamper : MonoBehaviour
{
	[SerializeField] private float positionXForReset = 32f;

	private float startPositionX;

	private void Awake()
	{
		startPositionX = transform.position.x;
	}
	
	private void Update()
	{
		if(transform.position.x <= positionXForReset)
		{
			transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
		}
	}
}