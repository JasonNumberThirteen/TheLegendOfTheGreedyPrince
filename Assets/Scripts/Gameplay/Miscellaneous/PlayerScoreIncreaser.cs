using UnityEngine;

[RequireComponent(typeof(Timer))]
public class PlayerScoreIncreaser : MonoBehaviour
{
	[SerializeField, Min(1)] private int initialPointsPerElapsedTime = 10;
	
	private Timer timer;
	private PlayerScore playerScore;
	private PlayerDeath playerDeath;
	private DifficultyManager difficultyManager;

	private int pointsPerElapsedTime;

	private void Awake()
	{
		timer = GetComponent<Timer>();
		playerScore = FindObjectOfType<PlayerScore>();
		playerDeath = FindObjectOfType<PlayerDeath>();
		difficultyManager = FindObjectOfType<DifficultyManager>();
		pointsPerElapsedTime = initialPointsPerElapsedTime;

		if(playerDeath != null)
		{
			playerDeath.playerDiedEvent.AddListener(OnPlayerDied);
		}

		if(difficultyManager != null)
		{
			difficultyManager.difficultyIncreasedEvent.AddListener(OnDifficultyIncreased);
		}

		timer.timeElapsedEvent.AddListener(OnTimeElapsed);
	}

	private void OnDestroy()
	{
		timer.timeElapsedEvent.RemoveListener(OnTimeElapsed);

		if(playerDeath != null)
		{
			playerDeath.playerDiedEvent.RemoveListener(OnPlayerDied);
		}

		if(difficultyManager != null)
		{
			difficultyManager.difficultyIncreasedEvent.RemoveListener(OnDifficultyIncreased);
		}
	}

	private void OnTimeElapsed()
	{
		if(playerScore != null)
		{
			playerScore.ChangeScoreBy(pointsPerElapsedTime);
		}
	}

	private void OnPlayerDied()
	{
		Destroy(gameObject);
	}

	private void OnDifficultyIncreased(int currentDifficulty)
	{
		pointsPerElapsedTime += initialPointsPerElapsedTime;
	}
}