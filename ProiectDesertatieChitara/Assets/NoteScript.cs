using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoteScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pressedDown = false;
    private Vector2 FirstPosition;
    private AudioSource stringSource;
    private AudioClip Clip;
    private ChordScript chordScript;
    private float bendProcent;

    private Vector3 _startPosition;
    private Vector3 _offsetToMouse;
    private float _zDistanceToCamera;

    // Start is called before the first frame update
    private void Start()
    {
        stringSource = transform.parent.GetComponent<AudioSource>();
        chordScript = transform.parent.GetComponent<ChordScript>();
        FirstPosition = this.gameObject.transform.localPosition;
    }

    public void SetAudioClip(string ChordName)
    {
        Clip = Resources.Load<AudioClip>(Paths.NOTE_PATH + ChordName);
    }

    // Update is called once per frame
    private void Update()
    {
        //var tapCount = Input.touchCount;
        //if (pressedDown && tapCount > 0)
        //{
        //    this.gameObject.transform.localPosition = Input.touches[0].position;
        //}
        if (pressedDown)
        {
            transform.position = Camera.main.ScreenToWorldPoint(
             new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
             ) + _offsetToMouse;
            Vector3 point = Input.mousePosition;
            //if (Mathf.Abs(FirstPosition.y - point.y) < 75)
            //    this.gameObject.transform.localPosition = new Vector2(FirstPosition.x, point.y);

            Debug.Log(point.x + " " + point.y);
            stringSource.pitch = 1 + (0.01f * Mathf.Lerp(0, 75, Mathf.Abs(Mathf.Abs(FirstPosition.y - point.y))));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        chordScript.NotePressed();
        //stringSource.pitch = 1;
        pressedDown = true;
        stringSource.Stop();
        stringSource.clip = Clip;
        stringSource.Play();

        _startPosition = transform.position;

        _zDistanceToCamera = Mathf.Abs(_startPosition.z - Camera.main.transform.position.z);

        _offsetToMouse = _startPosition - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
        );

        Debug.Log("ASSERT Button Pressed!" + Time.time);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        chordScript.NoteRelesed();
        pressedDown = false;
        this.gameObject.transform.localPosition = FirstPosition;
    }
}