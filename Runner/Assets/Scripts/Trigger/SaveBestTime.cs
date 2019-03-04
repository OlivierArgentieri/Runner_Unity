using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBestTime : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SaveTime()
    {
        if (GameManager.m_instance.GetCurrentTime() > SaveManager.m_instance.GetSavedTime())
            SaveManager.m_instance.SaveTime(GameManager.m_instance.GetCurrentTime());
    }
}
