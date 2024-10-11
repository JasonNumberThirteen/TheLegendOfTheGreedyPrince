using UnityEngine;

public class Obstacle : MonoBehaviour, ITriggerEnterWithPlayer
{
	public void OnTriggerEnterWithPlayer(GameObject sender, GameObject receiver)
	{
		if(receiver.TryGetComponent(out PlayerHealth playerHealth))
		{
			playerHealth.TakeDamage(1);
		}
	}
}