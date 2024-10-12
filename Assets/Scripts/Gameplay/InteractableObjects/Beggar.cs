using UnityEngine;

public class Beggar : MonoBehaviour, IClickableByPlayer
{
	[SerializeField] private int cost = 1;
	
	public void OnClickByPlayer(GameObject sender, GameObject receiver)
	{
		if(sender.TryGetComponent(out PlayerMoney playerMoney) && playerMoney.GetCurrentMoney() >= cost)
		{
			playerMoney.ChangeMoneyBy(cost);
		}

		if(sender.TryGetComponent(out PlayerHealth playerHealth))
		{
			playerHealth.HealBy(1);
		}
	}
}