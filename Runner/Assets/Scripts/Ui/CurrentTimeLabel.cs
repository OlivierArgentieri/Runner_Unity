using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTimeLabel : MonoBehaviour
{
    [SerializeField] private Text m_label_current_time_instance;
    // Use this for initialization
    void Start()
    {
        LevelManager.GetInstance().RegisterTextCurrentTimeLabel(m_label_current_time_instance);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
