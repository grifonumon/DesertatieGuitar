using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimation : MonoBehaviour
{
    public Animation anim;
    public Vector3 lastPosition;
    public NavMeshAgent nma;

    private void Update()
    {
        if (nma.velocity.magnitude == 0f)
        {
            anim.CrossFade("Idle");
        }

        if(nma.velocity.magnitude > 0f)
        {
            anim["Walk"].speed = nma.velocity.magnitude * 1.6f;
            anim.CrossFade("Walk");
        }
    }
}