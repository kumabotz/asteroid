using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputHandler : MonoBehaviour
{
    public delegate void TapAction(Touch t);
    public static event TapAction OnTap;

    public float tapMaxMovement = 50f;
    private Vector2 movement;
    private bool tapGestureFailed;

    void Start()
    {

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                movement = Vector2.zero;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                movement += touch.deltaPosition;
                if (movement.magnitude > tapMaxMovement)
                {
                    tapGestureFailed = true;
                }
            }
            else
            {
                // TouchPhase.Ended or TouchPhase.Canceled
                if (!tapGestureFailed)
                {
                    if (OnTap != null)
                    {
                        OnTap(touch);
                    }
                }

                tapGestureFailed = false;
            }
        }
    }
}
