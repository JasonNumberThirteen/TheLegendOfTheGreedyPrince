using UnityEngine;

public class Beggar : MonoBehaviour, IClickableByPlayer
{
	[SerializeField] private int cost = 1;
	
	public void OnClickByPlayer(GameObject sender, GameObject receiver)
	{
		if(sender.TryGetComponent(out PlayerMoney playerMoney) && sender.TryGetComponent(out PlayerHealth playerHealth) && playerMoney.GetCurrentMoney() >= cost)
		{
			playerMoney.ChangeMoneyBy(cost);
			playerHealth.HealBy(1);
		}
	}
}