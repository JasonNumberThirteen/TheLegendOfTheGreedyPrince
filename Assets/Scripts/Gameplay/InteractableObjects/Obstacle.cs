using UnityEngine;

public class Obstacle : MonoBehaviour, ITriggerEnterWithPlayer
{
	[SerializeField, Min(0)] private int damage = 1;
	
	public void OnTriggerEnterWithPlayer(GameObject sender, GameObject receiver)
	{
		if(receiver.TryGetComponent(out PlayerHealth playerHealth))
		{
			playerHealth.TakeDamage(damage);
		}
	}

	private void Awake()
	{
		var difficultyManager = FindObjectOfType<DifficultyManager>();

		if(difficultyManager != null)
		{
			damage = Mathf.CeilToInt(difficultyManager.GetCurrentDifficulty()*0.25f);
		}
	}
}