using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject m_gameManager;
    [SerializeField] private GameObject m_inputManager;
    [SerializeField] private GameObject m_saveManager;
    [SerializeField] private GameObject m_levelManager;

    [SerializeField] private GameObject m_pause_canvas;
    [SerializeField] private GameObject m_main_canvas;

    // Use this for initialization
    void Awake()
    {

        if (GameManager.m_instance == null)
            Instantiate(m_gameManager);

        if (InputManager.m_instance == null)
            Instantiate(m_inputManager);

        if (SaveManager.m_instance == null)
            Instantiate(m_saveManager);

        if (LevelManager.m_instance == null)
            Instantiate(m_levelManager);

        Instantiate(m_pause_canvas);
        Instantiate(m_main_canvas);
    }
}