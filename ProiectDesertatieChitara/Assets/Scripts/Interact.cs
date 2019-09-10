using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Interact : MonoBehaviour
{
    private Image sprite;

    private Vector2 oldPosition;
    private float speed = 0.3f;
    private Vector2 _startPosition;
    private Vector2 _offsetToMouse;
    private Transform viewPoint;
    private const float MAX_BEND = 120;

    public UILineRenderer Chord;

    private void Start()
    {
        sprite = GetComponent<Image>();
        viewPoint = transform.GetChild(0);
        _startPosition = transform.position;
    }

    private void OnTouchDown(Vector2 point)
    {
        oldPosition = point;

        _offsetToMouse = _startPosition - point;
        Chord.Points[2].x = transform.localPosition.x;
    }

    private void OnTouchUp()
    {
        transform.position = _startPosition;
        viewPoint.localPosition = Vector2.zero;
        Chord.Points[2].y = 0;
        Chord.SetAllDirty();
    }

    private void OnTouchStay(Vector2 point)
    {
        transform.position = point + _offsetToMouse;
        viewPoint.position = new Vector2(_startPosition.x, transform.position.y);
        if (_startPosition.y - MAX_BEND >= point.y + _offsetToMouse.y)
            viewPoint.position = new Vector2(_startPosition.x, _startPosition.y - MAX_BEND);
        if (_startPosition.y + MAX_BEND <= point.y + _offsetToMouse.y)
            viewPoint.position = new Vector2(_startPosition.x, _startPosition.y + MAX_BEND);

        Chord.Points[2].y = transform.localPosition.y;
        Chord.SetAllDirty();
        //if (_startPosition - MAX_BEND <= point.y + _offsetToMouse && _startPosition + MAX_BEND >= point.y + _offsetToMouse)
        //    transform.position = new Vector2(transform.position.x, point.y + _offsetToMouse);
    }

    private void OnTouchExit()
    {
        transform.position = _startPosition;
        viewPoint.localPosition = Vector2.zero;
    }
}