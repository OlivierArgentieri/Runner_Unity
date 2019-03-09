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
        if (m_instance_ == null)
            m_instance_ = this;
        if (m_instance_ != this)
        {
            Destroy(gameObject);
            return;
        }

        m_instance_ = this;
        //DontDestroyOnLoad(gameObject);
        
        Instantiate(m_pause_canvas);
        Instantiate(m_main_canvas);

        SoundManager.GetInstance().RegisterMainTheme(m_main_theme);
        GameManager.GetInstance(); // todo
        SaveManager.GetInstance(); // todo
        LevelManager.GetInstance();
    }

    private void Update()
    {
        //LevelManager.GetInstance().Update(); // todo
        InputManager.GetInstance().Update(); // todo
    }
    
    /*public static Loader GetInstance()
    {
        if (m_instance_ == null)
        {
            GameObject go = new GameObject("Loader");
            go.AddComponent<Loader>();
        }
        return m_instance_;
    }*/
}