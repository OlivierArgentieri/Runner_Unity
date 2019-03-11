using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputManager
{
    private static InputManager m_instance_;
    public static InputManager GetInstance()
    {
        if (m_instance_ == null)
            m_instance_ = new InputManager();
        return m_instance_;
    }
    
    public delegate void MouseEventHandler(float _fxValue, float _fyValue, float _fWheelValue);
    public event MouseEventHandler OnMouse;

    public delegate void LeftMouseButtonEventHandler();
    public event LeftMouseButtonEventHandler OnClickLeftMouseButton;

    public delegate void RightMouseButtonEventHandler();
    public event RightMouseButtonEventHandler OnClickRightMouseButton;

    public delegate void KeyboardButtonEventHandler(float _fHorizontalValue, float _fVerticalValue);
    public event KeyboardButtonEventHandler OnKeyboardButtonPressed;

    // move forward pressed
    public delegate void MoveForwardKeyboardButtonPressedEventHandler();
    public event MoveForwardKeyboardButtonPressedEventHandler OnKeyboardMoveForwardButtonPressed;

    // move backward pressed
    public delegate void MoveBackwardKeyboardButtonPressedEventHandler();
    public event MoveBackwardKeyboardButtonPressedEventHandler OnKeyboardMoveBackwardButtonPressed;

    // move forward Released 
    public delegate void MoveForwardKeyboardButtonReleasedEventHandler();
    public event MoveForwardKeyboardButtonReleasedEventHandler OnKeyboardMoveForwardButtonReleased;

    // move backward Released
    public delegate void MoveBackwardKeyboardButtonReleasedEventHandler();
    public event MoveBackwardKeyboardButtonReleasedEventHandler OnKeyboardMoveBackwardButtonReleased;

    // move left pressed
    public delegate void MoveLeftKeyboardButtonPressedEventHandler();
    public event MoveLeftKeyboardButtonPressedEventHandler OnKeyboardMoveLeftButtonPressed;

    // move Right pressed
    public delegate void MoveRightKeyboardButtonPressedEventHandler();
    public event MoveRightKeyboardButtonPressedEventHandler OnKeyboardMoveRightButtonPressed;

    // move left Released
    public delegate void MoveLeftKeyboardButtonReleasedEventHandler();
    public event MoveLeftKeyboardButtonReleasedEventHandler OnKeyboardMoveLeftButtonReleased;

    // move Right Released
    public delegate void MoveRightKeyboardButtonReleasedEventHandler();
    public event MoveRightKeyboardButtonReleasedEventHandler OnKeyboardMoveRightButtonReleased;

    // space bar
    public delegate void SpaceKeyboardButtonPressedEventHandler();
    public event SpaceKeyboardButtonPressedEventHandler OnKeyboardSpaceButtonPressed;

    // E pressed
    public delegate void KeyboardActivateButtonPressedEventHandler();
    public event KeyboardActivateButtonPressedEventHandler OnKeyboardActivateButtonPressed;

    // E released
    public delegate void KeyboardActivateButtonReleasedEventHandler();
    public event KeyboardActivateButtonReleasedEventHandler OnKeyboardActivateButtonReleased;

    // Escaped pressed
    public delegate void KeyboardEscapeButtonPressedEventHandler();
    public event KeyboardEscapeButtonPressedEventHandler OnKeyboardEscapeButtonPressed;

    // Escaped released
    public delegate void KeyboardEscapeButtonReleasedEventHandler();
    public event KeyboardEscapeButtonReleasedEventHandler OnKeyboardEscapeButtonReleased;
    
    public void Update()
    {
        TriggerMouseEventHandler();
        TriggerLeftMouseButtonEventHandler();
        TriggerRightMouseButtonEventHandler();

        TriggerKeyboardMoveForwardButtonPressed();
        TriggerKeyboardMoveBackwardButtonPressed();
        TriggerKeyboardMoveForwardButtonReleased();
        TriggerKeyboardMoveBackwardButtonReleased();

        TriggerKeyboardMoveLeftButtonPressed();
        TriggerKeyboardMoveLeftButtonReleased();
        TriggerKeyboardMoveRightButtonPressed();
        TriggerKeyboardMoveRightButtonReleased();

        TriggerKeyboardSpaceButtonPressedEventHandler();

        TriggerKeyboardActivateButtonPressedEventHandler();
        TriggerKeyboardActivateButtonReleasedEventHandler();

        TriggerKeyboardEscapeButtonPressedEventHandler();
        TriggerKeyboardEscapeButtonReleasedEventHandler();
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

    public void TriggerKeyboardMoveForwardButtonPressed()
    {
        if (OnKeyboardMoveForwardButtonPressed != null && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W)))
            OnKeyboardMoveForwardButtonPressed();
    }

    public void TriggerKeyboardMoveBackwardButtonPressed()
    {
        if (OnKeyboardMoveBackwardButtonPressed  != null && Input.GetKeyDown(KeyCode.S))
            OnKeyboardMoveBackwardButtonPressed();
    }

    public void TriggerKeyboardMoveForwardButtonReleased()
    {
        if (OnKeyboardMoveForwardButtonReleased != null && (Input.GetKeyUp(KeyCode.Z) ||Input.GetKeyUp(KeyCode.W)))
            OnKeyboardMoveForwardButtonReleased();
    }

    public void TriggerKeyboardMoveBackwardButtonReleased()
    {
        if (OnKeyboardMoveBackwardButtonReleased != null && Input.GetKeyUp(KeyCode.S))
            OnKeyboardMoveBackwardButtonReleased();
    }

    public void TriggerKeyboardMoveLeftButtonPressed()
    {
        if (OnKeyboardMoveLeftButtonPressed != null && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A)))
            OnKeyboardMoveLeftButtonPressed();
    }

    public void TriggerKeyboardMoveRightButtonPressed()
    {
        if (OnKeyboardMoveRightButtonPressed != null && Input.GetKeyDown(KeyCode.D))
            OnKeyboardMoveRightButtonPressed();
    }

    public void TriggerKeyboardMoveLeftButtonReleased()
    {
        if (OnKeyboardMoveLeftButtonReleased != null && (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.A)))
            OnKeyboardMoveLeftButtonReleased();
    }

    public void TriggerKeyboardMoveRightButtonReleased()
    {
        if (OnKeyboardMoveRightButtonReleased != null && Input.GetKeyUp(KeyCode.D))
            OnKeyboardMoveRightButtonReleased();
    }

    public void TriggerKeyboardSpaceButtonPressedEventHandler()
    {
        if (OnKeyboardSpaceButtonPressed != null && Input.GetKeyDown(KeyCode.Space))
            OnKeyboardSpaceButtonPressed();
    }

    public void TriggerKeyboardActivateButtonPressedEventHandler()
    {
        if (OnKeyboardActivateButtonPressed != null && Input.GetKeyDown(KeyCode.E))
            OnKeyboardActivateButtonPressed();
    }

    public void TriggerKeyboardActivateButtonReleasedEventHandler()
    {
        if (OnKeyboardActivateButtonReleased != null && Input.GetKeyUp(KeyCode.E))
            OnKeyboardActivateButtonReleased();
    }

    public void TriggerKeyboardEscapeButtonPressedEventHandler()
    {
        if (OnKeyboardEscapeButtonPressed != null && Input.GetKeyDown(KeyCode.Escape))
            OnKeyboardEscapeButtonPressed();
    }

    public void TriggerKeyboardEscapeButtonReleasedEventHandler()
    {
        if (OnKeyboardEscapeButtonReleased != null && Input.GetKeyUp(KeyCode.Escape))
            OnKeyboardEscapeButtonReleased();
    }
}