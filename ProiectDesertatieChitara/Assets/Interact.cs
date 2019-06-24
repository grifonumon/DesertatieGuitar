using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Color defaultColor;
    public Color selectedColor;
    private Image sprite;

    private void Start()
    {
        sprite = GetComponent<Image>();
    }

    private void OnTouchDown()
    {
        sprite.color = selectedColor;
    }

    private void OnTouchUp()
    {
        sprite.color = defaultColor;
    }

    private void OnTouchStay()
    {
        sprite.color = selectedColor;
    }

    private void OnTouchExit()
    {
        sprite.color = defaultColor;
    }
}