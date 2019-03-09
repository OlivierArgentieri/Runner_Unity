﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScenes : MonoBehaviour
{
    [SerializeField] private string m_name_scene;
    
    public void LoadScene()
    {
        LevelManager.GetInstance().Loadscene(m_name_scene);
    }
}
