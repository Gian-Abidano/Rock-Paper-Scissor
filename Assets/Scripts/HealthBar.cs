using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    public Image image;

    public void UpdateBar(float fillAmount)
    {
        image.DOFillAmount(fillAmount,0.5f);
        Debug.Log("1");
        if (fillAmount>0.5)
        {
            image.DOColor(Color.green,0.5f);
        }
        else if (fillAmount>0.25)
        {
            image.DOColor(Color.yellow,0.5f);
        }
        else
        {
            image.DOColor(Color.red,0.5f);
        }
        Debug.Log("2");
    }
}
