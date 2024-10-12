using TMPro;
using UnityEngine;

public class GainedScoreCounterUI : MonoBehaviour
{
	[SerializeField] private PlayerScore playerScore;
	
	private TMP_Text counterText;

	private void Awake()
	{
		counterText = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		UpdateCounterText();
	}

	private void UpdateCounterText()
	{
		if(counterText != null && playerScore != null)
		{
			counterText.text = $"Zdobyte punkty: {playerScore.GetCurrentScore()}";
		}
	}
}