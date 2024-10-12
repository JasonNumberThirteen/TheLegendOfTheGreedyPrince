using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    
    [SerializeField] private Transition transition;
    [SerializeField] private GameObject GameOverPanelUI;
    
    
    public void OnExitGameButtonClicked()
	{
		if(transition != null)
		{
			transition.LoadSceneWithName("MainMenuScene");
		}
	}

    public void OnStartAgainGameButtonClicked()
	{
		if(transition != null)
		{
			transition.LoadSceneWithName("GameplayScene");
		}
	}

    public void onDeath(){
        GameOverPanelUI.SetActive(true);
    }
}
