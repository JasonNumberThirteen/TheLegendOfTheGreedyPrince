using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
	public UnityEvent<int, int> scoreChangedEvent;

	private int currentScore;

	public void ChangeScoreBy(int points)
	{
		currentScore += points;

		scoreChangedEvent?.Invoke(currentScore, points);
	}

	public int GetCurrentScore()
	{
		return currentScore;
	}
}