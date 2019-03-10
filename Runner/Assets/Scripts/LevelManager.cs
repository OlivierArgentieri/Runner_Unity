using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager m_instance_;

    private Text m_current_time_label_instance_;
    private Text m_saved_time_label_instance_;
    private Text m_can_press_e_label_instance_;
    private Timer m_timer_;
    private GameObject m_pause_canvas_;
    private bool m_paused_ = false;


    public static LevelManager GetInstance()
    {
        if (m_instance_ == null)
        {
            GameObject go = new GameObject("LevelManager");
            go.AddComponent<LevelManager>();
        }
        return m_instance_;
    }

    private void Awake()
    {
        if (m_instance_ == null)
            m_instance_ = this;
        if (m_instance_ != this)
        {
            Destroy(gameObject);
            return;
        }

        m_instance_ = this;
        m_timer_ = new Timer();
        m_timer_.StartTimer(Time.time);
        InputManager.GetInstance().OnKeyboardEscapeButtonPressed += PauseCurrentLevel;
    }
    
    public void Update()
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

    public void RegisterCanPressELabel(Text _tCanPressELabelInstance)
    {
        this.m_can_press_e_label_instance_ = _tCanPressELabelInstance;
    }

    public void SwitchScene(string _sNextSceneName)
    {
        Loadscene(_sNextSceneName);
        SaveManager.GetInstance().SaveBestTimeByLevelName(SceneManager.GetActiveScene().name, m_timer_.GetCurrentTime(Time.time));
        m_timer_.ResetTimer(Time.time);
        Time.timeScale = 1f;
        m_paused_ = false;
        SoundManager.GetInstance().PlayMainTheme();

    }

    public void Loadscene(string _sSceneName)
    {
        SceneManager.LoadScene(_sSceneName);
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

    public string GetCurrentNameScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void SetActiveDisplayPressE(bool _bDisplay)
    {
        if (m_can_press_e_label_instance_ != null)
            m_can_press_e_label_instance_.enabled = _bDisplay;
    }

    private void DisplayTime(float _fTime)
    {
        if (m_current_time_label_instance_ != null)
            m_current_time_label_instance_.text = string.Format("time : {0:0.0} s", _fTime);
    }

    private void DisplaySavedTime(float _fTime)
    {
        if (m_saved_time_label_instance_ != null)
            m_saved_time_label_instance_.text = string.Format("Record : {0:0.0} s", _fTime);
    }

    public void RefreshSavedTime()
    {
        DisplaySavedTime(SaveManager.GetInstance().GetTimeByLevel(SceneManager.GetActiveScene().name)); // todo
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

    private void OnDestroy()
    {
        InputManager.GetInstance().OnKeyboardEscapeButtonPressed -= PauseCurrentLevel;
    }
}