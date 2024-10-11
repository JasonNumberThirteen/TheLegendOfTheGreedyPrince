using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
	public UnityEvent<int, int> playerTookDamageEvent;
	
	[SerializeField, Min(1)] private int healthPoints = 3;
	
	private PlayerInvincibility playerInvincibility;
	private int currentHealthPoints;

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
		currentHealthPoints = healthPoints;
	}
}