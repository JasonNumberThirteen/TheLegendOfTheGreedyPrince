using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerDeath : MonoBehaviour
{
	private PlayerHealth playerHealth;

	private void Awake()
	{
		playerHealth = GetComponent<PlayerHealth>();

		playerHealth.playerTookDamageEvent.AddListener(OnPlayerTookDamage);
	}

	private void OnDestroy()
	{
		playerHealth.playerTookDamageEvent.RemoveListener(OnPlayerTookDamage);
	}

	private void OnPlayerTookDamage(int leftHealthPoints)
	{
		if(leftHealthPoints <= 0)
		{
			gameObject.SetActive(false);
		}
	}
}