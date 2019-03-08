using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLEvel : MonoBehaviour
{
    [SerializeField] private string m_name_scene;
    
    public void LoadScene()
    {
        LevelManager.GetInstance().SwitchScene(m_name_scene);

    }
}
