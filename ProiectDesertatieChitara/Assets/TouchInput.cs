using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;

    private Camera camera;
    private RaycastHit hit;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    List<RaycastResult> results;

    private void Start()
    {
        camera = GetComponent<Camera>();

        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    private void Update()
    {
        ///---------New Input

#if UNITY_EDITOR
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
            {

                touchesOld = new GameObject[touchList.Count];
                touchList.CopyTo(touchesOld);
                touchList.Clear();

                //Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                //Set up the new Pointer Event
                m_PointerEventData = new PointerEventData(m_EventSystem);
                //Set the Pointer Event Position to that of the mouse position
                m_PointerEventData.position = Input.mousePosition;

                //Create a list of Raycast Results
                results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);

                foreach (RaycastResult result in results)
                {
                    GameObject recipient = result.gameObject;
                    touchList.Add(recipient);

                    if (Input.GetMouseButton(0))
                        recipient.SendMessage(Messages.ON_TOUCH_STAY, result.screenPosition, SendMessageOptions.DontRequireReceiver);
                    if (Input.GetMouseButtonDown(0))
                        recipient.SendMessage(Messages.ON_TOUCH_DOWN, result.screenPosition, SendMessageOptions.DontRequireReceiver);
                    if (Input.GetMouseButtonUp(0))
                        recipient.SendMessage(Messages.ON_TOUCH_UP, result.screenPosition, SendMessageOptions.DontRequireReceiver);
                }

                foreach (GameObject g in touchesOld)
                {
                    if (!touchList.Contains(g))
                    {
                        g.SendMessage(Messages.ON_TOUCH_EXIT, hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
#endif
            if (Input.touchCount > 0)
            {
                touchesOld = new GameObject[touchList.Count];
                touchList.CopyTo(touchesOld);
                touchList.Clear();

                foreach (Touch touch in Input.touches)
                {
                    Ray ray = camera.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out hit, touchInputMask))
                    {
                        GameObject recipient = hit.transform.gameObject;
                        touchList.Add(recipient);

                        switch (touch.phase)
                        {
                            case TouchPhase.Began:
                                recipient.SendMessage(Messages.ON_TOUCH_DOWN, hit.point, SendMessageOptions.DontRequireReceiver);
                                break;

                            case TouchPhase.Stationary:
                            case TouchPhase.Moved:
                                recipient.SendMessage(Messages.ON_TOUCH_STAY, hit.point, SendMessageOptions.DontRequireReceiver);
                                break;

                            case TouchPhase.Ended:
                                recipient.SendMessage(Messages.ON_TOUCH_UP, hit.point, SendMessageOptions.DontRequireReceiver);
                                break;

                            case TouchPhase.Canceled:
                                recipient.SendMessage(Messages.ON_TOUCH_EXIT, hit.point, SendMessageOptions.DontRequireReceiver);
                                break;
                        }
                    }
                }

                foreach (GameObject g in touchesOld)
                {
                    if (!touchList.Contains(g))
                    {
                        g.SendMessage(Messages.ON_TOUCH_EXIT, hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        
    }
}








            //// ------- OLD INPUT
//#if UNITY_EDITOR
//            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
//        {
//            touchesOld = new GameObject[touchList.Count];
//            touchList.CopyTo(touchesOld);
//            touchList.Clear();

//            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

//            if (Physics.Raycast(ray, out hit, touchInputMask))
//            {
//                GameObject recipient = hit.transform.gameObject;
//                touchList.Add(recipient);

//                if (Input.GetMouseButton(0))
//                    recipient.SendMessage(Messages.ON_TOUCH_STAY, hit.point, SendMessageOptions.DontRequireReceiver);
//                if (Input.GetMouseButtonDown(0))
//                    recipient.SendMessage(Messages.ON_TOUCH_DOWN, hit.point, SendMessageOptions.DontRequireReceiver);
//                if (Input.GetMouseButtonUp(0))
//                    recipient.SendMessage(Messages.ON_TOUCH_UP, hit.point, SendMessageOptions.DontRequireReceiver);
//            }

//            foreach (GameObject g in touchesOld)
//            {
//                if (!touchList.Contains(g))
//                {
//                    g.SendMessage(Messages.ON_TOUCH_EXIT, hit.point, SendMessageOptions.DontRequireReceiver);
//                }
//            }
//        }
//#endif

//        if (Input.touchCount > 0)
//        {
//            touchesOld = new GameObject[touchList.Count];
//            touchList.CopyTo(touchesOld);
//            touchList.Clear();

//            foreach (Touch touch in Input.touches)
//            {
//                Ray ray = camera.ScreenPointToRay(touch.position);

//                if (Physics.Raycast(ray, out hit, touchInputMask))
//                {
//                    GameObject recipient = hit.transform.gameObject;
//                    touchList.Add(recipient);

//                    switch (touch.phase)
//                    {
//                        case TouchPhase.Began:
//                            recipient.SendMessage(Messages.ON_TOUCH_DOWN, hit.point, SendMessageOptions.DontRequireReceiver);
//                            break;

//                        case TouchPhase.Stationary:
//                        case TouchPhase.Moved:
//                            recipient.SendMessage(Messages.ON_TOUCH_STAY, hit.point, SendMessageOptions.DontRequireReceiver);
//                            break;

//                        case TouchPhase.Ended:
//                            recipient.SendMessage(Messages.ON_TOUCH_UP, hit.point, SendMessageOptions.DontRequireReceiver);
//                            break;

//                        case TouchPhase.Canceled:
//                            recipient.SendMessage(Messages.ON_TOUCH_EXIT, hit.point, SendMessageOptions.DontRequireReceiver);
//                            break;
//                    }
//                }
//            }

//            foreach (GameObject g in touchesOld)
//            {
//                if (!touchList.Contains(g))
//                {
//                    g.SendMessage(Messages.ON_TOUCH_EXIT, hit.point, SendMessageOptions.DontRequireReceiver);
//                }
//            }
//        }
//    }
//}