using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        this.gameObject.SetActive(false);
        LevelManager.m_instance.RegisterPauseCanvas(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartLevel()
    {
        LevelManager.m_instance.ResetLevel();
        LevelManager.m_instance.PauseCurrentLevel();
    }
}