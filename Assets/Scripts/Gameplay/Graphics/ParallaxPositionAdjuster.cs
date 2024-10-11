using UnityEngine;

public class ParallaxPositionAdjuster : MonoBehaviour
{
	[SerializeField] private Camera cameraGO;
	[SerializeField, Min(0f)] private float cameraPositionMultiplier = 1f;

	private void Update()
	{
		if(cameraGO != null)
		{
			transform.position = GameObjectPosition();
		}
	}

	private Vector3 GameObjectPosition()
	{
		var x = cameraGO != null ? cameraGO.transform.position.x*cameraPositionMultiplier : transform.position.x;

		return new Vector3(x, transform.position.y, transform.position.z);
	}
}