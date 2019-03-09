using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    private static Loader m_instance_;
    [SerializeField] private GameObject m_pause_canvas;
    [SerializeField] private GameObject m_main_canvas;
    [SerializeField] private AudioClip m_main_theme;

    void Awake()
    {
        Instantiate(m_pause_canvas);
        Instantiate(m_main_canvas);

        SoundManager.GetInstance().RegisterMainTheme(m_main_theme);
        GameManager.GetInstance(); // todo
        SaveManager.GetInstance(); // todo
        //LevelManager.GetInstance();
    }

    private void Update()
    {
        InputManager.GetInstance().Update(); // todo
    }
    
}