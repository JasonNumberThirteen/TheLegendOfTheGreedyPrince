using UnityEngine;

[RequireComponent(typeof(Timer))]
public class ObjectsSpawner : MonoBehaviour
{
	[SerializeField] private GameObject gameObjectPrefab;
	[SerializeField] private GameObject playerGO;
	[SerializeField] private float offsetFromPlayer = 50f;
	
	private Timer timer;

	private void Awake()
	{
		timer = GetComponent<Timer>();

		timer.timeElapsedEvent.AddListener(OnTimeElapsed);
	}

	private void OnDestroy()
	{
		timer.timeElapsedEvent.RemoveListener(OnTimeElapsed);
	}

	private void OnTimeElapsed()
	{
		if(gameObjectPrefab != null && playerGO != null)
		{
			Instantiate(gameObjectPrefab, SpawnedGOPosition(), Quaternion.identity);
		}
	}

	private Vector2 SpawnedGOPosition()
	{
		var x = playerGO != null ? playerGO.transform.position.x + offsetFromPlayer : transform.position.x;
		
		return new Vector2(x, 10f);
	}
}