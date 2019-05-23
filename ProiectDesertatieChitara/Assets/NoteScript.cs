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

    // Start is called before the first frame update
    private void Start()
    {
        stringSource = transform.parent.GetComponent<AudioSource>();
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
        //if (pressedDown)
        //{
        //    Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    point.y = Mathf.Clamp(point.y * 3, -40f, 40f);
        //    this.gameObject.transform.localPosition = new Vector2(FirstPosition.x, point.y);
        //    Debug.Log(point.y);
        //    stringSource.pitch = point.y / 40f;
        //}
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        stringSource.pitch = 1;
        pressedDown = true;
        stringSource.Stop();
        stringSource.clip = Clip;
        stringSource.Play();

        Debug.Log("ASSERT Button Pressed!" + Time.time);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stringSource.Stop();
        pressedDown = false;
        this.gameObject.transform.localPosition = FirstPosition;
    }
}