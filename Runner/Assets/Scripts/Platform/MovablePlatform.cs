﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField] private float m_speed;
    private bool m_reversed_;

    private void Awake()
    {
        m_reversed_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move(m_speed);
    }

    private void Move(float _fSpeed)
    {
        transform.position += Vector3.forward * Time.deltaTime * _fSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            m_reversed_ = !m_reversed_;
    }
}