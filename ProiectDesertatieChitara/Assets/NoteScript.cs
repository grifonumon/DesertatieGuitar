using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private bool mouseDown;
    private AudioSource stringSource; 

    // Start is called before the first frame update
    void Start()
    {
        stringSource = transform.parent.GetComponent<AudioSource>();

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPointerDown()
    {
        mouseDown = true;
    }
    void OnPointerUp()
    {
        mouseDown = false;
    }
}
