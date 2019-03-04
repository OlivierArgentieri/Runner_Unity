﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager m_instance;
    private Player m_player_instance_;
    private Move m_move_instance_;
    private Text m_current_time_label_instance_;
    private float m_start_time_;
    private float m_current_time_;

    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;


        if (m_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        m_start_time_ = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        m_current_time_ = Time.time - m_start_time_;
        DisplayTime(Time.time);
    }

    public void RegisterTextMeterLabel(Text _tMeterLabelInstance)
    {
        this.m_current_time_label_instance_ = _tMeterLabelInstance;
    }

    public void RegisterPlayer(Player _pPlayerInstance)
    {
        m_player_instance_ = _pPlayerInstance;
        m_move_instance_ = _pPlayerInstance.GetComponent<Move>();
    }

    private void DisplayTime(float _fTime)
    {
        m_current_time_label_instance_.text = string.Format("time : {0} s", _fTime.ToString("0.0"));
    }

    public void SwitchScene(string _sNextSceneName)
    {
        SceneManager.LoadScene(_sNextSceneName);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float GetCurrentTime()
    {
        return m_current_time_;
    }
}