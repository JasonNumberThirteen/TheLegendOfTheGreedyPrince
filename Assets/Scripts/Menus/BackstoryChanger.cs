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
		
		if(storyImageUI != null && currentPageIndex < sprites.Length)
		{
			storyImageUI.sprite = sprites[currentPageIndex];
		}
		
		if(currentPageIndex >= sprites.Length)
		{
			SceneManager.LoadScene(sceneName);
		}
	}
}