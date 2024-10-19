using UnityEngine;

public class MusicControl : MonoBehaviour
{
	private static MusicControl instance;

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