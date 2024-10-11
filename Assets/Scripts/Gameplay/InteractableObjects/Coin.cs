using UnityEngine;

public class Coin : MonoBehaviour, IClickableByPlayer
{
	[SerializeField, Min(0)] private int worth = 100;
	
	public void OnClickByPlayer(GameObject sender, GameObject receiver)
	{
		if(sender.TryGetComponent(out PlayerMoney playerMoney))
		{
			playerMoney.ChangeMoneyBy(worth);
			Destroy(gameObject);
		}
	}
}