using UnityEngine;

public class UserInputHandler : MonoBehaviour
{
    public delegate void TapAction(Touch t);
    public static event TapAction OnTap;

    public delegate void PanBeganAction(Touch t);
    public static event PanBeganAction OnPanBegan;

    public delegate void PanHeldAction(Touch t);
    public static event PanHeldAction OnPanHeld;

    public delegate void PanEndedAction(Touch t);
    public static event PanEndedAction OnPanEnded;

    /// <summary>
    /// Minimum time to hold the finger on the screen to register as a pan gesture
    /// </summary>
    public float panMinTime = 0.4f;
    
    /// <summary>
    /// The time when finger is placed on the screen. It's used later to check if it is a pan gesture.
    /// </summary>
    private float startTime;
    private bool panGestureRecognized = false;

    public float tapMaxMovement = 50f;
    private Vector2 movement;
    private bool tapGestureFailed;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                movement = Vector2.zero;
                startTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                movement += touch.deltaPosition;

                if (!panGestureRecognized && Time.time - startTime > panMinTime)
                {
                    // pan started
                    panGestureRecognized = true;
                    tapGestureFailed = true;
                    OnPanBegan?.Invoke(touch);
                }
                else if (panGestureRecognized)
                {
                    // panning
                    OnPanHeld?.Invoke(touch);
                }
                else if (movement.magnitude > tapMaxMovement)
                {
                    tapGestureFailed = true;
                }
            }
            else
            {
                // TouchPhase.Ended or TouchPhase.Canceled
                if (panGestureRecognized)
                {
                    // pan ended
                    OnPanEnded?.Invoke(touch);
                }
                else if (!tapGestureFailed)
                {
                    // tap
                    OnTap?.Invoke(touch);
                }
                // reset
                panGestureRecognized = false;
                tapGestureFailed = false;
            }
        }
    }
}
