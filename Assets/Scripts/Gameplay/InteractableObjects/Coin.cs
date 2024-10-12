using UnityEngine;

public class Coin : MonoBehaviour, IClickableByPlayer
{
<<<<<<< Updated upstream
	[SerializeField, Min(0)] private int worth = 100;
	[SerializeField] private GameObject particleGO;
=======
	[SerializeField, Min(0)] private int worth = 10;
>>>>>>> Stashed changes
	
	public void OnClickByPlayer(GameObject sender, GameObject receiver)
	{
		if(sender.TryGetComponent(out PlayerMoney playerMoney))
		{
			playerMoney.ChangeMoneyBy(worth);

			if(particleGO != null)
			{
				Instantiate(particleGO, transform.position, Quaternion.identity);
			}

			Destroy(gameObject);
		}
	}
}