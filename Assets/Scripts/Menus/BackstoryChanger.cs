using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackstoryChanger : MonoBehaviour
{
	[SerializeField] private Image storyImageUI;
	[SerializeField] private Sprite[] sprites;
	[SerializeField] private string sceneName;

	private int currentPageIndex = 0;

	public void OnNextPageClicked()
	{
		++currentPageIndex;
		
		UpdateStoryImage();
		
		if(currentPageIndex >= sprites.Length)
		{
			SceneManager.LoadScene(sceneName);
		}
	}

	private void Start()
	{
		UpdateStoryImage();
	}

	private void UpdateStoryImage()
	{
		if(storyImageUI != null && currentPageIndex >= 0 && currentPageIndex < sprites.Length)
		{
			storyImageUI.sprite = sprites[currentPageIndex];
		}
	}
}