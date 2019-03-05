using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedTimeLabel : MonoBehaviour
{
    [SerializeField] private Text m_label_saved_time_instance;
    // Use this for initialization
    void Start()
    {
        LevelManager.m_instance.RegisterTextSavedTimeLabel(m_label_saved_time_instance);
        LevelManager.m_instance.RefreshSavedTime();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
