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
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

        StartCoroutine("TriggerInput");
    }

    private IEnumerator m_coroutine_;

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
    

    private IEnumerator TriggerInput()
    {
        while(true)
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

            TriggerKeyboardSpaceButtonEventHandler();
            yield return null;
        }
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
        if (OnKeyboardMoveForwardButtonPressed != null && Input.GetKeyDown(KeyCode.Z))
            OnKeyboardMoveForwardButtonPressed();
    }

    public void TriggerKeyboardMoveBackwardButtonPressed()
    {
        if (OnKeyboardMoveBackwardButtonPressed  != null && Input.GetKeyDown(KeyCode.S))
            OnKeyboardMoveBackwardButtonPressed();
    }

    public void TriggerKeyboardMoveForwardButtonReleased()
    {
        if (OnKeyboardMoveForwardButtonReleased != null && Input.GetKeyUp(KeyCode.Z))
            OnKeyboardMoveForwardButtonReleased();
    }

    public void TriggerKeyboardMoveBackwardButtonReleased()
    {
        if (OnKeyboardMoveBackwardButtonReleased != null && Input.GetKeyUp(KeyCode.S))
            OnKeyboardMoveBackwardButtonReleased();
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