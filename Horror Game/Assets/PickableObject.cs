using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public string itemName;
    public int itemTypeID;
    public Vector3 pickedPosition;
    public Quaternion pickedRotation;
    public AudioSource audioSource;


    private AudioClip audioClip;
    private float audioLevel;

    void Start()
    {
        audioClip = Resources.Load("bottle_drop") as AudioClip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioLevel = collision.relativeVelocity.magnitude / 15.0f;
        audioSource.PlayOneShot(audioClip, audioLevel);
    }
}
