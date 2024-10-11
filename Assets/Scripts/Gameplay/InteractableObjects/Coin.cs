using UnityEngine;

public class Coin : MonoBehaviour, IClickableByPlayer
{
	public void OnClickByPlayer(GameObject sender, GameObject receiver)
	{
		Destroy(gameObject);
	}
}