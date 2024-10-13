using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
	public UnityEvent<int, int> playerTookDamageEvent;
	public UnityEvent<int, int> playerHealedEvent;

	[SerializeField, Min(1)] private int healthPoints = 3;
	[SerializeField, Range(1, 8)] private int maxHealthPoints = 8;
	
	private PlayerInvincibility playerInvincibility;
	private int currentHealthPoints;

	public void HealBy(int points)
	{
		currentHealthPoints = Mathf.Clamp(currentHealthPoints  + points, currentHealthPoints, maxHealthPoints);

		playerHealedEvent?.Invoke(currentHealthPoints, points);
	}

	public void TakeDamage(int damage)
	{
		if(playerInvincibility != null && playerInvincibility.IsInvincible())
		{
			return;
		}
		
		currentHealthPoints -= damage;

		playerTookDamageEvent?.Invoke(currentHealthPoints, damage);
	}

	public int GetCurrentHealthPoints()
	{
		return currentHealthPoints;
	}

	private void Awake()
	{
		playerInvincibility = GetComponent<PlayerInvincibility>();
		currentHealthPoints = Mathf.Clamp(healthPoints, 1, maxHealthPoints);
	}
}