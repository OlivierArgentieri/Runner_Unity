using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Jump m_jump_;
    private Move m_move_;
    private bool m_is_jumping_;

    private bool m_move_left_pressed_;
    private bool m_move_right_pressed_;

    // Use this for initialization
    void Start()
    {
        GameManager.m_instance.RegisterPlayer(this);

        m_jump_ = GetComponent<Jump>();

        m_move_ = GetComponent<Move>();
        m_move_left_pressed_ = false;
        m_move_right_pressed_ = false;
        InputManager.m_instance.OnKeyboardSpaceButtonPressed += OnKeyboardSpaceButtonPressedEventHandler;
        InputManager.m_instance.OnKeyboardMoveLeftButtonPressed += OnKeyboardMoveLeftButtonPressedEventHandler;
        InputManager.m_instance.OnKeyboardMoveLeftButtonReleased += OnKeyboardMoveLeftButtonReleasedEventHandler;
        InputManager.m_instance.OnKeyboardMoveRightButtonPressed += OnKeyboardMoveRightButtonPressedEventHandler;
        InputManager.m_instance.OnKeyboardMoveRightButtonReleased += OnKeyboardMoveRightButtonReleasedEventHandler;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_move_left_pressed_)
            m_move_.MoveLeft();
        else if (m_move_right_pressed_)
            m_move_.MoveRight();
        else
            m_move_.ResetMove();

        m_move_.MoveForward();
    }

    private void OnKeyboardSpaceButtonPressedEventHandler()
    {
        m_jump_.MakeJump();
    }

    private void OnKeyboardMoveLeftButtonPressedEventHandler()
    {
        m_move_left_pressed_ = true;
    }

    private void OnKeyboardMoveRightButtonPressedEventHandler()
    {
        m_move_right_pressed_ = true;
    }

    private void OnKeyboardMoveLeftButtonReleasedEventHandler()
    {
        m_move_left_pressed_ = false;
    }

    private void OnKeyboardMoveRightButtonReleasedEventHandler()
    {
        m_move_right_pressed_ = false;
    }

    private void OnDestroy()
    {
        InputManager.m_instance.OnKeyboardSpaceButtonPressed -= OnKeyboardSpaceButtonPressedEventHandler;
        InputManager.m_instance.OnKeyboardMoveLeftButtonPressed -= OnKeyboardMoveLeftButtonPressedEventHandler;
        InputManager.m_instance.OnKeyboardMoveLeftButtonReleased -= OnKeyboardMoveLeftButtonReleasedEventHandler;
        InputManager.m_instance.OnKeyboardMoveRightButtonPressed -= OnKeyboardMoveRightButtonPressedEventHandler;
        InputManager.m_instance.OnKeyboardMoveRightButtonReleased -= OnKeyboardMoveRightButtonReleasedEventHandler;
    }
}
