using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 40f;
    public Joystick joystick;

    private float horizontalMove;
    private float verticalMove;

    void Update()
    {
        if (joystick.Horizontal >= 0.2f)
        {
            horizontalMove = runSpeed;
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }

        if (joystick.Vertical >= 0.5f)
        {
            verticalMove = runSpeed;
        }

        if (joystick.Vertical <= -0.5f)
        {
            verticalMove = -runSpeed;
        }
        GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalMove, verticalMove));
    }
}
