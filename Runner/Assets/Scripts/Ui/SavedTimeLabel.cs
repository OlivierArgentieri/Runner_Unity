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
        LevelManager.GetInstance().RegisterTextSavedTimeLabel(m_label_saved_time_instance);
        LevelManager.GetInstance().RefreshSavedTime();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
