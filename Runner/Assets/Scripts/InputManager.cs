using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager m_instance;

    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;

        if (m_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public delegate void MouseEventHandler(float _fxValue, float _fyValue, float _fWheelValue);
    public event MouseEventHandler OnMouse;

    public delegate void LeftMouseButtonEventHandler();
    public event LeftMouseButtonEventHandler OnClickLeftMouseButton;

    public delegate void RightMouseButtonEventHandler();
    public event RightMouseButtonEventHandler OnClickRightMouseButton;

    public delegate void KeyboardButtonEventHandler(float _fHorizontalValue, float _fVerticalValue);
    public event KeyboardButtonEventHandler OnKeyboardButtonPressed;

    // move left pressed
    public delegate void MoveLeftKeyboardButtonPressedEventHandler();
    public event MoveLeftKeyboardButtonPressedEventHandler OnKeyboardMoveLeftButtonPressed;

    // move Right pressed
    public delegate void MoveRigthKeyboardButtonPressedEventHandler();
    public event MoveRigthKeyboardButtonPressedEventHandler OnKeyboardMoveRightButtonPressed;

    // move left Released
    public delegate void MoveLeftKeyboardButtonReleasedEventHandler();
    public event MoveLeftKeyboardButtonReleasedEventHandler OnKeyboardMoveLeftButtonReleased;

    // move Right Released
    public delegate void MoveRigthKeyboardButtonReleasedEventHandler();
    public event MoveRigthKeyboardButtonReleasedEventHandler OnKeyboardMoveRightButtonReleased;

    // space bar
    public delegate void SpaceKeyboardButtonEventHandler();
    public event SpaceKeyboardButtonEventHandler OnKeyboardSpaceButtonPressed;

    private void Update()
    {
        TriggerMouseEventHandler();
        TriggerLeftMouseButtonEventHandler();
        TriggerRightMouseButtonEventHandler();
        TriggerKeyboardMoveLeftButtonPressed();
        TriggerKeyboardMoveLeftButtonReleased();
        TriggerKeyboardMoveRightButtonPressed();
        TriggerKeyboardMoveRightButtonReleased();
        TriggerKeyboardSpaceButtonEventHandler();
    }

    public void TriggerMouseEventHandler()
    {
        if (OnMouse != null)
            OnMouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse ScrollWheel"));
    }

    public void TriggerLeftMouseButtonEventHandler()
    {
        if (OnClickLeftMouseButton != null && Input.GetKeyDown(KeyCode.Mouse0))
            OnClickLeftMouseButton();
    }

    public void TriggerRightMouseButtonEventHandler()
    {
        if (OnClickRightMouseButton != null && Input.GetKeyDown(KeyCode.Mouse1))
            OnClickRightMouseButton();
    }

    public void TriggerKeyboardMoveLeftButtonPressed()
    {
        if (OnKeyboardMoveLeftButtonPressed != null && Input.GetKeyDown(KeyCode.Q))
            OnKeyboardMoveLeftButtonPressed();
    }

    public void TriggerKeyboardMoveRightButtonPressed()
    {
        if (OnKeyboardMoveRightButtonPressed != null && Input.GetKeyDown(KeyCode.D))
            OnKeyboardMoveRightButtonPressed();
    }

    public void TriggerKeyboardMoveLeftButtonReleased()
    {
        if (OnKeyboardMoveLeftButtonReleased != null && Input.GetKeyUp(KeyCode.Q))
            OnKeyboardMoveLeftButtonReleased();
    }

    public void TriggerKeyboardMoveRightButtonReleased()
    {
        if (OnKeyboardMoveRightButtonReleased != null && Input.GetKeyUp(KeyCode.D))
            OnKeyboardMoveRightButtonReleased();
    }

    public void TriggerKeyboardSpaceButtonEventHandler()
    {
        if (OnKeyboardSpaceButtonPressed != null && Input.GetKeyDown(KeyCode.Space))
            OnKeyboardSpaceButtonPressed();
    }
}