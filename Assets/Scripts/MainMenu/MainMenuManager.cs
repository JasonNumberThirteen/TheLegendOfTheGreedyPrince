using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] private GameObject mainMenuPanelUI;
	[SerializeField] private GameObject authorsPanelUI;

	public void SetMainMenuPanelUIActive(bool active)
	{
		if(mainMenuPanelUI != null)
		{
			mainMenuPanelUI.SetActive(active);
		}

		if(authorsPanelUI != null)
		{
			authorsPanelUI.SetActive(!active);
		}
	}

	private void Start()
	{
		SetMainMenuPanelUIActive(false);
	}
}