using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    public Camera cam;
    public GameObject handButton;
    public Text handButtonText;
    public GameObject dropButton;
    public GameObject playerHand;
    public GameObject pickablePlaceholder;

    private GameObject pickedObject,openObject;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private bool isHandFull = false;

    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        audioClip = Resources.Load("pick_object") as AudioClip;
        audioSource = gameObject.GetComponent<AudioSource>();
        pickedObject = null;
    }

    void Update()
    {
        ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray, out hit, 1.8f))
        {
            ResetCanvasInfoAboutObjects();

            if (hit.transform.gameObject.tag == "Pickable" && isHandFull == false)
            {
               
                pickedObject = hit.transform.gameObject;

                handButton.SetActive(true);
                handButton.GetComponent<Button>().onClick.RemoveAllListeners();
                handButton.GetComponent<Button>().onClick.AddListener(PickupObject);
                handButtonText.text = "Pick "+ pickedObject.GetComponent<PickableObject>().itemName;
            }
            else if(hit.transform.gameObject.tag == "OpenItem"){

                openObject = hit.transform.gameObject;

                handButton.SetActive(true);
                handButton.GetComponent<Button>().onClick.RemoveAllListeners();
                handButton.GetComponent<Button>().onClick.AddListener(OpenCloseItem);
                handButtonText.text = "Open/Close";
            }
            else if(hit.transform.gameObject.tag == "KeypadButtonToPress")
            {
                openObject = hit.transform.gameObject;

                handButton.SetActive(true);
                handButton.GetComponent<Button>().onClick.RemoveAllListeners();
                handButton.GetComponent<Button>().onClick.AddListener(KeypadObject);
                handButtonText.text = "Tap Code";
            }
            else if(hit.transform.gameObject.tag == "Puzzle")
            {
                openObject = hit.transform.gameObject;
                if (pickedObject != null && 
                    pickedObject.GetComponent<PickableObject>().itemTypeID == openObject.GetComponent<PuzzleToSolve>().fixPuzzleObjectID &&
                    openObject.GetComponent<PuzzleToSolve>().isFixed == false) {
                    handButton.SetActive(true);
                    handButton.GetComponent<Button>().onClick.RemoveAllListeners();
                    handButton.GetComponent<Button>().onClick.AddListener(SolvePuzzle);
                    handButtonText.text = "Use "+ pickedObject.GetComponent<PickableObject>().name;
                }
            }
        }
        else
        {
            ResetCanvasInfoAboutObjects();
        }
    }

    private void ResetCanvasInfoAboutObjects()
    {
        handButtonText.text = "";
        handButton.SetActive(false);
    }

    public void PickupObject()
    {
        if (pickedObject)
        {
            pickedObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            pickedObject.transform.GetComponent<Collider>().enabled = false;
            pickedObject.transform.SetParent(playerHand.transform);
            pickedObject.transform.localPosition = pickedObject.GetComponent<PickableObject>().pickedPosition;
            pickedObject.transform.localRotation = pickedObject.GetComponent<PickableObject>().pickedRotation;
            pickedObject.layer = 9;
            audioSource.PlayOneShot(audioClip);
            dropButton.SetActive(true);
            isHandFull = true;
        }
    }

    public void DropObject()
    {
        if (pickedObject)
        {
            pickedObject.transform.SetParent(pickablePlaceholder.transform);
            pickedObject.transform.GetComponent<Rigidbody>().isKinematic = false;
            pickedObject.transform.GetComponent<Rigidbody>().velocity = cam.transform.forward * 5.0f;
            pickedObject.transform.GetComponent<Collider>().enabled = true;
            pickedObject.transform.rotation = new Quaternion(15f,45f,25f,0f);
            pickedObject.layer = 0;
            pickedObject = null;
            dropButton.SetActive(false);
            isHandFull = false;
        }
    }

    public void OpenCloseItem()
    {
        if (openObject)
        {
            openObject.transform.GetComponent<OpenObject>().ChangeState();
           
        }
    }

    public void KeypadObject()
    {
        if (openObject)
        {
            openObject.GetComponentInParent<CodeLock>().PressButton();
        }
    }

    public void SolvePuzzle()
    {
        if (openObject)
        {
            openObject.transform.GetComponent<PuzzleToSolve>().SolvePuzzle(pickedObject.GetComponent<PickableObject>().itemTypeID);
        }
    }
}
