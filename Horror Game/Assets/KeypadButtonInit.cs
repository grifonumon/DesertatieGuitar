using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButtonInit : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().sharedMaterial.DisableKeyword("_EMISSION");
    }
}
