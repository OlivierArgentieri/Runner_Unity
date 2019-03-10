using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PauseCanvasScript : MonoBehaviour
{
    [SerializeField] private Slider m_volume_slider;

    void Start()
    {
        LevelManager.GetInstance().RegisterPauseCanvas(this.gameObject);
        InitSliderWithSound();
    }

    public void RestartLevel()
    {
        LevelManager.GetInstance().ResetLevel();
        LevelManager.GetInstance().PauseCurrentLevel();
    }

    public void OnValueChange()
    {
        if (m_volume_slider != null)
            SoundManager.GetInstance().ChangeVolume(m_volume_slider.value);
    }

    public void InitSliderWithSound()
    {
        if (m_volume_slider != null)
            m_volume_slider.value = SoundManager.GetInstance().GetCurrentVolume();
    }
}