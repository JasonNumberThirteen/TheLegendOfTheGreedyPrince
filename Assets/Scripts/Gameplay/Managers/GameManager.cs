using UnityEngine;

public class GameManager : MonoBehaviour
{
	private PlayerDeath playerDeath;

	private void Awake()
	{
		playerDeath = FindObjectOfType<PlayerDeath>();

		if(playerDeath != null)
		{
			playerDeath.playerDiedEvent.AddListener(OnPlayerDied);
		}
	}

	private void OnDestroy()
	{
		if(playerDeath != null)
		{
			playerDeath.playerDiedEvent.RemoveListener(OnPlayerDied);
		}
	}

	private void OnPlayerDied()
	{
		DestroyAllComponentsOfType<ObjectMovement>();
		DestroyAllComponentsOfType<ObjectsSpawner>();
		DestroyAllComponentsOfType<PlatformSpawner>();
		DestroyAllComponentsOfType<Animator>();
		DestroyAllComponentsOfType<DuckMovement>();
		DestroyAllComponentsOfType<ObjectTimedDestructor>();
	}

	private void DestroyAllComponentsOfType<T>() where T : Component
	{
		var components = FindObjectsOfType<T>();

		foreach (var component in components)
		{
			Destroy(component);
		}
	}
}