using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarSympathy : MonoBehaviour
{
    [SerializeField] int minimum;
    [SerializeField] int maximum;
    [SerializeField] public int current;
    [SerializeField] Image mask;
    [SerializeField] Image fill;
    [SerializeField] Color color;

    private PlayerSympathy playerSympathy;
   
    private void Awake()
	{
		playerSympathy = FindObjectOfType<PlayerSympathy>();
		current = playerSympathy.GetCurrentSympathy();

		if(playerSympathy != null)
		{
			playerSympathy.sympathyChangedEvent.AddListener(OnSympathyChanged);
		}
	}
    
    private void OnDestroy()
	{
		if(playerSympathy != null)
		{
			playerSympathy.sympathyChangedEvent.RemoveListener(OnSympathyChanged);
		}
	}

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        
    }

    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
        fill.color = color;
    }


    private void OnSympathyChanged(int currentSympathy, int collectedSympathy)
	{
		UpdateProgressSympathy(currentSympathy);
        
	}

	private void UpdateProgressSympathy(int currentSympathy)
	{
		if(playerSympathy != null)
		{
			current = currentSympathy;
		}
	}
}
