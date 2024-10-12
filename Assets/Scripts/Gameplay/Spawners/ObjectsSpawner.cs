using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Timer))]
public class ObjectsSpawner : MonoBehaviour
{
	[SerializeField] private GameObject gameObjectPrefab;
	[SerializeField] private GameObject parentGO;
	[SerializeField] private float offsetXFromParent = 50f;
	[SerializeField] private float spawnedObjectsY;

	public UnityEvent objectSpawnedEvent;
	
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
		if(gameObjectPrefab != null && parentGO != null)
		{
			Instantiate(gameObjectPrefab, SpawnedGOPosition(), Quaternion.identity);
			objectSpawnedEvent?.Invoke();
		}
	}

	private Vector2 SpawnedGOPosition()
	{
		var x = parentGO != null ? parentGO.transform.position.x + offsetXFromParent : transform.position.x;
		
		return new Vector2(x, spawnedObjectsY);
	}
}