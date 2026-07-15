using UnityEngine;

public static class MobileInput
{
    public static float horizontal;
    public static bool jumpHeld;

    private static bool jumpDownFlag;

    public static void PressJump()
    {
        jumpHeld = true;
        jumpDownFlag = true;
    }

    public static void ReleaseJump()
    {
        jumpHeld = false;
    }

    public static bool ConsumeJumpDown()
    {
        if (jumpDownFlag)
        {
            jumpDownFlag = false;
            return true;
        }

        return false;
    }
}
