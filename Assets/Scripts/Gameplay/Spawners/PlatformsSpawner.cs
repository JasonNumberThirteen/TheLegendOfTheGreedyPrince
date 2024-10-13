using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Timer))]
public class PlatformsSpawner : MonoBehaviour
{
	public UnityEvent objectSpawnedEvent;
	
	[SerializeField] private GameObject gameObjectPrefab;
	[SerializeField] private float offsetXPerSpawn = 75f;
	[SerializeField] private float spawnedObjectsY;

	private Timer timer;
	private float currentOffsetX;

	private void Awake()
	{
		timer = GetComponent<Timer>();

		timer.timeElapsedEvent.AddListener(OnTimeElapsed);

		currentOffsetX = offsetXPerSpawn;
	}

	private void OnDestroy()
	{
		timer.timeElapsedEvent.RemoveListener(OnTimeElapsed);
	}

	private void OnTimeElapsed()
	{
		if(gameObjectPrefab != null)
		{
			Instantiate(gameObjectPrefab, SpawnedGOPosition(), Quaternion.identity);

			currentOffsetX += offsetXPerSpawn;

			objectSpawnedEvent?.Invoke();
		}
	}

	private Vector2 SpawnedGOPosition()
	{
		return new Vector2(currentOffsetX, spawnedObjectsY);
	}
}