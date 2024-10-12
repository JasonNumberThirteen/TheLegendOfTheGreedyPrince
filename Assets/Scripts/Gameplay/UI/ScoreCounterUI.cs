using TMPro;
using UnityEngine;

public class ScoreCounterUI : MonoBehaviour
{
	private PlayerScore playerScore;
	private TMP_Text counterText;

	private void Awake()
	{
		playerScore = FindObjectOfType<PlayerScore>();
		counterText = GetComponent<TMP_Text>();

		if(playerScore != null)
		{
			playerScore.scoreChangedEvent.AddListener(OnScoreChanged);
		}
	}

	private void OnDestroy()
	{
		if(playerScore != null)
		{
			playerScore.scoreChangedEvent.RemoveListener(OnScoreChanged);
		}
	}

	private void Start()
	{
		UpdateCounterText();
	}

	private void OnScoreChanged(int currentScore, int gainedPoints)
	{
		UpdateCounterText();
	}

	private void UpdateCounterText()
	{
		if(counterText != null && playerScore != null)
		{
			counterText.text = playerScore.GetCurrentScore().ToString("D6");
		}
	}
}