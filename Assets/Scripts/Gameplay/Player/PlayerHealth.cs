using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
	public UnityEvent<int, int> playerTookDamageEvent;
	
	[SerializeField, Min(1)] private int healthPoints = 3;

	private int currentHealthPoints;

	public void TakeDamage(int damage)
	{
		currentHealthPoints -= damage;

		playerTookDamageEvent?.Invoke(currentHealthPoints, damage);
	}

	private void Start()
	{
		currentHealthPoints = healthPoints;
	}
}