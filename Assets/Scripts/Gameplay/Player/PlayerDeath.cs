using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider2D)
	{
		gameObject.SetActive(false);
	}
}