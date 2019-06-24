using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;

    private Camera camera;
    private RaycastHit hit;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, touchInputMask))
            {
                GameObject recipient = hit.transform.gameObject;
                touchList.Add(recipient);

                if (Input.GetMouseButton(0))
                    recipient.SendMessage(Messages.ON_TOUCH_STAY, hit.point, SendMessageOptions.DontRequireReceiver);
                if (Input.GetMouseButtonDown(0))
                    recipient.SendMessage(Messages.ON_TOUCH_DOWN, hit.point, SendMessageOptions.DontRequireReceiver);
                if (Input.GetMouseButtonUp(0))
                    recipient.SendMessage(Messages.ON_TOUCH_UP, hit.point, SendMessageOptions.DontRequireReceiver);
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