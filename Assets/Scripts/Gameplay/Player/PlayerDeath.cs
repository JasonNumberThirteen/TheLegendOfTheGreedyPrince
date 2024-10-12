using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerDeath : MonoBehaviour
{
	public UnityEvent playerDiedEvent;
	
	private PlayerHealth playerHealth;

	private void Awake()
	{
		playerHealth = GetComponent<PlayerHealth>();

		playerHealth.playerTookDamageEvent.AddListener(OnPlayerTookDamage);
	}

	private void Update(){
		if(transform.position.y < -15){
			gameObject.SetActive(false);
			playerDiedEvent?.Invoke();
		}
		
	}

	private void OnDestroy()
	{
		playerHealth.playerTookDamageEvent.RemoveListener(OnPlayerTookDamage);
	}

	private void OnPlayerTookDamage(int leftHealthPoints, int damage)
	{
		if(leftHealthPoints <= 0)
		{
			gameObject.SetActive(false);
			playerDiedEvent?.Invoke();
		}
	}
}