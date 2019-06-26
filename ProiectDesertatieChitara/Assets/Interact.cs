using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Color defaultColor;
    public Color selectedColor;
    private Image sprite;

    private Vector2 oldPosition;
    private float speed = 0.5f;

    private void Start()
    {
        sprite = GetComponent<Image>();
    }

    private void OnTouchDown(Vector2 point)
    {
        sprite.color = selectedColor;
        oldPosition = point;
    }

    private void OnTouchUp()
    {
        sprite.color = defaultColor;
    }

    private void OnTouchStay( Vector2 point )
    {
        sprite.color = selectedColor;

        transform.localPosition += new Vector3(transform.localPosition.x + (oldPosition.x - point.x)*speed, transform.localPosition.y + (oldPosition.y - point.y) * speed, transform.localPosition.z);
        oldPosition = point;
    }

    private void OnTouchExit()
    {
        sprite.color = defaultColor;
    }
}