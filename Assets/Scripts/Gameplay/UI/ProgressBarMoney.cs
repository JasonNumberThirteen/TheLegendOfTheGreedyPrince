using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarMoney : MonoBehaviour
{
    [SerializeField] int minimum;
    [SerializeField] int maximum;
    [SerializeField] public int current;
    [SerializeField] Image mask;
    [SerializeField] Image fill;
    [SerializeField] Color color;

    private PlayerMoney playerMoney;
   
    private void Awake()
	{
		playerMoney = FindObjectOfType<PlayerMoney>();
		

		if(playerMoney != null)
		{
			playerMoney.moneyChangedEvent.AddListener(OnMoneyChanged);
		}
	}
    

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        Debug.Log(current);
    }

    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
        fill.color = color;
    }


    private void OnMoneyChanged(int currentMoney, int collectedMoney)
	{
		UpdateProgressMoney();
        Debug.Log(current);
	}

	private void UpdateProgressMoney()
	{
		if(playerMoney != null)
		{
			current +=  10;
		}
	}
}
