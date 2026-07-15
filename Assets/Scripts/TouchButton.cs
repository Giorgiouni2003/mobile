using UnityEngine;
using UnityEngine.EventSystems;

public class TouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum Action
    {
        Left,
        Right,
        Jump,
    }

    public Action action;

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (action)
        {
            case Action.Left:
                MobileInput.horizontal = -1f;
                break;
            case Action.Right:
                MobileInput.horizontal = 1f;
                break;
            case Action.Jump:
                MobileInput.PressJump();
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        switch (action)
        {
            case Action.Left:
                if (MobileInput.horizontal < 0f) MobileInput.horizontal = 0f;
                break;
            case Action.Right:
                if (MobileInput.horizontal > 0f) MobileInput.horizontal = 0f;
                break;
            case Action.Jump:
                MobileInput.ReleaseJump();
                break;
        }
    }

}
