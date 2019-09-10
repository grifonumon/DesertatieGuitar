using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class CodeLock : MonoBehaviour
    
{
    [Header("Attatch player Camera")]
    public Camera cam;
    [Header("Select gameobject with Animator for the door animation")]
    public ExitDoorPuzzle exitDoor;

    private string code = "";
    private string codeRecent = "";
    private TextMeshPro codeText;
    [Header("This button order is very important")]

    [Space(20)]
    public GameObject [] codeButtons;

    [Header("Animated Buttons")]
    [Space(20)]
    public bool animatedClick = true;

    [Header("0 = Click, 1 = Denied, 2 = Granted")]
    [Space(20)]
    public AudioSource[] sound;

    [Header("Maximum interacting distance")]
    [Space(20)]
    public float dist = 0.6f;

    private int passwordLenght = 5;

    [Header("Choose your password")]
    [Space(20)]
    public string password;

    [Header("Acces granted/denied lights")]
    [Space(20)]
    public Texture [] glow;
    private Material mat;
    private Renderer rend;

    [Header("Timer before door close")]
    [Header("0 = No timer")]
    [Space(20)]
    public float timer;

    public bool isActive = false;
    private float timerClose;

    private bool open;

    

    // Start is called before the first frame update
    void Start()
    {
        timerClose = timer;
        rend = gameObject.GetComponent<Renderer>();
        mat = rend.material;
        codeText = codeButtons[11].GetComponent<TextMeshPro>();
        codeText.text = "";

        //Dezactivate 
        GetComponent<Renderer>().sharedMaterial.DisableKeyword("_EMISSION");
    }


    void DeActivate()
    {
        code = "";
        codeText.text = code;
        open = false;
        if (glow.Length > 0)
            mat.SetTexture("_EmissionMap", glow[0]);
    }


    public void ChangeState()
    {
        this.GetComponent<Renderer>().sharedMaterial.EnableKeyword("_EMISSION");

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("KeypadButtons"))
        {
            g.GetComponent<Renderer>().sharedMaterial.EnableKeyword("_EMISSION");
        }
        this.gameObject.tag = "Keypad";
        isActive = true;
    }

    public void PressButton()
    {

        if (cam != null && isActive == true)
        {

            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;



            //Reset, clear password
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[0] && hit.distance <= dist)
            {
                if (open)
                {
                    code = "";
                    codeText.text = code;
                    open = false;
                }
                code = "";
                codeText.text = code;
                if (glow.Length > 0)
                    mat.SetTexture("_EmissionMap", glow[0]);
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[0].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }


            }


            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[1] && hit.distance <= dist)
            {
                if (code.Length < passwordLenght && codeText.text != "error")
                {
                    if (open)
                    {
                        code = "";
                        codeText.text = code;
                        open = false;
                    }

                    code += "1";
                    codeText.text = code;
                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[0]);
                }
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[1].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[2] && hit.distance <= dist)
            {
                if (code.Length < passwordLenght && codeText.text != "error")
                {
                    if (open)
                    {
                        code = "";
                        codeText.text = code;
                        open = false;
                    }
                    else
                    {
                        code += "2";
                        codeText.text = code;
                    }

                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[0]);
                }
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[2].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[3] && hit.distance <= dist)
            {
                if (code.Length < passwordLenght && codeText.text != "error")
                {
                    if (open)
                    {
                        code = "";
                        codeText.text = code;
                        open = false;
                    }
                    else
                    {
                        code += "3";
                        codeText.text = code;
                    }

                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[0]);
                }
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[3].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[4] && hit.distance <= dist)
            {
                if (code.Length < passwordLenght && codeText.text != "error")
                {
                    if (open)
                    {
                        code = "";
                        codeText.text = code;
                        open = false;
                    }
                    else
                    {
                        code += "4";
                        codeText.text = code;
                    }

                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[0]);
                }
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[4].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[5] && hit.distance <= dist)
            {
                if (code.Length < passwordLenght && codeText.text != "error")
                {
                    if (open)
                    {
                        code = "";
                        codeText.text = code;
                        open = false;
                    }
                    else
                    {
                        code += "5";
                        codeText.text = code;
                    }

                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[0]);
                }
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[5].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[6] && hit.distance <= dist)
            {
                if (code.Length < passwordLenght && codeText.text != "error")
                {
                    if (open)
                    {
                        code = "";
                        codeText.text = code;
                        open = false;
                    }
                    else
                    {
                        code += "6";
                        codeText.text = code;
                    }

                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[0]);
                }
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[6].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[7] && hit.distance <= dist)
            {
                if (code.Length < passwordLenght && codeText.text != "error")
                {
                    if (open)
                    {
                        code = "";
                        codeText.text = code;
                        open = false;
                    }
                    else
                    {
                        code += "7";
                        codeText.text = code;
                    }

                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[0]);
                }
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[7].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[8] && hit.distance <= dist)
            {
                if (code.Length < passwordLenght && codeText.text != "error")
                {
                    if (open)
                    {
                        code = "";
                        codeText.text = code;
                        open = false;
                    }
                    else
                    {
                        code += "8";
                        codeText.text = code;
                    }

                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[0]);
                }
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[8].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[9] && hit.distance <= dist)
            {
                if (code.Length < passwordLenght && codeText.text != "error")
                {
                    if (open)
                    {
                        code = "";
                        codeText.text = code;
                        open = false;
                    }
                    else
                    {
                        code += "9";
                        codeText.text = code;
                    }

                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[0]);
                }
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[9].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }

            //Enter code
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == codeButtons[10] && hit.distance <= dist)
            {
                if (codeText.text == password)
                {
                    exitDoor.UnlockPuzzle(0);
                    if (sound.Length > 0)
                        sound[2].Play();
                    codeText.text = "88888";
                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[1]);
                }
                else
                {
                    open = false;
                    if (sound.Length > 0)
                        sound[1].Play();
                    codeText.text = "error";
                    if (glow.Length > 0)
                        mat.SetTexture("_EmissionMap", glow[2]);
                }
                if (sound.Length > 0 && !sound[0].isPlaying)
                    sound[0].Play();

                if (animatedClick)
                {
                    Animator anim = codeButtons[10].GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }

        }
        else
        {
            if (cam == null)
                Debug.Log("Missing player Camera");
        }
    }
}
