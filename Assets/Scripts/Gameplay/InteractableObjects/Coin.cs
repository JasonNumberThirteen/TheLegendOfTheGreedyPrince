using UnityEngine;

public class Coin : MonoBehaviour, IClickableByPlayer
{
	[SerializeField, Min(0)] private int worth = 100;
	[SerializeField, Min(0)] private int score = 100;
	[SerializeField] private GameObject particleGO;
	
	public void OnClickByPlayer(GameObject sender, GameObject receiver)
	{
		if(sender.TryGetComponent(out PlayerMoney playerMoney))
		{
			playerMoney.ChangeMoneyBy(worth);
		}

		if(sender.TryGetComponent(out PlayerScore playerScore))
		{
			playerScore.ChangeScoreBy(score);
		}

		if(particleGO != null)
		{
			Instantiate(particleGO, transform.position, Quaternion.identity);
		}

		Destroy(gameObject);
	}
}