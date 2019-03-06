using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager m_instance;
    private Text m_current_time_label_instance_;
    private Text m_saved_time_label_instance_;
    private Timer m_timer_;
    private GameObject m_pause_canvas_;
    private bool m_paused_ = false;
    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;


        if (m_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        m_timer_ = new Timer();
        m_timer_.StartTimer(Time.time);

        InputManager.m_instance.OnKeyboardEscapeButtonPressed += PauseCurrentLevel;
    }


    // Update is called once per frame
    void Update()
    {
        DisplayTime(m_timer_.GetCurrentTime(Time.time));
    }

    public void RegisterTextCurrentTimeLabel(Text _tTimeLabelInstance)
    {
        this.m_current_time_label_instance_ = _tTimeLabelInstance;
    }

    public void RegisterPauseCanvas(GameObject _cPauseCanvas)
    {
        m_pause_canvas_ = _cPauseCanvas;
        m_pause_canvas_.SetActive(false);
    }

    public void RegisterTextSavedTimeLabel(Text _tTimeLabelInstance)
    {
        this.m_saved_time_label_instance_ = _tTimeLabelInstance;
    }
    public void SwitchScene(string _sNextSceneName)
    {
        SceneManager.LoadScene(_sNextSceneName);
        SaveManager.m_instance.SaveBestTimeByLevelName(SceneManager.GetActiveScene().name, m_timer_.GetCurrentTime(Time.time));
        m_timer_.ResetTimer(Time.time);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetLevel()
    {
        RestartLevel();
        m_timer_.ResetTimer(Time.time);
    }

    public string GetCurrentNameSecene()
    {
        return SceneManager.GetActiveScene().name;
    }

    private void DisplayTime(float _fTime)
    {
        if (m_current_time_label_instance_ != null)
            m_current_time_label_instance_.text = string.Format("time : {0} s", _fTime.ToString("0.0"));
    }

    private void DisplaySavedTime(float _fTime)
    {
        if (m_saved_time_label_instance_ != null)
            m_saved_time_label_instance_.text = string.Format("Record : {0} s", _fTime.ToString("0.0"));
    }

    public void RefreshSavedTime()
    {
        DisplaySavedTime(SaveManager.m_instance.GetTimeByLevel(SceneManager.GetActiveScene().name));
    }

    public void PauseCurrentLevel()
    {
        if (!m_paused_)
        {
            Time.timeScale = 0;
            m_pause_canvas_.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            m_pause_canvas_.SetActive(false);
        }
        m_paused_ = !m_paused_;
    }
}