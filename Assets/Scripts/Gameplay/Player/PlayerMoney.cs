using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
	public UnityEvent<int, int> moneyChangedEvent;
	
	private int currentMoney;

	public void ChangeMoneyBy(int money)
	{
		currentMoney += money;

		moneyChangedEvent?.Invoke(currentMoney, money);
	}

	public int GetCurrentMoney()
	{
		return currentMoney;
	}
}