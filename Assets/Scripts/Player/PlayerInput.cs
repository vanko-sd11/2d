using UnityEngine;

public class PlayerInput
{
    public float movement { get; private set; }
    public bool isJump { get; private set; }

    public void Move()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
            isJump = true;
    }
    public void ConsumeJump()
    {
        isJump = false;
    }
}
