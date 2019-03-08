using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public static Loader m_instance_;
    [SerializeField] private GameObject m_pause_canvas;
    [SerializeField] private GameObject m_main_canvas;

    // Use this for initialization
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
        
        
        Instantiate(m_pause_canvas);
        Instantiate(m_main_canvas);
        GameManager.GetInstance();
        SaveManager.GetInstance();
    }

    private void Update()
    {
        LevelManager.GetInstance().Update();
        InputManager.GetInstance().Update();
    }
}