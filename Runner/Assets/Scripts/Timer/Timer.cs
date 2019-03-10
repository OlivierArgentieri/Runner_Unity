using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float m_start_time_;
    
    // Update is called once per frame   
    public void StartTimer(float _currentTime)
    {
        m_start_time_ = _currentTime;
    }
    
    public float GetCurrentTime(float _fcurrentTime)
    {
        return _fcurrentTime - m_start_time_;
    }

    public void ResetTimer(float _currentTime)
    {
        StartTimer(_currentTime);
    }
}