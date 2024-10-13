using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Timer))]
public class DifficultyManager : MonoBehaviour
{
	public UnityEvent<int> difficultyIncreasedEvent;
	
	private int currentDifficulty = 1;
	private Timer timer;

	public int GetCurrentDifficulty()
	{
		return currentDifficulty;
	}

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
		IncreaseDifficulty();
	}

	private void IncreaseDifficulty()
	{
		++currentDifficulty;

		difficultyIncreasedEvent?.Invoke(currentDifficulty);
	}
}