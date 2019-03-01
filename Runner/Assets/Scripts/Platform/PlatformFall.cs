using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{

    private bool m_falling_;
    private float m_speed_fall_;
    private void Awake()
    {
        m_speed_fall_ = 0;
        m_falling_ = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(m_falling_)
        {
            Fall(0.5f);
            Debug.Log("test");
        }
    }

    private void Fall(float _fSpeedFalling)
    {

        transform.position += -Vector3.up * Time.deltaTime * _fSpeedFalling;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_falling_ = true;
            Debug.Log("test");

        }
    }
}
