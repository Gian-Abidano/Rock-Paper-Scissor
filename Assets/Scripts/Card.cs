using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Attack attackValue;
    public Player player;
    public Vector2 firstCardPosition;
    Vector2 originalScale;
    Color originalColor;
    bool isClickable = true;

    // Start is called before the first frame update
    private void Start()
    {
        firstCardPosition = this.transform.position;
        originalScale = this.transform.localScale;
        originalColor = GetComponent<Image>().color;
    }

    public void OnClick()
    {
        player.SetChosenCard(this);
    }

    internal void Reset()
    {
        transform.position = firstCardPosition;
        transform.localScale = originalScale;
    }

    internal void SetClickable(bool value)
    {
        isClickable = value;
    }
}
