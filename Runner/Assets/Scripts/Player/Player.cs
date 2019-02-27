using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Jump m_jump_;

    private bool m_is_jumping_;
    // Use this for initialization
    void Start()
    {
        m_jump_ = GetComponent<Jump>();
        InputManager.m_instance.OnKeyboardSpaceButtonPressed += OnOnKeyboardSpaceButtonPressed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnOnKeyboardSpaceButtonPressed()
    {
        if (!m_is_jumping_)
            m_jump_.jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
            this.m_is_jumping_ = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
            this.m_is_jumping_ = true;
    }
}
