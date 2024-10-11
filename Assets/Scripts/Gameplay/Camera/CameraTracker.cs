using UnityEngine;

public class CameraTracker : MonoBehaviour
{
	[SerializeField] private GameObject targetGO;
	[SerializeField] private Vector2 offsetFromTargetGO;

	private float initialZ;

	private void Awake()
	{
		initialZ = transform.position.z;
	}

	private void LateUpdate()
	{
		if(targetGO != null)
		{
			transform.position = CameraPosition();
		}
	}

	private Vector3 CameraPosition()
	{
		var x = targetGO.transform.position.x + offsetFromTargetGO.x;
		var y = targetGO.transform.position.y + offsetFromTargetGO.y;

		return new Vector3(x, y, initialZ);
	}
}