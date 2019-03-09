using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScenes : MonoBehaviour
{
    [SerializeField] private string m_name_scene;
    
    public void LoadScene()
    {
        LevelManager.GetInstance().Loadscene(m_name_scene);
    }

    public void StartMainTheme()
    {
        SoundManager.GetInstance().PlayMainTheme();
    }

    public void StopMainTheme()
    {
        SoundManager.GetInstance().StopMainTheme();
    }

    public void LoadSceneForLevel()
    {
        LevelManager.GetInstance().Loadscene(m_name_scene);
        Time.timeScale = 1f;
    }
}
