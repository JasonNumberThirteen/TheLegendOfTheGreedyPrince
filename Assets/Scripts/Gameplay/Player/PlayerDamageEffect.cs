using UnityEngine;

[RequireComponent(typeof(PlayerHealth), typeof(SpriteRenderer))]
public class PlayerDamageEffect : MonoBehaviour
{
	[SerializeField] private Timer timer;
	[SerializeField, Min(0f)] private float blinkDelay = 0.05f;
	
	private PlayerHealth playerHealth;
	private SpriteRenderer spriteRenderer;

	private bool blinkRenderer;

	private void Awake()
	{
		playerHealth = GetComponent<PlayerHealth>();
		spriteRenderer = GetComponent<SpriteRenderer>();

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

	private void Update()
	{
		if(blinkRenderer)
		{
			spriteRenderer.enabled = Time.time % (blinkDelay*2) >= blinkDelay;
		}
	}

	private void OnPlayerTookDamage(int currentHealthPoints, int damage)
	{
		blinkRenderer = true;
	}

	private void OnTimeElapsed()
	{
		blinkRenderer = false;
	}
}