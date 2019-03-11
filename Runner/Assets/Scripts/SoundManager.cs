using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager m_instance_;
    private AudioSource m_main_theme_;
    void Awake()
    {
        if (m_instance_ == null)
            m_instance_ = this;
        if (m_instance_ != this)
        {
            Destroy(gameObject);
            return;
        }

        m_instance_ = this;
        DontDestroyOnLoad(gameObject);
    }

    public static SoundManager GetInstance()
    {
        if (m_instance_ == null)
        {
            GameObject go = new GameObject("SoundManager");
            go.AddComponent<SoundManager>();
        }

        return m_instance_;
    }

    public void PlayMainTheme()
    {
        if (m_main_theme_ != null && !m_main_theme_.isPlaying)
        {
            m_main_theme_.Play();
            m_main_theme_.loop = true;
            m_main_theme_.volume = 0.5f;
        }
    }

    public void StopMainTheme()
    {
        if (m_main_theme_ != null && m_main_theme_.isPlaying)
            m_main_theme_.Stop();
    }

    public void RegisterMainTheme(AudioClip _acAudioMainTheme)
    {
        if (m_main_theme_ == null)
            m_main_theme_ = this.gameObject.AddComponent<AudioSource>();

        if (_acAudioMainTheme != null && m_main_theme_.clip != _acAudioMainTheme)
        {
            m_main_theme_.clip = _acAudioMainTheme;
            PlayMainTheme();
        }
    }

    public void ChangeVolume(float _fVolume)
    {
        if (m_main_theme_ != null)
            m_main_theme_.volume = _fVolume;
    }

    public float GetCurrentVolume()
    {
        if (m_main_theme_ != null)
        {
            return m_main_theme_.volume;
        }

        return 0;
    }
}