using UnityEngine;

public class ObjectTimedDestructor : MonoBehaviour
{
	[SerializeField] private float delay;
	
	private void Start()
	{
		Destroy(gameObject, delay);
	}
}