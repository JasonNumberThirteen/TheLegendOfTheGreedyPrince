using UnityEngine;

public class MusicManager : MonoBehaviour
{
	private static MusicManager instance;

	private void Awake()
	{
		DontDestroyOnLoad(this);

		if(instance == null)
		{
			instance = this;
		}
		else if(instance != null)
		{
			Destroy(gameObject);
		}
	}
}