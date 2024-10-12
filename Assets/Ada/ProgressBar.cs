using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] int minimum;
    [SerializeField] int maximum;
    [SerializeField] int current;
    [SerializeField] Image mask;
    [SerializeField] Image fill;
    [SerializeField] Color color;
   
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
}
