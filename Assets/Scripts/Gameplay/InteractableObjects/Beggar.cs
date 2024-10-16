using UnityEngine;

public class Beggar : MonoBehaviour, IClickableByPlayer
{
	[SerializeField] private int cost = 1;
	[SerializeField, Min(0)] private int score = 1000;

	private bool wasReceivedCoin;
	
	public void OnClickByPlayer(GameObject sender, GameObject receiver)
	{
		if(!wasReceivedCoin && sender.TryGetComponent(out PlayerMoney playerMoney) && playerMoney.GetCurrentMoney() >= cost)
		{
			playerMoney.ChangeMoneyBy(-cost);

			if(sender.TryGetComponent(out PlayerHealth playerHealth))
			{
				playerHealth.HealBy(1);
			}

			if(sender.TryGetComponent(out PlayerScore playerScore))
			{
				playerScore.ChangeScoreBy(score);
			}

			wasReceivedCoin = true;
		}
	}

	private void Awake()
	{
		var difficultyManager = FindObjectOfType<DifficultyManager>();

		if(difficultyManager != null)
		{
			cost = Mathf.CeilToInt(difficultyManager.GetCurrentDifficulty()*0.5f);
		}
	}
}