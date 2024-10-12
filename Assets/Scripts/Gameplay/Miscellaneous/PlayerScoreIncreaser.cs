using UnityEngine;

[RequireComponent(typeof(Timer))]
public class PlayerScoreIncreaser : MonoBehaviour
{
	[SerializeField, Min(1)] private int pointsPerElapsedTime = 10;
	
	private Timer timer;
	private PlayerScore playerScore;
	private PlayerDeath playerDeath;

	private void Awake()
	{
		timer = GetComponent<Timer>();
		playerScore = FindObjectOfType<PlayerScore>();
		playerDeath = FindObjectOfType<PlayerDeath>();

		if(playerDeath != null)
		{
			playerDeath.playerDiedEvent.AddListener(OnPlayerDied);
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
}