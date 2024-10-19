using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
	[SerializeField] private AudioClip mainMenuMusic;
	[SerializeField] private AudioClip gameplayMusic;
	
	private static MusicManager instance;

	private AudioSource audioSource;

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

		audioSource = GetComponent<AudioSource>();

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		switch (scene.name)
		{
			case "MainMenuScene":
				PlayMusic(mainMenuMusic);
				break;

			case "GameplayScene":
				PlayMusic(gameplayMusic);
				break;
		}
	}

	private void PlayMusic(AudioClip audioClip)
	{
		if(audioClip != null && audioSource.clip != audioClip)
		{
			audioSource.clip = audioClip;
			
			audioSource.Play();
		}
	}
}