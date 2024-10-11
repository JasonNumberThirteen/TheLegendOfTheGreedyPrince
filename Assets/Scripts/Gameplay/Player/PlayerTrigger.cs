using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider2D)
	{
		if(collider2D.TryGetComponent(out ITriggerEnterWithPlayer triggerEnterWithPlayer))
		{
			triggerEnterWithPlayer.OnTriggerEnterWithPlayer(collider2D.gameObject, gameObject);
		}
	}
}