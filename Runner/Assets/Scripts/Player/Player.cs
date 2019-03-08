using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Analytics;

public class Player : MonoBehaviour
{
    private Jump m_jump_;
    private Move m_move_;
    private bool m_is_jumping_;

    private bool m_move_forward_pressed_;
    private bool m_move_backward_pressed_;
    private bool m_move_left_pressed_;
    private bool m_move_right_pressed_;
    // Use this for initialization

    void Start()
    {
        m_jump_ = GetComponent<Jump>();
        m_move_ = GetComponent<Move>();
        m_move_forward_pressed_ = false;
        m_move_backward_pressed_ = false;
        m_move_left_pressed_ = false;
        m_move_right_pressed_ = false;

        InputManager.GetInstance().OnKeyboardMoveForwardButtonPressed += OnKeyboardMoveForwardButtonPressedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveBackwardButtonPressed += OnKeyboardMoveBackwardButtonPressedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveForwardButtonReleased += OnKeyboardMoveForwardButtonReleasedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveBackwardButtonReleased += OnKeyboardMoveBackwardButtonReleasedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveLeftButtonPressed += OnKeyboardMoveLeftButtonPressedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveLeftButtonReleased += OnKeyboardMoveLeftButtonReleasedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveRightButtonPressed += OnKeyboardMoveRightButtonPressedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveRightButtonReleased += OnKeyboardMoveRightButtonReleasedEventHandler;
        InputManager.GetInstance().OnKeyboardSpaceButtonPressed += OnKeyboardSpaceButtonPressedEventHandler;
        InputManager.GetInstance().OnKeyboardActivateButtonPressed += OnKeyboardActivateButtonPressedEventHandler;
        GameManager.m_instance.RegisterPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_move_forward_pressed_)
            m_move_.MoveForward();

        if (m_move_backward_pressed_)
            m_move_.MoveBackward();

        if (m_move_left_pressed_)
            m_move_.MoveLeft();
        if (m_move_right_pressed_)
            m_move_.MoveRight();
      //  else
       //     m_move_.ResetMove();
    }

    public void OnKeyboardMoveForwardButtonPressedEventHandler()
    {
        m_move_forward_pressed_ = true;
    }

    public void OnKeyboardMoveBackwardButtonPressedEventHandler()
    {
        m_move_backward_pressed_ = true;
    }

    public void OnKeyboardMoveForwardButtonReleasedEventHandler()
    {
        m_move_forward_pressed_ = false;
    }

    public void OnKeyboardMoveBackwardButtonReleasedEventHandler()
    {
        m_move_backward_pressed_ = false;
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

    private void OnKeyboardSpaceButtonPressedEventHandler()
    {
        m_jump_.MakeJump();
    }

    private void OnKeyboardActivateButtonPressedEventHandler()
    {
        RaycastHit hit;
        Ray Ray = new Ray(transform.position, Vector3.forward);
        var button = Physics.SphereCastAll(Ray, 0.3f).FirstOrDefault( o=> o.collider.tag == "Button");

        if (!button.Equals(default(RaycastHit)))
        {
            button.collider.gameObject.GetComponent<ButtonActivable>().Activate();
        }
    }

    private void OnDestroy()
    {
        InputManager.GetInstance().OnKeyboardMoveForwardButtonPressed -= OnKeyboardMoveForwardButtonPressedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveBackwardButtonPressed -= OnKeyboardMoveBackwardButtonPressedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveForwardButtonReleased -= OnKeyboardMoveForwardButtonReleasedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveBackwardButtonReleased -= OnKeyboardMoveBackwardButtonReleasedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveLeftButtonPressed -= OnKeyboardMoveLeftButtonPressedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveLeftButtonReleased -= OnKeyboardMoveLeftButtonReleasedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveRightButtonPressed -= OnKeyboardMoveRightButtonPressedEventHandler;
        InputManager.GetInstance().OnKeyboardMoveRightButtonReleased -= OnKeyboardMoveRightButtonReleasedEventHandler;
        InputManager.GetInstance().OnKeyboardSpaceButtonPressed -= OnKeyboardSpaceButtonPressedEventHandler;
        InputManager.GetInstance().OnKeyboardActivateButtonPressed -= OnKeyboardActivateButtonPressedEventHandler;
    }
}