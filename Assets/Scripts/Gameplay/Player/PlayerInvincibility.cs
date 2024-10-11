using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerInvincibility : MonoBehaviour
{
	[SerializeField] private Timer timer;
	
	private PlayerHealth playerHealth;

	private bool isInvincible;

	public bool IsInvincible()
	{
		return isInvincible;
	}

	private void Awake()
	{
		playerHealth = GetComponent<PlayerHealth>();

		if(playerHealth != null)
		{
			playerHealth.playerTookDamageEvent.AddListener(OnPlayerTookDamage);
		}

		if(timer != null)
		{
			timer.timeElapsedEvent.AddListener(OnTimeElapsed);
		}
	}

	private void OnDestroy()
	{
		if(playerHealth != null)
		{
			playerHealth.playerTookDamageEvent.RemoveListener(OnPlayerTookDamage);
		}

		if(timer != null)
		{
			timer.timeElapsedEvent.RemoveListener(OnTimeElapsed);
		}
	}

	private void OnPlayerTookDamage(int currentHealthPoints, int damage)
	{
		isInvincible = true;

		if(timer != null)
		{
			timer.Reset();
		}
	}

	private void OnTimeElapsed()
	{
		isInvincible = false;
	}
}