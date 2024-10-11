using UnityEngine;

public class Coin : MonoBehaviour, IClickableByPlayer
{
	public void OnClickByPlayer(GameObject sender, GameObject receiver)
	{
		if(sender.TryGetComponent(out PlayerMoney playerMoney))
		{
			playerMoney.ChangeMoneyBy(100);
			Destroy(gameObject);
		}
	}
}