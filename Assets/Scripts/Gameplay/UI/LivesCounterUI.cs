using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class LivesCounterUI : MonoBehaviour
{
	[SerializeField, Min(0)] private int spriteWidth = 64;
	
	private PlayerHealth playerHealth;
	private RectTransform rectTransform;

	private void Awake()
	{
		playerHealth = FindObjectOfType<PlayerHealth>();
		rectTransform = GetComponent<RectTransform>();

		if(playerHealth != null)
		{
			playerHealth.playerTookDamageEvent.AddListener(OnPlayerTookDamage);
			playerHealth.playerHealedEvent.AddListener(OnPlayerHealed);
		}
	}

	private void Start()
	{
		UpdateRectTransformSize();
	}

	private void OnDestroy()
	{
		if(playerHealth != null)
		{
			playerHealth.playerTookDamageEvent.RemoveListener(OnPlayerTookDamage);
			playerHealth.playerHealedEvent.RemoveListener(OnPlayerHealed);
		}
	}

	private void OnPlayerTookDamage(int leftHealthPoints, int damage)
	{
		UpdateRectTransformSize();
	}

	private void OnPlayerHealed(int leftHealthPoints, int healedPoints)
	{
		UpdateRectTransformSize();
	}

	private void UpdateRectTransformSize()
	{
		if(playerHealth != null)
		{
			rectTransform.sizeDelta = new Vector2(playerHealth.GetCurrentHealthPoints()*spriteWidth, spriteWidth);
		}
	}
}