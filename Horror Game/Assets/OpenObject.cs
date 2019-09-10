using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObject : MonoBehaviour
{
    public bool isOpen = false;
    public int type = -1; // 0 - classic door
                          // 1 - drawer

    public bool isLocked = false;

    private Animator animator;
    private AudioSource audioSource;
    private AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
    }

    public void ChangeState()
    {
        if(isLocked == false)
        {
            isOpen = !isOpen;
            animator.SetBool("open", isOpen);
        }


        if(type != -1)
        {
            if(type == 0)
            {
                if (isLocked)
                {
                    audioClip = Resources.Load("locked_door") as AudioClip;
                }
                else
                {
                    if (isOpen == true)
                        audioClip = Resources.Load("door_open_noise") as AudioClip;
                    else
                        audioClip = Resources.Load("close_door_sound") as AudioClip;
                }
            }else if(type == 1)
            {
                if (isOpen == true)
                    audioClip = Resources.Load("drawer_open") as AudioClip;
                else
                    audioClip = Resources.Load("drawer_close") as AudioClip;
            }


            audioSource.PlayOneShot(audioClip);
        }
    }
}
