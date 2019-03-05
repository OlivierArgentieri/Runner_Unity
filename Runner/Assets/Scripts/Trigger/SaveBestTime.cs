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
        SaveManager.m_instance.SaveLevelData(new LevelData { m_level_name = GameManager.m_instance.GetCurrentNameSecne(), m_saved_time = 10 });
        // if (GameManager.m_instance.GetCurrentTime() > SaveManager.m_instance.GetSavedTime())
        // SaveManager.m_instance.SaveTime(GameManager.m_instance.GetCurrentTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            SaveTime();
    }
}