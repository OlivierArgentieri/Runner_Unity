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

    public delegate void RightArrowKeyboardButtonEventHandler();
    public event RightArrowKeyboardButtonEventHandler OnKeyboardRightArrowButtonPressed;

    public delegate void SpaceKeyboardButtonEventHandler();
    public event SpaceKeyboardButtonEventHandler OnKeyboardSpaceButtonPressed;

    private void Update()
    {
        TriggerMouseEventHandler();
        TriggerLeftMouseButtonEventHandler();
        TriggerRightMouseButtonEventHandler();
        TriggerKeyboardButtonPressed();
        TriggerKeyboardRightArrowButtonEventHandler();
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

    public void TriggerKeyboardButtonPressed()
    {
        if (OnKeyboardButtonPressed != null)
            OnKeyboardButtonPressed(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public void TriggerKeyboardRightArrowButtonEventHandler()
    {
        if (OnKeyboardRightArrowButtonPressed != null && Input.GetKeyDown(KeyCode.RightArrow))
            OnKeyboardRightArrowButtonPressed();
    }

    public void TriggerKeyboardSpaceButtonEventHandler()
    {
        if (OnKeyboardSpaceButtonPressed != null && Input.GetKeyDown(KeyCode.Space))
            OnKeyboardSpaceButtonPressed();
    }
}