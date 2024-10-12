using UnityEngine;

[RequireComponent(typeof(Timer))]
public class MainMenuManager : MonoBehaviour
{
	[SerializeField] private Transition transition;
	[SerializeField] private GameObject mainMenuPanelUI;
	[SerializeField] private GameObject authorsPanelUI;

	private Timer timer;

	public void OnStartGameButtonClicked()
	{
		if(transition != null)
		{
			transition.NextScene("BackstoryScene");
		}
	}

	public void OnAuthorsButtonClicked()
	{
		SetOnlyMainMenuPanelUIActive(false);
	}

	public void OnBackFromAuthorsButtonClicked()
	{
		SetOnlyMainMenuPanelUIActive(true);
	}

	public void OnQuitButtonClicked()
	{
		Application.Quit();
	}

	private void SetOnlyMainMenuPanelUIActive(bool active)
	{
		SetMainMenuPanelUIActive(active);
		SetAuthorsPanelUIActive(!active);
	}

	private void SetMainMenuPanelUIActive(bool active)
	{
		if(mainMenuPanelUI != null)
		{
			mainMenuPanelUI.SetActive(active);
		}
	}

	private void SetAuthorsPanelUIActive(bool active)
	{
		if(authorsPanelUI != null)
		{
			authorsPanelUI.SetActive(active);
		}
	}

	private void SetBothPanelsActive(bool active)
	{
		SetMainMenuPanelUIActive(active);
		SetAuthorsPanelUIActive(active);
	}

	private void Awake()
	{
		timer = GetComponent<Timer>();

		timer.timeElapsedEvent.AddListener(OnTimeElapsed);
	}

	private void Start()
	{
		SetBothPanelsActive(false);
	}

	private void OnDestroy()
	{
		timer.timeElapsedEvent.RemoveListener(OnTimeElapsed);
	}

	private void OnTimeElapsed()
	{
		SetMainMenuPanelUIActive(true);
	}
}