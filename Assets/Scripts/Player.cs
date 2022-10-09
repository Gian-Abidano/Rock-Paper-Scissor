using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] Card chosenCard;
    public Transform attackPosReference;
    public TMP_Text healthText;
    public HealthBar healthBar;
    public float health;
    public float maxHealth;
    private Tweener animationTweener;
    public Attack? AttackValue 
    {
        get
        {
            if(chosenCard==null)
                return null;
            else
                return chosenCard.attackValue;
        }
    }
    public void Reset()
    {
        if(chosenCard!=null)
        {
            chosenCard.Reset();
        }

        chosenCard = null;
    }
    public void SetChosenCard(Card newCard)
    {
        if(chosenCard != null)
        {
            chosenCard.Reset();
        }

        chosenCard = newCard;
        chosenCard.transform.DOScale(chosenCard.transform.localScale*1.2f,0.2f);
    }

    public void ChangingHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health,0,100);
        healthBar.UpdateBar(health/maxHealth);
        healthText.text = health + "/" + maxHealth;
    }

    public void AnimateAttack()
    {
        animationTweener = chosenCard.transform.DOMove(attackPosReference.position,1);
    }

    public bool InAnimation()
    {
        return animationTweener.IsActive();
    }

    internal void DamageAnimation()
    {
        var image = chosenCard.GetComponent<Image>();
        animationTweener =  image
            .DOColor(Color.red,0.1f)
            .SetLoops(2,LoopType.Yoyo)
            .SetDelay(0.5f);
    }

    internal void DrawAnimation()
    {
        var image = chosenCard.GetComponent<Image>();
        animationTweener =  image
            .DOColor(Color.blue,0.1f)
            .SetLoops(2,LoopType.Yoyo)
            .SetDelay(0.5f);
        animationTweener = chosenCard.transform
            .DOMove(chosenCard.firstCardPosition,1)
            .SetEase(Ease.InBack)
            .SetDelay(0.2f);
    }

    public void isClickable(bool value)
    {
        Card[] cards = GetComponentsInChildren<Card>();
        foreach (var card in cards)
        {
            card.SetClickable(value);
        }
    }
}
