using UnityEngine;

[RequireComponent(typeof(Timer))]
public class MainMenuManager : MonoBehaviour
{
	[SerializeField] private GameObject mainMenuPanelUI;
	[SerializeField] private GameObject authorsPanelUI;

	private Timer timer;

	public void SetMainMenuPanelUIActive(bool active)
	{
		if(mainMenuPanelUI != null)
		{
			mainMenuPanelUI.SetActive(active);
		}
	}

	public void SetAuthorsPanelUIActive(bool active)
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