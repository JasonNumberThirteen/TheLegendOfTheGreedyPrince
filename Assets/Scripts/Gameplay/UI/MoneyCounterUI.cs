using TMPro;
using UnityEngine;

public class MoneyCounterUI : MonoBehaviour
{
	private PlayerMoney playerMoney;
	private TMP_Text counterText;

	private void Awake()
	{
		playerMoney = FindObjectOfType<PlayerMoney>();
		counterText = GetComponent<TMP_Text>();

		if(playerMoney != null)
		{
			playerMoney.moneyChangedEvent.AddListener(OnMoneyChanged);
		}
	}

	private void Start()
	{
		UpdateCounterText();
	}

	private void OnDestroy()
	{
		if(playerMoney != null)
		{
			playerMoney.moneyChangedEvent.RemoveListener(OnMoneyChanged);
		}
	}

	private void OnMoneyChanged(int currentMoney, int collectedMoney)
	{
		UpdateCounterText();
	}

	private void UpdateCounterText()
	{
		if(counterText != null && playerMoney != null)
		{
			counterText.text = playerMoney.GetCurrentMoney().ToString();
		}
	}
}