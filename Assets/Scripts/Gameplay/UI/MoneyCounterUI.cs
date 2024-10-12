using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextUIFontSizeIncreaseEffect))]
public class MoneyCounterUI : MonoBehaviour
{
	private PlayerMoney playerMoney;
	private TMP_Text counterText;
	private TextUIFontSizeIncreaseEffect textUIFontSizeIncreaseEffect;

	private void Awake()
	{
		playerMoney = FindObjectOfType<PlayerMoney>();
		counterText = GetComponent<TMP_Text>();
		textUIFontSizeIncreaseEffect = GetComponent<TextUIFontSizeIncreaseEffect>();

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

			textUIFontSizeIncreaseEffect.SetFontSize();
		}
	}
}