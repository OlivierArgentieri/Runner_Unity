using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float m_start_time_;
    private bool m_started_;
    private float m_current_time_;

    // Update is called once per frame
    void Update()
    {
        if(m_started_)
        {
            Count();
            Debug.Log(GetCurrentTime());
        }
    }

    public void StartTimer()
    {
        m_start_time_ = Time.time;
        m_started_ = true;
    }

    private void Count()
    {
        m_current_time_ = Time.time - m_start_time_;
    }

    public float GetCurrentTime()
    {
        return m_current_time_;
    }

    public void StopTimer()
    {
        m_started_ = false;
        ResetTimer();
    }

    public void ResetTimer()
    {
        this.m_start_time_ = Time.time;
    }

    public void PauseTimer()
    {
        m_started_ = !m_started_;
    }
}
