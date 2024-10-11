using TMPro;
using UnityEngine;

public class LivesCounterUI : MonoBehaviour
{
	private PlayerHealth playerHealth;
	private TMP_Text counterText;

	private void Awake()
	{
		playerHealth = FindObjectOfType<PlayerHealth>();
		counterText = GetComponent<TMP_Text>();

		if(playerHealth != null)
		{
			playerHealth.playerTookDamageEvent.AddListener(OnPlayerTookDamage);
		}
	}

	private void Start()
	{
		UpdateCounterText();
	}

	private void OnDestroy()
	{
		if(playerHealth != null)
		{
			playerHealth.playerTookDamageEvent.RemoveListener(OnPlayerTookDamage);
		}
	}

	private void OnPlayerTookDamage(int leftHealthPoints, int damage)
	{
		UpdateCounterText();
	}

	private void UpdateCounterText()
	{
		if(counterText != null && playerHealth != null)
		{
			counterText.text = playerHealth.GetCurrentHealthPoints().ToString();
		}
	}
}