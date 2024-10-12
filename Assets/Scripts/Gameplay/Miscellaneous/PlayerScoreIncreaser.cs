using UnityEngine;

[RequireComponent(typeof(Timer))]
public class PlayerScoreIncreaser : MonoBehaviour
{
	[SerializeField, Min(1)] private int pointsPerElapsedTime = 10;
	
	private Timer timer;
	private PlayerScore playerScore;

	private void Awake()
	{
		timer = GetComponent<Timer>();
		playerScore = FindObjectOfType<PlayerScore>();

		timer.timeElapsedEvent.AddListener(OnTimeElapsed);
	}

	private void OnDestroy()
	{
		timer.timeElapsedEvent.RemoveListener(OnTimeElapsed);
	}

	private void OnTimeElapsed()
	{
		if(playerScore != null)
		{
			playerScore.ChangeScoreBy(pointsPerElapsedTime);
		}
	}
}